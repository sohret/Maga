//using PA.Data.Models;
using PA.Data.Models.PAX;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Z.EntityFramework.Plus;

namespace PaWebsite.Controllers
{
    public class HomeController : BaseController
    {
        ModelPAX _db = new ModelPAX();

        // First page
        // GET: /Home/
        public ActionResult Index()
        {
            var categories = new List<Category>();
            //Response.Cookies.Add(new HttpCookie("imgUpload", "1"));
            foreach (var cat in (List<Category>)ViewBag.Global_Categories)
            {
                if (!categories.Exists(x => x.CategoryID == cat.CategoryID))
                {
                    categories.Add(cat);
                }
            }

            var firstPageCategories = categories.Where(x => x.FirstPageOrderNo != null).ToList();

            var parentIDs = firstPageCategories.Select(x => x.ParentID).Distinct().ToList();

            var cats = new List<Category>();
            foreach (int id in parentIDs)
            {
                if (id == 0)
                    continue;
                int categoryID = FindRootCategory(id, categories);

                firstPageCategories.Where(x => x.ParentID == id).ToList().ForEach(x => x.ParentID = categoryID);

                if (firstPageCategories.Exists(x => x.CategoryID == categoryID))
                {
                    continue;
                }

                var cat = categories.First(x => x.CategoryID == categoryID);
                firstPageCategories.Add(new Category()
                {
                    CategoryID = categoryID,
                    ParentID = 0,
                    OrderNo = cat.OrderNo,
                    Name = cat.Name
                });
            }

            return View(firstPageCategories.Distinct().OrderBy(x => x.FirstPageOrderNo).ThenBy(x => x.OrderNo).ToList());
        }

        private int FindRootCategory(int parentCategoryID, List<Category> cats)
        {
            var cat = cats.First(x => x.CategoryID == parentCategoryID);
            int returnID = cat.CategoryID;
            while (cat.ParentID != 0)
            {
                cat = cats.FirstOrDefault(x => x.CategoryID == cat.ParentID);
                returnID = cat.CategoryID;
            }
            return returnID;

        }

        public ActionResult About()
        {
            return View();
        }

        // Full Text Search
        public JsonResult FillCategory(string text, int rootCategoryID)
        {
            text = text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            string[] s = text.Replace("  ", " ").Split(' ');
            text = "";
            string likeText = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s.Length > 1 && i > 0 && s[i].Length <= 2)
                {
                    likeText += " and TAGS like N'%" + s[i] + "%'";
                }
                else
                {
                    text += (string.IsNullOrEmpty(text) ? "" : "&") + "\"*" + s[i] + "*\"";
                }
            }


            string query = string.Format("set rowcount 100; Select * from dbo.zSearch where LanguageID = {0} and contains(TAGS, N'{1}') {2} {3}"
                , LangID, text, likeText, (rootCategoryID == -1 ? "" : " and RootCategoryID = " + rootCategoryID));

            var result = _db.zSearch.SqlQuery(query).ToList();
            //.Where(x => x.LanguageID == LangID && x.TAGS.Contains(text)).Select(x => new { x.URL, x.TEXT }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public ActionResult cats()
        {
            return View("AllCategories");
        }


        private IQueryable<Product> GetQuery(int categoryID)
        {

            var query = _db.Product.Where(x => x.CategoryID == categoryID);

            #region FILTER

            int priceFrom = -1, priceTo = -1;

            if (Request.QueryString["pricefrom"] != null && int.TryParse(Request.QueryString["pricefrom"], out priceFrom))
            {
                query = query.Where(x => x.PriceFrom >= priceFrom * 100);
            }
            if (Request.QueryString["priceto"] != null && int.TryParse(Request.QueryString["priceto"], out priceTo))
            {
                query = query.Where(x => x.PriceFrom <= priceTo * 100);
            }

            var brands = new List<int>();
            if (!string.IsNullOrEmpty(Request.QueryString["brand"]))
            {
                brands.AddRange(Request.QueryString["brand"].Split(';').Select(int.Parse).ToList());
            }
            ViewBag.SelectedBrands = brands;

            if (brands != null && brands.Count > 0)
            {
                var xBrands = brands.ToList();
                query = query.Where(x => xBrands.Contains(x.BrandID));
            }

            var colors = new List<int>();
            if (!string.IsNullOrEmpty(Request.QueryString["color"]))
            {
                colors.AddRange(Request.QueryString["color"].Split(';').Select(int.Parse).ToList());
            }
            ViewBag.SelectedColors = colors;

            if (colors != null && colors.Count > 0)
            {
                var xColors = colors.ToList();
                var colorQuery = _db.ShopProduct.Where(x => x.ColorID != null && x.ColorID != 0 && xColors.Contains((int)x.ColorID)).Select(x => x.ProductID);
                query = query.Where(x => colorQuery.Contains(x.ID));
            }

            //if (filters != null)
            //{
            //    var xFilters = filters.ToList();
            //    var filterQuery = _db.ProductPropertyValue.Where(x => xFilters.Contains(x.ID)).Select(x => x.ProductID);
            //    query = query.Where(x => filterQuery.Contains(x.ID));
            //}

            #endregion FILTER

            return query;
        }


