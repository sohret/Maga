using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PaWebsite
{
    public class MvcApplication : System.Web.HttpApplication
    {
        static List<CultureInfo> _existingCulture = new List<CultureInfo>();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            string[] langs = ConfigurationManager.AppSettings["CultureList"].ToLower().Split(',');
            for (int i = 0; i < langs.Length; i++)
            {
                _existingCulture.Add(new CultureInfo(langs[i]));
            }


            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new MultiLanguageViewEngine());
        }

        protected void Application_BeginRequest()
        {
            //HttpContextBase currentContext = new HttpContextWrapper(HttpContext.Current);
            //RouteData routeData = RouteTable.Routes.GetRouteData(currentContext);
            //CultureInfo c;
            //HttpCookie ck; //= new HttpCookie("maga.az");

            //ck = HttpContext.Current.Request.Cookies["maga.az"];

            //if (ck != null)
            //{
            //    routeData.Values["culture"] = ck.Values["culture"];
            //    c = new CultureInfo(ck.Values["culture"]);
            //}

            //try
            //{
            //    if (routeData.Values["culture"] != null && _existingCulture.Contains(new CultureInfo((string)routeData.Values["culture"])))
            //    {
            //        c = new CultureInfo((string)routeData.Values["culture"]);
            //    }
            //    else
            //    {
            //        c = new CultureInfo(ConfigurationManager.AppSettings["culture"]);
            //        routeData.Values["culture"] = c.Name.Substring(0, 2);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    c = new CultureInfo(ConfigurationManager.AppSettings["culture"]);
            //}

            //routeData.Route = RouteTable.Routes["culture"];



            //routeData.Values["culture"] = c.Name.Substring(0, 2);

            //Thread.CurrentThread.CurrentCulture = c;
            //Thread.CurrentThread.CurrentUICulture = c;
            //if (ck==null)
            //{
            //    ck = new HttpCookie("maga.az");
            //    ck.Expires = DateTime.Now.AddYears(1);
            //    ck.Values.Add("culture", c.Name.Substring(0, 2));
            //}
            //else
            //{
            //    ck.Values["culture"] = c.Name.Substring(0, 2);
            //}

            //ck.Values["Expires"] = DateTime.Now.AddYears(1).ToString();
            
            //HttpContext.Current.Response.Cookies.Set(ck);



        }
    }
}