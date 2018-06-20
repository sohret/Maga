using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaWebsite.Helpers;
using PA.Data.Models.PAX;
using Z.EntityFramework.Plus;

namespace PaWebsite.Controllers
{
    public abstract class BaseController : Controller
    {
        ModelPAX _db = new ModelPAX();
        private static string _cookieLangName = "lang";
        public string LangCode { get; set; }
        public int LangID { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Session["isAdmin"] = Request.Cookies.AllKeys.Contains("imgUpload");
            string cultureOnCookie = GetCultureOnCookie(filterContext.HttpContext.Request);
            string cultureOnURL = filterContext.RouteData.Values.ContainsKey("lang") ? filterContext.RouteData.Values["lang"].ToString() : GlobalHelper.DefaultCulture;
            //string culture = (string.IsNullOrEmpty(cultureOnCookie) ? filterContext.RouteData.Values["lang"].ToString() : cultureOnCookie);
            if (cultureOnURL == "null")
            {
                if (!string.IsNullOrEmpty(cultureOnCookie))
                {
                    Response.Redirect(Url.Action("Index", new { lang = cultureOnCookie }));
                }
                Response.Redirect(Url.Action("Index", new { lang = "az" }));
            }
            //if (cultureOnURL != culture)
            //{
            //    Response.Redirect(Url.Action("Index", new { lang = culture }));
            //    culture = cultureOnURL;
            //    //filterContext.HttpContext.Response.RedirectToRoute("LocalizedDefault", new { lang = culture, controller = filterContext.RouteData.Values["controller"], action = filterContext.RouteData.Values["action"] });
            //    //return;
            //}

            string culture = cultureOnURL;
            SetCurrentCultureOnThread(culture);
            if (culture != MultiLanguageViewEngine.CurrentCulture)
            {
                (ViewEngines.Engines[0] as MultiLanguageViewEngine).SetCurrentCulture(culture);
            }

            SetCultureOnCookie(filterContext.HttpContext.Response, culture);


            ///


            ViewBag.Lang = culture;
            LangCode = culture;
            LangID = _db.Language.FromCache(DateTime.Now.AddHours(24)).First(x => x.Code == LangCode).LanguageID;

            ViewBag.LanguagesToChange = _db.Language.AsNoTracking().FromCache().Where(x => x.LanguageForID == LangID && x.LanguageID != LangID).ToList();
            ViewBag.Global_Brands = _db.Brand.AsNoTracking().FromCache("global").OrderBy(x => x.OrderNo).ToList();
            ViewBag.Global_Categories = _db.Category.AsNoTracking().FromCache("global").Where(x => x.LanguageID == LangID).OrderBy(x => x.OrderNo).ToList();
            ViewBag.Global_Colors = _db.Color.AsNoTracking().FromCache("global").Where(x => x.LanguageID == LangID).OrderBy(x => x.OrderNo).ToList();
            ViewBag.Global_Languages = _db.Language.AsNoTracking().FromCache("global").Where(x => x.LanguageID == LangID).OrderBy(x => x.OrderNo).ToList();
            ViewBag.Global_ProductNamePrefixes = _db.ProductNamePrefix.AsNoTracking().FromCache("global").Where(x => x.LanguageID == LangID).ToList();
            ViewBag.Global_Properties = _db.Property.AsNoTracking().FromCache("global").Where(x => x.LanguageID == LangID).OrderBy(x => x.OrderNo).ToList();
            ViewBag.Global_PropertyGroups = _db.PropertyGroup.AsNoTracking().FromCache("global").Where(x => x.LanguageID == LangID).OrderBy(x => x.OrderNo).ToList();
            ViewBag.Global_PropertyValues = _db.PropertyValue.AsNoTracking().FromCache("global").Where(x => x.LanguageID == LangID).ToList();
            ViewBag.Global_Shops = _db.Shop.AsNoTracking().FromCache("global").Where(x => x.LanguageID == LangID).OrderBy(x => x.OrderNo).ToList();
            ViewBag.Global_Prefixes = _db.ProductNamePrefix.AsNoTracking().FromCache("global").Where(x => x.LanguageID == LangID).ToList();

            ViewBag.ParentCategories = ((List<Category>)ViewBag.Global_Categories).Where(x => x.ParentID == 0).OrderBy(x => x.OrderNo).ToList();

            ViewBag.Global_AdsBoardSite = _db.AdsBoardSite.AsNoTracking().FromCache("global").Where(x => x.LanguageID == LangID).ToList();
            ViewBag.Global_AdsBoardSiteCategory = _db.AdsBoardSiteCategory.AsNoTracking().FromCache("global").ToList();

            ///



            base.OnActionExecuting(filterContext);
        }


        private static void SetCurrentCultureOnThread(string lang)
        {
            if (string.IsNullOrEmpty(lang))
                lang = GlobalHelper.DefaultCulture;
            var cultureInfo = new System.Globalization.CultureInfo(lang);
            System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
            System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
        }

        public static String GetCultureOnCookie(HttpRequestBase request)
        {
            var cookie = request.Cookies[_cookieLangName];
            string culture = string.Empty;
            if (cookie != null)
            {
                culture = cookie.Value;
            }
            return culture;
        }

        private void SetCultureOnCookie(HttpResponseBase response, string culture)
        {
            var cookie = new HttpCookie(_cookieLangName);
            cookie.Value = culture;
            cookie.Expires = DateTime.Now.AddYears(1);
            response.Cookies.Add(cookie);
        }
    }
}