        #region Category
        public ActionResult Cat(int id, int page = 1, int order = 1)
        {
            //var arr = filter.Split(',');
            int count = Convert.ToInt32(ConfigurationManager.AppSettings["count"]);
            var cat = _db.Category.FromCache(DateTime.Now.AddHours(1)).FirstOrDefault(x => x.LanguageID == LangID && x.CategoryID == id);
            if (cat == null)
            {
                // TODO: redirect to page not found
                return null;
            }


            if (cat.ParentID == 0)
            {
                ViewBag.RootCategoryID = cat.CategoryID;
            }
            else
            {
                ViewBag.RootCategoryID = FindRootCategory(cat.ParentID, (List<Category>)ViewBag.Global_Categories);
            }

            ViewBag.Category = cat;
            ViewBag.Title = cat.Name;
            if (cat.IsLastLevel)
            {
                int countOnPage = int.Parse(System.Configuration.ConfigurationManager.AppSettings["count"]); ;
                ViewBag.Pagination_CurentPage = page;
                ViewBag.Pagination_CountOnPage = countOnPage;
                //ViewBag.Pagination_Count = _db.Product.Where(x => x.CategoryID == id).Count();



                var query = GetQuery(id);



                // min and max price for price selector
                ViewBag.MinPrice = query.Min(x => x.PriceFrom) / 100;
                ViewBag.MaxPrice = query.Max(x => x.PriceFrom) / 100;
                ViewBag.Pagination_Count = query.Count();

                // sorting
                switch (order)
                {
                    case 1:
                        query = query.OrderBy(x => x.PriceFrom); // price ascending
                        break;
                    case 2:
                        query = query.OrderByDescending(x => x.PriceFrom); // price descending
                        break;
                    case 3:
                        query = query.OrderBy(x => x.Name); // product name ascending
                        break;
                    case 4:
                        query = query.OrderByDescending(x => x.Name); // product name descending
                        break;
                }

                var products = query.Skip((page - 1) * countOnPage).Take(20).ToList();
                ViewBag.Products = products;


                var productIDs = products.Select(x => x.ID).ToList();

                var shopProducts = _db.ShopProduct.Where(x => productIDs.Contains(x.ProductID)).ToList();
                ViewBag.ShopProducts = shopProducts;

                ViewBag.Categories = ((List<Category>)ViewBag.Global_Categories).Where(x => x.ParentID == id).OrderBy(x => x.OrderNo).ToList();

                var brandIds = _db.Product.Where(x => productIDs.Contains(x.ID)).Select(x => x.BrandID).ToList();
                var colorIds = shopProducts.Select(x => x.ColorID).ToList();


                var allProductIDs = _db.Product.Where(x => x.CategoryID == id).Select(x => x.ID);
                var allBrandIds = _db.Product.Where(x => x.CategoryID == cat.CategoryID).Select(x => x.BrandID).ToList();
                ViewBag.Brands = ((List<Brand>)ViewBag.Global_Brands).Where(x => allBrandIds.Contains(x.ID)).ToList();
                var allColorIds = _db.ShopProduct.Where(x => allProductIDs.Contains(x.ProductID)).Select(x => x.ColorID).ToList();
                ViewBag.Colors = ((List<PA.Data.Models.PAX.Color>)ViewBag.Global_Colors).Where(x => x.ColorID != 0 && allColorIds.Contains(x.ColorID)).ToList();

                // for filters creating
                ViewBag.ProductPropertyValues = _db.ProductPropertyValue.Where(x => allProductIDs.Contains(x.ProductID)).ToList();

                ViewBag.ProductDescription = _db.ProductDescription.Where(x => x.LanguageID == LangID && productIDs.Contains(x.ProductID)).ToList();

                return View(products);
            }
            else
            {
                var categories = _db.Category.FromCache(DateTime.Now.AddHours(1)).Where(x => x.LanguageID == LangID).OrderBy(x => x.OrderNo).ToList();
                return View("SubCategory", categories);
            }


        }



