using HtmlAgilityPack;
using PA.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace ShopCrawler
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtFrom.Minimum = 0;
            txtTo.Minimum = 0;

            ModelPA db = new ModelPA();

            for (int shopId = 46; shopId <= 46; shopId++)
            {
                if (shopId == 17 || shopId == 33 || shopId == 36 || shopId == 39 || shopId == 43
                    || shopId == 27 /* smartel.az */)
                {
                    continue;
                }
                //int shopId = 1;
                // 17. 33. 36. 39. 43. do not scan

                button1.Text = "ShopId = " + shopId;
                Application.DoEvents();


                DateTime scanDateTime = DateTime.Now;

                var crawlers = db.Crawler.Where(x => x.ShopID == shopId).OrderBy(x => x.OrderNo).ThenBy(x => x.ID).ToList();
                txtTo.Value = crawlers.Count;
                for (int i = 0; i < crawlers.Count; i++)
                {
                    txtFrom.Value = i + 1;
                    Application.DoEvents();

                    if (crawlers[i].UrlXpath == "xml")
                    {
                        using (System.Net.WebClient client = new System.Net.WebClient())
                        {
                            client.DownloadFile(crawlers[i].Url, "46.xml");
                        }

                        var web = new HtmlWeb();
                        var doc = web.Load(Path.Combine(Application.StartupPath, "46.xml"));

                        var nodes = doc.DocumentNode.SelectNodes(crawlers[i].ProductXpath);
                        txtTo.Value = nodes.Count;
                        for (int k = 8750; k < nodes.Count; k++)
                        {
                            txtFrom.Value = k + 1;
                            Application.DoEvents();
                            PACrawler.Crawle(crawlers[i].ShopID, nodes[k].InnerText, crawlers[i].ProductXpath, crawlers[i].TitleXpath
                                , crawlers[i].UrlXpath, crawlers[i].PriceXpath, crawlers[i].IsPriceWithPenny, null, scanDateTime);
                        }
                    }
                    else
                    {
                        PACrawler.Crawle(crawlers[i].ShopID, crawlers[i].Url, crawlers[i].ProductXpath, crawlers[i].TitleXpath
                            , crawlers[i].UrlXpath, crawlers[i].PriceXpath, crawlers[i].IsPriceWithPenny, null, scanDateTime);
                    }
                }

                DateTime dtToRemove = scanDateTime.AddMinutes(-1);
                var toRemove = db.ShopProduct.Where(x => x.ShopID == shopId && x.DeleteDate == null && x.UpdateDate < dtToRemove).ToList();
                toRemove.ForEach(x => x.DeleteDate = scanDateTime);
                db.SaveChanges();
            }

            #region have to crawle

            // 33 orion.az - internet explorer acmir
            // 36 galaxy.az - sehifeleme ajax ile qurulub
            // 39 vipbaby.az - sonraya qalsin


            // 43 micro.az - web pustoy vernulsa
            //PACrawler.Crawle(shopId, "http://micro.az/index.php?route=product/category&path=85&limit=9999"
            //, "//div[contains(@class, 'product-grid')]"
            //, ".//div[contains(@class, 'caption')]/h4/a"
            //, ".//div[contains(@class, 'caption')]/h4/a"
            //, ".//p[contains(@class, 'price')]", false, null);


            // gigatech.az
            //PACrawler.Crawle(shopId, "http://www.gigatech.az/index.php?name=News&op=topicview&new_topic=86&self_topic=0"
            //    , "//table[@width='100%'][@border='0'][@cellspacing='0'][@cellpadding='0']"
            //    , ".//a[contains(@class, 'linkntitle')]"
            //    , ".//a[contains(@class, 'linkntitle')]"
            //    , ".//b", false, null);


            #endregion have to crawle


            #region Crawle Manual

            // 45 controlstore.az
            //PACrawler.Crawle(shopId, "http://controlstore.az/index.php?route=product/category&path=339&limit=9999"
            //, "//div[contains(@class, 'product-layout')]"
            //, ".//div[contains(@class, 'caption')]/h4/a"
            //, ".//div[contains(@class, 'caption')]/h4/a"
            //, ".//span[contains(@class, 'price-regular')]", false, null);



            // 44 almali.az
            //PACrawler.Crawle(shopId, "https://almali.az/index.php?route=product/category&path=275&page=#PAGE#"
            //, "//div[contains(@class, 'product-block')]"
            //, ".//div[contains(@class, 'name')]/a"
            //, ".//div[contains(@class, 'name')]/a"
            //, ".//div[contains(@class, 'price')]", false, null);


            // 42 w-t.az
            //PACrawler.Crawle(shopId, "https://www.w-t.az/c1-mobil-cihazlar?Products_page=#PAGE#"
            //, "//div[contains(@class, 'items')]/div/a"
            //, "./h2"
            //, "."
            //, "./span", false, null);


            // 41 yarpaq.az
            //PACrawler.Crawle(shopId, "https://www.yarpaq.az/ru/computers-and-games/computers/laptops/?page=#PAGE#"
            //, "//div[contains(@class, 'product_result_list')]/article"
            //, ".//a[contains(@itemprop, 'name')]"
            //, ".//a[contains(@itemprop, 'name')]"
            //, ".//span[contains(@itemprop, 'price')]", false, null);


            // 40 hatikoshop.az
            //PACrawler.Crawle(shopId, "http://hatikoshop.az/ru/kompyuternoe-oborudovanie-bakida-almaq/noutbuki-bakida-almaq/?limit=9999"
            //, "//div[@id='boxfeatured']/div"
            //, ".//div[contains(@class, 'name')]/a"
            //, ".//div[contains(@class, 'name')]/a"
            //, ".//div[contains(@class, 'price')]", false, null);


            // 38 yarmarka.az
            //PACrawler.Crawle(shopId, "http://yarmarka.az/index.php?page=shop.browse&category_id=51&option=com_virtuemart&Itemid=100001&lang=ru&limit=9999"
            //, "//div[@id='product_list']/div"
            //, ".//h2/a"
            //, ".//h2/a"
            //, ".//span[contains(@class, 'productPrice')]", false, null);


            // 37 bestshop.az
            //PACrawler.Crawle(shopId, "http://bestshop.az/ru/kupit-kompyuternaya-tehnika/kupit-noutbuki/?limit=9999"
            //, "//div[@id='boxfeatured']/div"
            //, ".//div[contains(@class, 'name')]/a"
            //, ".//div[contains(@class, 'name')]/a"
            //, ".//div[contains(@class, 'price')]/span[contains(@class, 'price-new')]", false, null);


            // 35 technostore.az
            //PACrawler.Crawle(shopId, "https://www.technostore.az/lang/ru/telefonyi-i-svyaz/smartfoni?page=#PAGE#"
            //, "//div[contains(@class, 'products')]/ul/li"
            //, ".//div[contains(@class, 'product-title')]"
            //, ".//div[contains(@class, 'product-actions')]/a"
            //, ".//div[contains(@class, 'product-price')]", false, null);


            // 34 tesko.az
            //PACrawler.Crawle(shopId, "http://tesko.az/index.php?route=product/category&path=60_61&limit=2000"
            //, "//div[contains(@class, 'product-list')]/div"
            //, ".//div[contains(@class, 'name')]/a"
            //, ".//div[contains(@class, 'name')]/a"
            //, ".//div[contains(@class, 'price')]", false, null);


            // 32 giftshop.az
            //PACrawler.Crawle(shopId, "http://giftshop.az/index.php?id_category=345&controller=category&id_lang=4&n=2000"
            //, "//ul[@id='product_list']/li"
            //, ".//h3/a"
            //, ".//h3/a"
            //, ".//span[contains(@class, 'price')]", false, null);


            // 31 onlinepc.az
            //PACrawler.Crawle(shopId, "http://onlinepc.az/19-laptoplar?n=60&p=#PAGE#"
            //, "//ul[contains(@class, 'product_list')]/li"
            //, ".//a[contains(@class, 'product-name')]"
            //, ".//a[contains(@class, 'product-name')]"
            //, ".//span[contains(@class, 'price')]", false, null);


            // 30 compus.az
            //PACrawler.Crawle(shopId, "http://compus.az/index.php?route=product/category&path=18&limit=2000"
            //, "//div[contains(@class, 'product-grid')]/div"
            //, ".//div[contains(@class, 'name')]/a"
            //, ".//div[contains(@class, 'name')]/a"
            //, ".//div[contains(@class, 'price')]/span[contains(@class, 'price-new')]", false, null);


            // 29 nix.az
            //PACrawler.Crawle(shopId, "http://nix.az/ru/kupit-kompyuternaya-tehnika/kupit-monobloki-i-pk/?limit=2000"
            //, "//div[contains(@class, 'product-grid')]/div[contains(@class, 'item')]"
            //, ".//div[contains(@class, 'name')]/a"
            //, ".//div[contains(@class, 'name')]/a"
            //, ".//div[contains(@class, 'price')]/span[contains(@class, 'price-new')]", false, null);


            // 28 mycomp.az
            //PACrawler.Crawle(shopId, "http://mycomp.az/index.php?categoryID=564&offset=#PAGE#"
            //, "//div[contains(@class, 'cpt_maincontent')]/center/table/tr"
            //, ".//div[contains(@class, 'prdbrief_name')]/a"
            //, ".//div[contains(@class, 'prdbrief_name')]/a"
            //, ".//div[contains(@class, 'prdbrief_price')]/span", false, null);


            // 27 smartel.az
            //PACrawler.Crawle(shopId, "http://www.smartel.az/shop/category/tv-ve-audio/televizorlar?user_per_page=2000"
            //, "//div[@id='items-catalog-main']/div[contains(@class, 'catalog-item')]"
            //, ".//span[contains(@class, 'title')]"
            //, ".//a[contains(@class, 'frame-photo-title')]"
            //, ".//span[contains(@class, 'price-new')]", false, null);


            // 26 amazoncomp.az
            //PACrawler.Crawle(shopId, "http://www.amazoncomp.az/ru/category/LCD_Display?limit=2000"
            //, "//div[@id='product_list']/div[contains(@class, 'non_slider_prod_list')]/ul/li"
            //, ".//div/div/div/a"
            //, ".//div/div/div/a"
            //, ".//p[contains(@class, 'big_price')]", false, null);


            // 25 aem-elektron.az
            //PACrawler.Crawle(shopId, "http://aem-elektron.az/sebeke-avadanliqi/?limit=10000"
            //, "//div[@id='content']/div[contains(@class, 'product-grid')]/div"
            //, ".//div[contains(@class, 'name')]/a"
            //, ".//div[contains(@class, 'name')]/a"
            //, ".//div[contains(@class, 'price')]", false, null);


            // 24 telecom.az
            //PACrawler.Crawle(shopId, "http://telecom.az/category/item/telefonlar.html?page=#PAGE#"
            //, "//div[contains(@class, 'nav_panel_right')]/div[contains(@class, 'data_filtr')]/a"
            //, ".//div[contains(@class, 'item_phone')]/div[contains(@class, 'item_top')]/h2"
            //, "."
            //, ".//button[contains(@class, 'item_btn_danger')]", false, null);


            // 23 soliton.az
            //PACrawler.Crawle(shopId, "http://www.soliton.az/mobile/mobile/"
            //, "//div[@id='productList']/div[contains(@class, 'item')]"
            //, ".//a/strong"
            //, ".//a"
            //, "./strong", false, null);


            // 22 maxi.az
            //PACrawler.Crawle(shopId, "https://maxi.az/ru/telefonlar-ve-plansetler/telefonlar/smartfonlar/?PAGEN_100=#PAGE#"
            //    , "//div[contains(@class, 'cont-cat-in')]/div[contains(@class, 'one-cat-item')]"
            //    , ".//div[contains(@class, 'one-cat-item-tit')]/a"
            //    , ".//div[contains(@class, 'one-cat-item-tit')]/a"
            //    , ".//div[contains(@class, 'news-slid-price')]", false, null);


            // 21 notecomp.az
            //PACrawler.Crawle(shopId, "http://www.notecomp.az/ru/all/86-#PAGE#.html"
            //    , "//div[@id='goods-list']/table/tr"
            //    , ".//td/a/b"
            //    , ".//td/a"
            //    , ".//span[contains(@class, 'priceX')]", false, null);


            // 20 photohouse.az
            //PACrawler.Crawle(shopId, "http://www.photohouse.az/accessories/"
            //    , "//ul[@class='box clearfix']/li"
            //    , ".//section/span"
            //    , ".//div[contains(@class, 'price')]/a"
            //    , ".//div[contains(@class, 'price')]/a", false, null);


            // 19 ncp.az
            //PACrawler.Crawle(shopId, "http://ncp.az/catalog/qulaq__q_v__mikrofonlar/?show=3000&view=squares"
            //    , "//ul[contains(@class, 'productList')]/li[contains(@class, 'product')]"
            //    , ".//a[contains(@class, 'name')]"
            //    , ".//a[contains(@class, 'name')]"
            //    , ".//span[contains(@class, 'price')]", false, null);


            // arshinmalalan.az
            //PACrawler.Crawle(shopId, "https://arshinmalalan.az/ru/category/10/noutbuki/"
            //    , "//ul[@id='product-grid']/li"
            //    , ".//div[contains(@class, 'StyleNumber')]/a/p/span"
            //    , ".//div[contains(@class, 'blog-post')]/div/a"
            //    , ".//span[contains(@itemprop, 'lowPrice')]", false, null);


            // unitech.az
            //PACrawler.Crawle(shopId, "http://www.unitech.az/phones/page,#PAGE#"
            //    , "//div[contains(@class, 'products_outer')]"
            //    , ".//p[contains(@class, 'products_title')]"
            //    , ".//a[contains(@class, 'products_more')]"
            //    , ".//p[contains(@class, 'products_price_active')]", false, null);


            // bakinity.biz
            //PACrawler.Crawle(shopId, "http://electro.az/index.php?route=product/category&path=24&page=#PAGE#"
            //    , "//li[contains(@class, 'ui-item')]"
            //    , ".//div[contains(@class, 'title')]/a"
            //    , ".//div[contains(@class, 'title')]/a"
            //    , ".//p[contains(@class, 'price')]", false, null);


            // bakinity.biz
            //PACrawler.Crawle(shopId, "http://laptopmarket.az/category/230/0/#PAGE#"
            //    , "//div[contains(@class, 'pro_in0')]/div[contains(@class, 'prods')]"
            //    , ".//div[contains(@class, 'prodText')]/a/b"
            //    , ".//div[contains(@class, 'prodText')]/a"
            //    , ".//div[contains(@class, 'prodPrice')]", false, null);


            // bakinity.biz
            //PACrawler.Crawle(shopId, "http://www.bakinity.biz/catalog/computer_hardware/?view=squares&show=60&PAGEN_1=#PAGE#&SIZEN_1=20"
            //    , "//ul[contains(@class, 'productList')]/li[contains(@class, 'product')]"
            //    , ".//a[contains(@class, 'name')]"
            //    , ".//a[contains(@class, 'name')]"
            //    , ".//span[contains(@class, 'price')]", false, null);


            // bestel.az
            //PACrawler.Crawle(shopId, "https://bestel.az/category/86/noutbuklar?page=#PAGE#"
            //    , "//div[contains(@class, 'product-item')]"
            //    , ".//h3/a"
            //    , ".//h3/a"
            //    , ".//div[contains(@class, 'pi-price')]", false, null);


            // telecom.nlt.az
            //PACrawler.Crawle(shopId, "http://telecom.nlt.az/Products/1?&page=#PAGE#"
            //    , "//div[contains(@class, 'container')]/div[contains(@class, 'products')]/div[contains(@class, 'product')]"
            //    , ".//div[contains(@class,'header')]/h3"
            //    , ".//div[contains(@class,'image')]/span/a"
            //    , ".//price", false, null);


            // compstore.az
            //PACrawler.Crawle(shopId, "https://compstore.az/gaming-zona/#PAGE#/"
            //    , "//div[contains(@class, 'cat-short-box')]"
            //    , ".//div[contains(@class,'cat-short-name')]/span/a/h3"
            //    , ".//div[contains(@class,'cat-short-name')]/span/a"
            //    , ".//span[contains(@class,'price')]", false, null);

            // impuls.az
            //PACrawler.Crawle(shopId, "http://impuls.az/index.php?route=product/category&path=95&limit=100&page=#PAGE#"
            //    , "//div[@id='content']/div[contains(@class, 'row')]/div[contains(@class, 'product-layout')]"
            //    , ".//div[contains(@class,'name-product')]/a"
            //    , ".//div[contains(@class,'name-product')]/a"
            //    , ".//div[contains(@class,'price-product')]", false, null);


            // dosttech.az
            //PACrawler.Crawle(shopId, "http://dosttech.az/az/category/14-mobil-telefon?page=#PAGE#"
            //    , "//div[@id='grid']/ul[contains(@class, 'products')]/li[contains(@class, 'product')]"
            //    , ".//div[contains(@class,'product-inner')]/a/h3"
            //    , ".//div[contains(@class,'product-inner')]/a"
            //    , ".//div[contains(@class,'price-add-to-cart')]/span", false, null);


            // irtelecom.az
            //PACrawler.Crawle(6, "http://www.bakuelectronics.az/index.php?l=product_list&c=30&sortby=price:asc&pg=#PAGE#"
            //    , "//div[contains(@class, 'list_item')]"
            //    , ".//a[contains(@class,'product_title_link')]"
            //    , ".//a[contains(@class,'product_title_link')]"
            //    , ".//span[contains(@class,'price')]", false, null);

            // irtelecom.az
            // Mobil telefonlar -> Smartphones
            //PACrawler.Crawle(5, 122, "https://irtelecom.az/catalog/index/1"
            //    , "//div[contains(@class, 'offer_inner_product')]"
            //    , ".//div[@class='feat_product_box_title']/a"
            //    , ".//div[@class='feat_product_box_title']/a"
            //    , ".//div[@class='feat_product_box_price']/span[@class='price_base']/span[@class='manat_price_value']", false, null);


            // Kontakt.az
            // Mobil telefonlar
            //////PACrawler.Crawle(1, 122, "https://kontakt.az/category/telefonlar/mobil-telefonlar/page/#PAGE#/"
            //////    , "//div[contains(@class, 'product-info')]"
            //////    , ".//h5/a"
            //////    , ".//h5/a"
            //////    , ".//span[contains(@class,'price')]/strong/span", true);

            // Planşetlər
            //////PACrawler.Crawle(1, 30, "https://kontakt.az/category/plansetler/page/#PAGE#/"
            //////    , "//div[contains(@class, 'product-info')]"
            //////    , ".//h5/a"
            //////    , ".//h5/a"
            //////    , ".//span[contains(@class,'price')]/strong/span", true);


            // Televizor
            //////PACrawler.Crawle(1, 160, "https://kontakt.az/category/audio-video/televizor/page/#PAGE#/"
            //////    , "//div[contains(@class, 'product-info')]"
            //////    , ".//h5/a"
            //////    , ".//h5/a"
            //////    , ".//span[contains(@class,'price')]/strong/span", true);





            // mgstore.az
            // Mobil telefonlar -> Smartphones
            //////PACrawler.Crawle(2, 122, "https://mgstore.az/ru/shop/telefony-i-svyaz-7/smartfony-mobilnye-telefony-466/smartfony-777/#PAGE#?perPage=24&order=0&available=1"
            //////    , "//div[contains(@class, 'product-inner')]"
            //////    , ".//a/h3"
            //////    , ".//a"
            //////    , ".//span[contains(@class,'amount')]", false);


            // optimal.az
            // Mobil telefonlar -> Smartphones
            //////PACrawler.Crawle(3, 122, "https://optimal.az/az/category-66-Mobil+telefonlar?page=#PAGE#&per-page=16&sort_price=asc"
            //////    , "//div[contains(@class, 'p-div')]"
            //////    , ".//a/div[@class='p-title']"
            //////    , ".//a"
            //////    , ".//div[@class='p-price-div']/div/div", false);


            // integral.az
            // Mobil telefonlar -> Smartphones
            //PACrawler.Crawle(4, 122, "http://www.integral.az/catalog/list.php?SECTION_ID=1779&PAGEN_3=#PAGE#"
            //    , "//li[contains(@class, 'product-item')]"
            //    , ".//div[@class='title']"
            //    , ".//div[@class='detail']/a"
            //    , ".//div[@class='price']", false);

            #endregion Crawle Manual


            MessageBox.Show("SCAN is DONE");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PACrawler c = new PACrawler();
            c.Crawle("http://m.ua/m1_item.php?idg_=#ID#&view_=desc&full_=1", txtFrom, txtTo, txtDirection);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NormilizeScannedProduct();
        }


        private void NormilizeScannedProduct()
        {
            ModelPA db = new ModelPA();

            var brands = db.Brand.ToList();
            var categories = db.Category.ToList();
            var categoriesT = db.CategoryTranslate.Where(x => x.LanguageID == 2).ToList();
            var prefixes = db.ProductNamePrefix.ToList();
            var prefixesT = db.ProductNamePrefixTranslate.Where(x => x.LanguageID == 2).ToList();

            var properties = db.Property.ToList();
            var propertiesT = db.PropertyTranslate.Where(x => x.LanguageID == 2).ToList();


            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            var prods = new List<ScannedProductPAM>();

            while (true)
            {
                Application.DoEvents();

                try
                {
                    prods.Clear();
                    prods = db.ScannedProductPAM.Where(x => x.BrandID == null && x.Name == null).OrderByDescending(x => x.ID).Take(1000).ToList();
                }
                catch { continue; }

                if (prods.Count == 0)
                {
                    break;
                }


                foreach (ScannedProductPAM prod in prods)
                {
                    doc.LoadHtml(prod.Content);

                    if (doc.DocumentNode.Descendants("title").SingleOrDefault().InnerText.Contains("Товар не найден"))
                    {
                        prod.FullName = prod.Name = "NotFound";
                        continue;
                    }

                    string title = doc.DocumentNode.SelectSingleNode("//div[@id='top-page-title']/h1").InnerText.Trim();
                    var breadcrumbs = doc.DocumentNode.SelectNodes("//div[@id='top-page-title']/div[@class='breadcrumbs']/div/a/span");

                    string brandName = breadcrumbs[breadcrumbs.Count - 1].InnerText.Trim();

                    if (title.StartsWith(brandName))
                    {
                        prod.FullName = prod.Name = "ScanLater";
                        continue;
                    }

                    if (breadcrumbs.Count == 1)
                    {
                        prod.FullName = prod.Name = "NoBrand";
                        continue;
                    }

                    string categoryName = breadcrumbs[breadcrumbs.Count - 2].InnerText.Trim();




                    #region Category

                    var category = categoriesT.FirstOrDefault(x => x.Name.ToLower() == categoryName.ToLower());

                    if (category == null)
                    {
                        prod.FullName = prod.Name = "NoCategory";
                        continue;
                    }

                    prod.CategoryID = category.CategoryID;

                    #endregion Category


                    prod.FullName = title;
                    prod.Brand = brandName;
                    prod.Category = categoryName;
                    prod.Prefix = title.Substring(0, title.IndexOf(brandName) - 1);
                    try
                    {
                        prod.Name = title.Substring(title.IndexOf(brandName) + brandName.Length + 1);
                    }
                    catch { prod.Name = " "; }

                    #region Brand

                    var brand = brands.FirstOrDefault(x => x.Name.ToLower() == brandName.ToLower());
                    if (brand == null)
                    {
                        brand = new Brand()
                        {
                            Name = brandName,
                            OrderNo = 9999999
                        };
                        db.Brand.Add(brand);
                        db.SaveChanges();
                        brands = db.Brand.ToList();
                    }

                    prod.BrandID = brand.ID;

                    #endregion Brand

                    #region Prefix

                    var prefix = prefixesT.FirstOrDefault(x => x.Name.ToLower() == prod.Prefix.ToLower());
                    if (prefix == null)
                    {
                        var newPrefix = new ProductNamePrefix();
                        db.ProductNamePrefix.Add(newPrefix);
                        db.SaveChanges();

                        db.ProductNamePrefixTranslate.Add(new ProductNamePrefixTranslate()
                        {
                            LanguageID = 1,
                            Name = prod.Prefix,
                            PrefixID = newPrefix.ID
                        });

                        prefix = new ProductNamePrefixTranslate()
                        {
                            LanguageID = 2,
                            Name = prod.Prefix,
                            PrefixID = newPrefix.ID
                        };

                        db.ProductNamePrefixTranslate.Add(prefix);
                        db.SaveChanges();
                        prefixes = db.ProductNamePrefix.ToList();
                        prefixesT = db.ProductNamePrefixTranslate.Where(x => x.LanguageID == 2).ToList();
                    }

                    prod.PrefixID = prefix.PrefixID;

                    #endregion Prefix


                    #region Property
                    /*
                    List<ProductProperty> productProperties = new List<ProductProperty>();
                    List<PropertyTranslate> productPropertiesT = new List<PropertyTranslate>();
                    List<ProductPropertyValue> productPropertyValues = new List<ProductPropertyValue>();
                    List<ProductPropertyValueTranslate> productPropertyValuesT = new List<ProductPropertyValueTranslate>();

                    var props = doc.DocumentNode.SelectNodes("//div[@id='full_descr_block']/table/tbody/tr/td");
                    foreach (HtmlNode prop in props)
                    {
                        var pp = prop.SelectNodes(".//table/tbody/tr/td");

                        string PropertyName = pp[0].InnerText.Trim();

                        var property = propertiesT.FirstOrDefault(x=>x.Name == PropertyName);
                        if (property != null)
                        {
                            var newProperty = new Property()
                        }

                        var newProductProperty = new ProductProperty();
                        var newPropertyT1 = new PropertyTranslate();
                        var newPropertyT2 = new PropertyTranslate();
                        newProductProperty.ProductID = prod.ID;

                        newPropertyT1.Property = newProperty;
                        newPropertyT1.Name = pp[0].InnerText.Trim();


                        if (newPropertyT1.Name == "Цвет")
                        {
                            var ppp = pp[1].SelectNodes(".//div");
                            foreach (var pv in ppp)
                            {
                                var pvName = pv.Attributes["title"];
                            }
                        }
                        else
                        {

                        }


                    }
                    */
                    #endregion Property
                }

                db.SaveChanges();
            }

            MessageBox.Show("NormilizeScannedProduct is DONE");


        }

        private void button4_Click(object sender, EventArgs e)
        {
            NormilizeScannedProductProperties();
        }

        private void NormilizeScannedProductProperties()
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ModelPA"].ConnectionString);
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;
            conn.Open();

            string NL = System.Environment.NewLine;
            StringBuilder cmd = new StringBuilder();

            ModelPA dbX = new ModelPA();
            dbX.Database.Connection.Open();

            var propertyGroupsDic = dbX.PropertyGroupTranslate.AsNoTracking().Where(x => x.LanguageID == 2).Select(x => new { x.GroupID, x.Name }).ToList()
                .ToDictionary(x => x.Name.ToLower(), x => x.GroupID);

            var propertiesDic = dbX.PropertyTranslate.AsNoTracking().Where(x => x.LanguageID == 2).Select(x => new { x.PropertyID, x.Name }).ToList()
                .ToDictionary(x => x.Name.ToLower(), x => x.PropertyID);

            var propertyValuesDic = dbX.PropertyValueTranslate.AsNoTracking().Where(x => x.LanguageID == 2).Select(x => new { x.ValueID, x.Name }).ToList()
                .ToDictionary(x => x.Name.Replace('³', '3').Replace('²', '2').Replace(((char)8206).ToString(), "")
                    .Replace("°", " гр").ToLower(), x => x.ValueID);


            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            while (true)
            {
                Application.DoEvents();

                dbX = new ModelPA();
                dbX.Database.Connection.Open();

                List<ViewScannedProduct> scannedProducts;
                try
                {
                    scannedProducts = dbX.ViewScannedProduct.AsNoTracking().Take(100).ToList();
                }
                catch { continue; }

                if (scannedProducts.Count == 0)
                {
                    break;
                }

                cmd.Clear();
                cmd.Append("Begin transaction" + NL + "Declare @id int" + NL);

                for (int j = 0; j < scannedProducts.Count; j++)
                {
                    cmd.Append(NL + "Update ScannedProductPAM Set IsPropertyScanned = 1 Where ID = " + scannedProducts[j].MID + NL + NL);

                    Application.DoEvents();
                    doc.LoadHtml(scannedProducts[j].content);


                    #region Property

                    var newProductProperties = new List<ProductProperty>();
                    var newProductPropertiesT = new List<PropertyTranslate>();
                    var newProductPropertyValues = new List<PropertyValue>();
                    var newProductPropertyValuesT = new List<PropertyValueTranslate>();


                    var tables = doc.DocumentNode.SelectNodes("//div[@id='full_descr_block']/table/tr/td");
                    if (tables == null)
                    {
                        tables = doc.DocumentNode.SelectNodes("//div[@id='full_descr_block']/div[contains(@class,'short-desc')]");
                        if (tables == null)
                        {
                            continue;
                        }
                    }

                    long productID = scannedProducts[j].ID;

                    int? activeGroup = null;

                    List<long> productPropertyRepeat = new List<long>();

                    for (int i = 0; i < tables.Count; i++)
                    {
                        var rows = tables[i].SelectNodes(".//table/tr");

                        if (rows == null)
                        {
                            continue;
                        }

                        foreach (HtmlNode row in rows)
                        {

                            var columns = row.SelectNodes(".//td");

                            string propertyName = columns[0].InnerText.Trim();
                            string propertyNameL = propertyName.ToLower();

                            if (string.IsNullOrEmpty(propertyName) || propertyName == "Цвет")
                            {
                                continue;
                            }



                            #region property group

                            if (columns.Count == 1) // this is a group
                            {
                                //var propertyGroup = propertyGroupsT.FirstOrDefault(x => x.Name.ToLower() == propertyName.ToLower());
                                //if (propertyGroup == null)

                                int groupId;

                                if (!propertyGroupsDic.TryGetValue(propertyNameL, out groupId))
                                {
                                    var newPropertyGroup = new PropertyGroup()
                                    {
                                        OrderNo = 999999999,
                                    };
                                    dbX.PropertyGroup.Add(newPropertyGroup);

                                    var newPropertyGroupT1 = new PropertyGroupTranslate()
                                    {
                                        PropertyGroup = newPropertyGroup,
                                        LanguageID = 1,
                                        Name = propertyName
                                    };
                                    dbX.PropertyGroupTranslate.Add(newPropertyGroupT1);

                                    var newPropertyGroupT2 = new PropertyGroupTranslate()
                                    {
                                        PropertyGroup = newPropertyGroup,
                                        LanguageID = 2,
                                        Name = propertyName
                                    };
                                    dbX.PropertyGroupTranslate.Add(newPropertyGroupT2);
                                    dbX.SaveChanges();

                                    groupId = newPropertyGroup.ID;
                                    propertyGroupsDic.Add(propertyNameL, groupId);
                                }

                                activeGroup = groupId;

                                continue;
                            }

                            #endregion property group




                            #region Property

                            //List<int> propertyIDs = properties.Select(x => x.ID).ToList();
                            //PropertyTranslate property = propertiesT.FirstOrDefault(x => propertyIDs.Contains(x.PropertyID) && x.Name == propertyName);
                            //PropertyTranslate property = propertiesT.FirstOrDefault(x => x.Name.ToLower() == propertyName.ToLower());

                            int propertyId;

                            if (!propertiesDic.TryGetValue(propertyNameL, out propertyId))
                            {
                                var newProperty = new Property()
                                {
                                    ValueTypeID = 1,
                                    OrderNo = 999999999,
                                };
                                dbX.Property.Add(newProperty);

                                var newPropertyT1 = new PropertyTranslate()
                                {
                                    Property = newProperty,
                                    LanguageID = 1,
                                    Name = propertyName
                                };
                                dbX.PropertyTranslate.Add(newPropertyT1);

                                var newPropertyT2 = new PropertyTranslate()
                                {
                                    Property = newProperty,
                                    LanguageID = 2,
                                    Name = propertyName
                                };
                                dbX.PropertyTranslate.Add(newPropertyT2);

                                dbX.SaveChanges();


                                propertyId = newProperty.ID;

                                propertiesDic.Add(propertyNameL, propertyId);
                                //properties.Add(newProperty);
                                //propertiesT.Add(property);
                            }

                            #endregion Property




                            #region ProductProperty
                            long ll = (activeGroup ?? 0) + propertyId + productID;
                            if (productPropertyRepeat.Contains(ll))
                            {
                                continue;
                            }
                            else
                            {
                                cmd.Append("Insert into ProductProperty (GroupID, ProductID, PropertyID) Select "
                                    + (activeGroup == null ? "NULL" : activeGroup.ToString())
                                    + ", " + productID + ", " + propertyId + NL
                                    + "set @id = Scope_Identity()" + NL);
                                productPropertyRepeat.Add(ll);
                            }

                            #endregion ProductProperty




                            #region Property Values

                            columns[1].InnerHtml = columns[1].InnerHtml.Replace("<br>", ((char)3).ToString());
                            string[] values = columns[1].InnerText.Replace("&nbsp;", " ").Split((char)3);

                            if (!(values.Length == 1 && values[0] == ""))
                            {
                                for (int k = 0; k < values.Length; k++)
                                {
                                    if (values[k] == "")
                                    {
                                        continue;
                                    }

                                    string propertyValueName = values[k].Replace("�", "").Replace("  ", " ").Replace("?", "").Trim();
                                    string propertyValueNameL = propertyValueName.Replace('³', '3').Replace('²', '2')
                                        .Replace(((char)8206).ToString(), "")
                                        .Replace("°", " гр").ToLower();
                                    //string sss = propertyValuesDic.First(x => x.Value == 39609).Key;

                                    int propertyValueId;
                                    if (!propertyValuesDic.TryGetValue(propertyValueNameL, out propertyValueId))
                                    {
                                        var newPropertyValue = new PropertyValue()
                                        {
                                            OrderNo = 999999999,
                                        };
                                        dbX.PropertyValue.Add(newPropertyValue);

                                        var newPropertyValueT1 = new PropertyValueTranslate()
                                        {
                                            PropertyValue = newPropertyValue,
                                            LanguageID = 1,
                                            Name = propertyValueName
                                        };
                                        dbX.PropertyValueTranslate.Add(newPropertyValueT1);

                                        var newPropertyValueT2 = new PropertyValueTranslate()
                                        {
                                            PropertyValue = newPropertyValue,
                                            LanguageID = 2,
                                            Name = propertyValueName
                                        };
                                        dbX.PropertyValueTranslate.Add(newPropertyValueT2);

                                        dbX.SaveChanges();

                                        propertyValueId = newPropertyValue.ID;
                                        propertyValuesDic.Add(propertyValueNameL, propertyValueId);
                                        //propertyValues.Add(newPropertyValue);
                                        //propertyValuesT.Add(propertyValue);
                                    }





                                    #region ProductPropertyValue

                                    cmd.Append("Insert into ProductPropertyValue (ProductPropertyID, ValueID) Select @id, "
                                        + propertyValueId + NL);

                                    #endregion ProductPropertyValue




                                }

                            }

                            #endregion Property Values



                        }

                    }

                    cmd.Append(NL + NL + NL);

                    #endregion Property
                }


                cmd.Append("commit");

                comm.CommandText = cmd.ToString();

                comm.ExecuteNonQuery();
            }

            conn.Close();
            MessageBox.Show("NormilizeScannedProduct is DONE");


        }

        private void btnScanImages_Click(object sender, EventArgs e)
        {
            // generate foldes array
            var folders = new List<string>();


            // disable smartel.az
            for (int i = 0; i < 1000000; i++)
            {
                string s = System.IO.Path.GetRandomFileName().Substring(0, 2);
                if (!folders.Contains(s))
                {
                    folders.Add(s);
                }

                if (folders.Count == 1024)
                {
                    break;
                }
            }

            folders.Sort(StringComparer.Create(new CultureInfo("en-US"), true));


            var db = new ModelPA();
            var IDs = db.ShopProduct.Select(x => new { x.Product.ID, x.Product.MID }).ToList();

            var folder = @"D:\MUA_IMAGES\";

            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                for (int i = 0; i < IDs.Count; i++)
                {
                    int folderId = (int)(IDs[i].ID / 1024);
                    if (folderId > 1023)
                    {
                        folderId = (int)(folderId / 1024);
                    }

                    if (File.Exists(Path.Combine(folder, "s", folders[folderId], IDs[i].ID + ".jpg")))
                    {
                        continue;
                    }

                    if (!Directory.Exists(folder + "s\\" + folders[folderId]))
                    {
                        Directory.CreateDirectory(folder + "s\\" + folders[folderId]);
                        Directory.CreateDirectory(folder + "b\\" + folders[folderId]);
                    }

                    if (!Directory.Exists(folder + "new"))
                    {
                        Directory.CreateDirectory(folder + "new");
                    }

                    if (!Directory.Exists(folder + "new\\s\\" + folders[folderId]))
                    {
                        Directory.CreateDirectory(folder + "new\\s\\" + folders[folderId]);
                        Directory.CreateDirectory(folder + "new\\b\\" + folders[folderId]);
                    }

                    try
                    {
                        client.DownloadFile(new Uri("http://m.ua/jpg/" + IDs[i].MID + ".jpg")
                            , Path.Combine(folder, "s", folders[folderId], IDs[i].ID + ".jpg"));
                        client.DownloadFile(new Uri("http://m.ua/jpg_zoom1/" + IDs[i].MID + ".jpg")
                            , Path.Combine(folder, "b", folders[folderId], IDs[i].ID + ".jpg"));

                        File.Copy(Path.Combine(folder, "s", folders[folderId], IDs[i].ID + ".jpg")
                            , Path.Combine(folder, "new\\s", folders[folderId], IDs[i].ID + ".jpg"));
                        File.Copy(Path.Combine(folder, "b", folders[folderId], IDs[i].ID + ".jpg")
                            , Path.Combine(folder, "new\\b", folders[folderId], IDs[i].ID + ".jpg"));
                    }
                    catch
                    {

                    }
                }
            }

            MessageBox.Show("Images Scan is DONE");
        }

        private void btnScanMoreImages_Click(object sender, EventArgs e)
        {
            var db = new ModelPA();
            var IDs = db.ShopProduct.Select(x => new { x.Product.ID, x.Product.MID }).ToList();

            var folder = @"D:\MUA_IMAGES\o\";

            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                for (int i = 0; i < IDs.Count; i++)
                {
                    if (System.IO.File.Exists(folder + IDs[i].ID + ".jpg"))
                    {
                        continue;
                    }

                    //int folderId = (int)(IDs[i].ID / 1024);
                    //if (!System.IO.Directory.Exists(folder + "s\\" + folders[folderId]))
                    //{
                    //    System.IO.Directory.CreateDirectory(folder + "s\\" + folders[folderId]);
                    //    System.IO.Directory.CreateDirectory(folder + "b\\" + folders[folderId]);
                    //}

                    //try
                    //{
                    //    client.DownloadFile(new Uri("http://m.ua/jpg/" + IDs[i].MID + ".jpg")
                    //        , System.IO.Path.Combine(folder, "s", folders[folderId], IDs[i].ID + ".jpg"));
                    //    client.DownloadFile(new Uri("http://m.ua/jpg_zoom1/" + IDs[i].MID + ".jpg")
                    //        , System.IO.Path.Combine(folder, "b", folders[folderId], IDs[i].ID + ".jpg"));
                    //}
                    //catch
                    //{

                    //}

                    string json = client.DownloadString("http://m.ua/mtools/mui_get_img_gallery.php?idg_=1000000&f_type_=IMG");
                    var jj = Newtonsoft.Json.JsonConvert.DeserializeObject<myJson>(json.Substring(1, json.Length - 2));

                    foreach (var item in jj.pp_images)
                    {

                    }
                    //var def = new { pp_images = new myJson() };
                    //var jj = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(json.Substring(1, json.Length - 2), myJson);

                    //dynamic jjj = Newtonsoft.Json.JsonConvert.DeserializeObject(jj.pp_images.ToString());
                }
            }

            MessageBox.Show("ScanMoreImages is DONE");
        }

        private void btnScanMuaDefaultProperties_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ModelPA"].ConnectionString);
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;
            conn.Open();

            string NL = System.Environment.NewLine;
            StringBuilder cmd = new StringBuilder();


            var db = new ModelPA();

            long from;
            if (db.ProductDefaultProperty.Where(x => x.MID <= txtTo.Value).Count() == 0)
            {
                from = (long)txtFrom.Value;
            }
            else
            {
                from = db.ProductDefaultProperty.Where(x => x.MID <= txtTo.Value).Max(x => x.MID) + 1;
            }

            if (from < (long)txtFrom.Value)
            {
                from = (long)txtFrom.Value;
            }

            var properties = db.PropertyTranslate.AsNoTracking().Where(x => x.LanguageID == 2).Select(x => new { ID = x.PropertyID, Name = x.Name.ToLower() }).ToList();
            //var defaultIDs = db.ProductDefaultProperty.AsNoTracking().Select(x => x.ProductID).Distinct().ToList();

            string url = "http://m.ua/mtools/mui_item_description_v2.php?idg_={0}&mode_=short";
            var web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36";

            bool isSave = true;

            cmd.Append("Begin transaction\n");

            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                for (long productID = from; productID <= txtTo.Value; productID++)
                {
                    //if (defaultIDs.Contains(productID))
                    //{
                    //    continue;
                    //}

                    txtFrom.Value = productID;
                    Application.DoEvents();

                    if (productID % 100 == 0)
                    {
                        isSave = true;
                    }

                    string requestUrl = string.Format(url, productID);
                    HtmlAgilityPack.HtmlDocument doc = web.Load(requestUrl);
                    //string json = client.DownloadString(string.Format(url, i));
                    //MessageBox.Show(json);

                    //doc.DocumentNode.InnerHtml = doc.DocumentNode.InnerHtml.Replace("\\'", "").Replace("\\\"", "");
                    var nodes = doc.DocumentNode.SelectNodes("//td[contains(@class, 'prop')]");
                    if (nodes == null)
                    {
                        continue;
                    }

                    for (int j = 0; j < nodes.Count; j++)
                    {
                        string propertyName = nodes[j].InnerText.ToLower();
                        if (propertyName == "цвет")
                        {
                            continue;
                        }

                        var property = properties.FirstOrDefault(x => x.Name == propertyName);

                        if (property == null)
                        {
                            continue;
                        }

                        //var defaultProperty = new ProductDefaultProperty()
                        //{
                        //    ProductID = i,
                        //    PropertyID = property.ID
                        //};

                        //db.ProductDefaultProperty.Add(defaultProperty);

                        cmd.Append(string.Format("INSERT INTO dbo.ProductDefaultProperty (MID, PropertyID) Select {0}, {1} \n", productID, property.ID));

                    }

                    //db.SaveChanges();

                    if (isSave)
                    {
                        cmd.Append("commit");
                        comm.CommandText = cmd.ToString();
                        comm.ExecuteNonQuery();

                        isSave = false;
                        cmd.Clear();
                        cmd.Append("Begin transaction\n");
                    }
                }
            }

            if (cmd.ToString() != "")
            {
                cmd.Append("commit");
                comm.CommandText = cmd.ToString();
                comm.ExecuteNonQuery();
            }

            conn.Close();
            MessageBox.Show("Scan Default Properties is DONE");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnScanMuaDefaultPropertiesFull_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ModelPA"].ConnectionString);
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;
            conn.Open();

            string NL = System.Environment.NewLine;
            StringBuilder cmd = new StringBuilder();


            var db = new ModelPA();

            //long from = db.ProductDefaultProperty.Where(x => x.MID <= txtTo.Value).Max(x => x.MID) + 1;

            //if (from < (long)txtFrom.Value)
            //{
            //    from = (long)txtFrom.Value;
            //}

            long from = (long)txtFrom.Value;

            var properties = db.PropertyTranslate.AsNoTracking().Where(x => x.LanguageID == 2).Select(x => new { ID = x.PropertyID, Name = x.Name.ToLower() }).ToList();
            var defaultIDs = db.ProductDefaultProperty.AsNoTracking().Where(x => x.MID >= from && x.MID <= txtTo.Value).Select(x => x.MID).Distinct().ToList();

            string url = "http://m.ua/mtools/mui_item_description_v2.php?idg_={0}&mode_=full";
            var web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36";

            bool isSave = true;

            cmd.Append("Begin transaction\n");

            int counter = 0;

            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                for (long productID = from; productID <= txtTo.Value; productID++)
                {
                    if (defaultIDs.Contains(productID))
                    {
                        continue;
                    }

                    txtFrom.Value = productID;
                    Application.DoEvents();

                    if (counter % 100 == 0)
                    {
                        isSave = true;
                    }

                    string requestUrl = string.Format(url, productID);
                    HtmlAgilityPack.HtmlDocument doc = web.Load(requestUrl);
                    //string json = client.DownloadString(string.Format(url, i));
                    //MessageBox.Show(json);

                    //doc.DocumentNode.InnerHtml = doc.DocumentNode.InnerHtml.Replace("\\'", "").Replace("\\\"", "");
                    var nodes = doc.DocumentNode.SelectNodes("//td[contains(@class, 'prop')]");
                    if (nodes == null)
                    {
                        continue;
                    }

                    counter++;


                    for (int j = 0; j < nodes.Count; j++)
                    {
                        string propertyName = nodes[j].InnerText.ToLower();
                        if (propertyName == "цвет")
                        {
                            continue;
                        }

                        var property = properties.FirstOrDefault(x => x.Name == propertyName);

                        if (property == null)
                        {
                            continue;
                        }

                        //var defaultProperty = new ProductDefaultProperty()
                        //{
                        //    ProductID = i,
                        //    PropertyID = property.ID
                        //};

                        //db.ProductDefaultProperty.Add(defaultProperty);

                        cmd.Append(string.Format("INSERT INTO dbo.ProductDefaultProperty (MID, PropertyID) Select {0}, {1} \n", productID, property.ID));

                    }

                    //db.SaveChanges();

                    if (isSave)
                    {
                        cmd.Append("commit");
                        comm.CommandText = cmd.ToString();
                        comm.ExecuteNonQuery();

                        isSave = false;
                        cmd.Clear();
                        cmd.Append("Begin transaction\n");

                        counter = 0;
                    }
                }
            }

            if (cmd.ToString() != "")
            {
                cmd.Append("commit");
                comm.CommandText = cmd.ToString();
                comm.ExecuteNonQuery();
            }

            conn.Close();
            MessageBox.Show("Scan Default Properties is DONE");
        }


        private void CreateCategoriesFromDB()
        {
            txtFrom.Minimum = 0;
            txtTo.Minimum = 0;

            List<myCategory> myCategories = new List<myCategory>();

            ModelPA db = new ModelPA();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            List<string> contents;

            int skip = 0;
            while (true)
            {
                Application.DoEvents();

                //if (skip == 3)
                //{
                //    break;
                //}

                contents = db.ScannedProductPAM.AsNoTracking().OrderBy(x => x.ID).Skip(skip * 1000).Take(1000).Select(x => x.Content).ToList();
                skip++;
                txtFrom.Value = skip * 1000;
                txtTo.Value = myCategories.Count();

                if (contents.Count == 0)
                {
                    break;
                }

                foreach (string content in contents)
                {
                    doc.LoadHtml(content);

                    var nodes = doc.DocumentNode.SelectNodes("//div[@id='top-page-title']/div[contains(@class, 'breadcrumbs')]/div/a");
                    if (nodes == null || nodes.Count < 3)
                    {
                        continue;
                    }

                    for (int i = 1; i < nodes.Count - 1; i++)
                    {
                        int id = int.Parse(nodes[i].Attributes["href"].Value.Replace("kata", "").Replace("/", ""));
                        int parentID = int.Parse(nodes[i - 1].Attributes["href"].Value.Replace("kata", "").Replace("/", ""));

                        if (!myCategories.Exists(x => x.ID == id && x.ParentID == parentID))
                        {
                            myCategories.Add(new myCategory()
                            {
                                ID = id,
                                ParentID = parentID,
                                Name = nodes[i].InnerText
                            });
                        }
                    }
                }
            }


            System.IO.File.WriteAllText("D:\\Caterories.xml", ToXML<List<myCategory>>(myCategories));


            MessageBox.Show("CreateCategoriesFromDB is DONE");
        }

        public string ToXML<T>(T obj)
        {
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                xmlSerializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }

        private void btnCreateCategoriesFromDB_Click(object sender, EventArgs e)
        {
            CreateCategoriesFromDB();
        }

    }


    class myJson
    {
        public Newtonsoft.Json.Linq.JObject pp_images { get; set; }
        public object pp_titles { get; set; }
        public object pp_descriptions { get; set; }
        public string NumPhoto { get; set; }
        public string NumVideo { get; set; }
    }


    class myKeyValue
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class myCategory
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
    }

}