        public int TestFilter(int id)
        {
            var query = GetQuery(id);
            int cnt = query.Count();
            return cnt;


            //var filterProperties = Request.QueryString.AllKeys;

            //List<ShopProduct> shopProducts = new List<ShopProduct>();
            //string sqlQuery = "select sp.* from ShopProduct sp inner join Product p on sp.productid = p.id where ";

            //int c = 0;
            //string propName = "";
            //foreach (var prop in filterProperties.ToList())
            //{
            //    if (prop == null)
            //        continue;
            //    var values = Request.QueryString[prop].ToString().Split(';');
            //    int counter = 0;
            //    if (prop != propName)
            //    {
            //        c = 0;
            //    }

            //    if (c == 0 && propName != "")
            //    {
            //        sqlQuery += " and " + prop + " in (";
            //    }
            //    else
            //    {
            //        sqlQuery += prop + " in (";
            //    }

            //    foreach (var val in values)
            //    {
            //        if (val == "")
            //            continue;


            //        if (counter == 0)
            //        {
            //            sqlQuery += val;
            //        }

            //        else if (counter > 0 && counter < values.Length)
            //        {
            //            sqlQuery += " , " + val;
            //        }
            //        counter++;
            //    }
            //    counter = 0;
            //    sqlQuery += ")";
            //    c++;
            //    propName = prop;
            //}


            //return _db.ShopProduct.SqlQuery(sqlQuery).ToList().Count;

        }



        #endregion Category


        #region Product
        public ActionResult Prod(int id)
        {
            var product = _db.Product.First(x => x.ID == id);
            ViewBag.Product = product;

            ViewBag.RootCategoryID = FindRootCategory(product.CategoryID, (List<Category>)ViewBag.Global_Categories);

            ViewBag.ShopProducts = _db.ShopProduct.Where(x => x.ProductID == id).ToList();

            var propertyIds = _db.ProductProperty.Where(x => x.ProductID == id).Select(x => x.PropertyID).ToList();
            var productPropertyValueIds = _db.ProductPropertyValue.Where(x => x.ProductPropertyID == id)
                .Select(x => x.ValueID).ToList();

            ViewBag.Properties = _db.Property.Where(x => propertyIds.Contains(x.PropertyID)).ToList();
            ViewBag.PropertyValues = _db.PropertyValue.Where(x => productPropertyValueIds.Contains(x.ValueID)).ToList();

            var desc = _db.ProductDescription.FirstOrDefault(x => x.LanguageID == LangID && x.ProductID == id);
            ViewBag.ProductDescription = (desc == null ? "" : desc.Description);

            return View(product);
        }


        public PartialViewResult ProdPopupDetail(int id)
        {
            var shopProd = _db.ShopProduct.Where(x => x.ProductID == id).First();

            var propertyIds = _db.ProductProperty.Where(x => x.ProductID == shopProd.ProductID)
                .Select(x => x.PropertyID).ToList();
            var productPropertyValueIds = _db.ProductPropertyValue.Where(x => x.ProductPropertyID == id)
                .Select(x => x.ValueID).ToList();

            ViewBag.Properties = _db.Property.Where(x => propertyIds.Contains(x.PropertyID)).ToList();
            ViewBag.PropertyValues = _db.PropertyValue.Where(x => productPropertyValueIds.Contains(x.ValueID)).ToList();
            ViewBag.Product = _db.Product.First(x => x.ID == id);

            return PartialView("_Prod_PopupDetail", shopProd);
        }

        public ActionResult Comp()
        {
            var compIds = Request.QueryString["compare"].Split(';');
            List<long> ids = new List<long>();
            foreach (var id in compIds)
            {
                if (id != "undefined" && !string.IsNullOrEmpty(id))
                    ids.Add(long.Parse(id));
                else
                    continue;
            }


            var prods = _db.Product.Where(x => ids.Contains(x.ID)).ToList();
            var prodIds = prods.Select(z => z.ID).ToList();
            var prodPropValue = _db.ProductPropertyValue.Where(x => prodIds.Contains(x.ProductID)).ToList();

            ViewBag.ProdPropValue = prodPropValue;

            return View(prods);
        }

        #endregion Product


        public ActionResult Go(int id, int adsId = -1)
        {
            if (adsId == -1)
            {
                ViewBag.RedirectUrl = _db.ShopProduct.First(x => x.ID == id).URL.Replace("amp;", "");
                var track = new ShopProductTracker();
                track.ShopProductID = id;
                // TODO: track.UserID = ???;
                _db.ShopProductTracker.Add(track);
                _db.SaveChangesAsync();

                ViewBag.Method = "post";
            }
            else
            { // GoTo Ads Board Site
                var product = _db.Product.Where(x => x.ID == id).First();
                string brand = ((List<Brand>)ViewBag.Global_Brands).First(x => x.ID == product.BrandID).Name;
                string[] names = product.Name.Split(' ');
                string keyword = brand + " " + names[0] + (names.Length > 1 ? " " + names[1] : "");

                var adsSite = ((List<AdsBoardSite>)ViewBag.Global_AdsBoardSite).First(x => x.ID == adsId);
                var adsCategory = ((List<AdsBoardSiteCategory>)ViewBag.Global_AdsBoardSiteCategory).Where(x => x.AdsBoardSiteID == adsSite.ID && x.CategoryID == product.CategoryID).FirstOrDefault();
                string url = adsSite.URL.Replace("#CATEGORY#", adsCategory.URL).Replace("#KEYWORDS#", keyword);


                ViewBag.RedirectUrl = url;


                var track = new AdsBoardSiteTracker();
                track.ProductID = id;
                track.AdsBoardSiteID = adsId;
                // TODO: track.UserID = ???;
                _db.AdsBoardSiteTracker.Add(track);
                _db.SaveChangesAsync();

                ViewBag.Method = "get";
            }

            return View("ShopProductTracker");
        }

        public string ClearCache()
        {
            QueryCacheManager.ExpireAll();

            return "Cache is cleared";
        }


        /// <summary>
        /// Save downloaded image
        /// </summary>
        /// <param name="url">External image url. url starts with http:// or https://</param>
        /// <param name="productID">Product id</param>
        /// <returns></returns>
        [HttpPost]
        public void SaveDownloadedImage(int productID, string url)
        {

            using (WebClient webClient = new WebClient())
            {
                byte[] data = webClient.DownloadData(url);

                using (MemoryStream ms = new MemoryStream(data))
                {
                    using (var img = Image.FromStream(ms))
                    {
                        SaveImage(img, productID);
                    }
                }

            }

        }

        /// <summary>
        /// Uploading image for product
        /// </summary>
        /// <param name="uploadedImage">Uploaded image source</param>
        /// <param name="sourcePath">updated image source path</param>
        [HttpPost]
        public void UploadImage(HttpPostedFileBase uploadedImage, int productID)
        {
            var bigFileName = Server.MapPath(Helper.CreateBigImagePath((int)productID));
            var bigFileDirName = bigFileName.Substring(0, bigFileName.LastIndexOf('\\') + 1);

            var smallFileName = Server.MapPath(Helper.CreateThumbImagePath((int)productID));
            var smallFileDirName = smallFileName.Substring(0, smallFileName.LastIndexOf('\\') + 1);


            Image image = Image.FromStream(uploadedImage.InputStream);
            SaveImage(image, productID);
        }

        /// <summary>
        /// Save Product image
        /// </summary>
        /// <param name="img">uploaded or download external url image</param>
        /// <param name="productID">product id</param>
        private void SaveImage(Image img, int productID)
        {
            var bigFileName = Server.MapPath(Helper.CreateBigImagePath((int)productID));
            var bigFileDirName = bigFileName.Substring(0, bigFileName.LastIndexOf('\\') + 1);

            var smallFileName = Server.MapPath(Helper.CreateThumbImagePath((int)productID));
            var smallFileDirName = smallFileName.Substring(0, smallFileName.LastIndexOf('\\') + 1);

            if (!Directory.Exists(bigFileDirName))
            {
                Directory.CreateDirectory(bigFileDirName);
            }
            img.Save(bigFileName, ImageFormat.Jpeg);

            if (!Directory.Exists(smallFileDirName))
            {
                Directory.CreateDirectory(smallFileDirName);
            }
            img.Save(smallFileName, ImageFormat.Jpeg);
        }

    }
}