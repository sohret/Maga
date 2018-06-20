using HtmlAgilityPack;
using PA.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopCrawler
{
    public class PACrawler
    {
        public static void Crawle(int shopId, string url, string nodesXpath, string titleXpath, string urlXpath, string priceXpath, bool isPriceWithPenny
            , int? childNode, DateTime scanDateTime)
        {
            ModelPA db = new ModelPA();

            var shopProductsInDatabase = db.ShopProduct.Where(x => x.ShopID == shopId).ToList();

            var shopProductsScanned = new List<ShopProduct>();

            var web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36";

            int lastPage = (url.Contains("#PAGE#") ? 100 : 1);
            int repeat = 0;

            for (int page = 1; page <= lastPage; page++)
            {
                if (repeat > 20) // if the next pages show last page
                {
                    break;
                }

                string myPage = page.ToString();
                #region custom code
                if (shopId == 9)
                {
                    myPage = ((page - 1) * 24).ToString();
                }
                else if (shopId == 28)
                {
                    myPage = ((page - 1) * 20).ToString();
                }
                #endregion custom code

                string requestUrl = url.Replace("#PAGE#", myPage);
                if (shopId == 41 && page == 1)
                {
                    requestUrl = url.Replace("?page=#PAGE#", "");
                }

                HtmlAgilityPack.HtmlDocument doc = null;
                bool isBreak = false;
                while (true)
                {
                    try
                    {
                        doc = web.Load(requestUrl);
                        break;
                    }
                    catch (WebException ex)
                    {
                        if (ex.Message == "The request was aborted: The connection was closed unexpectedly."
                            || ex.Message == "Unable to connect to the remote server")
                        {
                            isBreak = true;
                            break;
                        }
                        else
                        {
                            System.Threading.Thread.Sleep(10000);
                            //throw;
                        }
                    }
                }

                if (isBreak)
                {
                    break;
                }

                if (shopId == 46 && (doc.DocumentNode.SelectSingleNode("//div[contains(@class,'error-page')]") != null
                    || doc.DocumentNode.SelectSingleNode("//span[contains(@class,'exception_title')]") != null))
                {
                    break;
                }


                if (web.ResponseUri.ToString() != requestUrl) // if redirected to other url
                {
                    if (shopId == 1 && web.ResponseUri.ToString() == requestUrl.Replace("/page/" + page, ""))
                    {
                    }
                    else if (shopId == 9 && web.ResponseUri.ToString() == requestUrl.Replace("0/", ""))
                    {

                    }
                    else
                    {
                        break;
                    }
                }

                #region custom code
                if (shopId == 22) // maxi.az
                {
                    var xnodes = doc.DocumentNode.SelectNodes("//span[@class='was-price']");
                    if (xnodes != null)
                    {
                        for (int i = xnodes.Count - 1; i >= 0; i--)
                        {
                            xnodes[i].ParentNode.RemoveChild(xnodes[i]);
                        }
                    }
                }
                if (shopId == 26) // amazoncomp.az
                {
                    var xnodes = doc.DocumentNode.SelectNodes("//span[@class='product_score']");
                    if (xnodes != null)
                    {
                        for (int i = xnodes.Count - 1; i >= 0; i--)
                        {
                            xnodes[i].ParentNode.RemoveChild(xnodes[i]);
                        }
                    }
                    xnodes = doc.DocumentNode.SelectNodes("//span[@class='order']");
                    if (xnodes != null)
                    {
                        for (int i = xnodes.Count - 1; i >= 0; i--)
                        {
                            xnodes[i].ParentNode.RemoveChild(xnodes[i]);
                        }
                    }
                }
                #endregion custom code



                HtmlAgilityPack.HtmlNodeCollection nodes;
                if (urlXpath == "xml")
                {
                    nodes = doc.DocumentNode.SelectNodes("//body");
                }
                else
                {
                    nodes = doc.DocumentNode.SelectNodes(nodesXpath);
                }

                if (nodes == null || nodes.Count == 0)
                {
                    break;
                }

                for (int i = 0; i < nodes.Count; i++)
                {
                    if (repeat > 20) // if the next pages show last page
                    {
                        break;
                    }

                    string productUrl;
                    if (urlXpath == "xml")
                    {
                        productUrl = requestUrl;
                    }
                    else
                    {
                        var nodeUrl = nodes[i].SelectSingleNode(urlXpath);
                        //if (nodeUrl == null && (nodes.Count == 1 || shopId == 21))
                        //{
                        //    break;
                        //}
                        if (nodeUrl == null)
                        {
                            continue;
                        }

                        productUrl = nodeUrl.Attributes["href"].Value;
                    }

                    if (shopProductsScanned.FirstOrDefault(x => x.URL == productUrl) != null)
                    {
                        repeat++;
                        continue;
                        //page = 100;
                        //break;
                    }

                    string title = nodes[i].SelectSingleNode(titleXpath).InnerText.Trim();

                    if (shopId == 32) // giftshop.az
                    {
                        title = WebUtility.HtmlDecode(title);
                    }
                    if (shopId == 5 && title.Contains("..."))
                    {
                        title = GetIrTelecomProductName(int.Parse(productUrl.Replace("/product/index/", "")));
                    }

                    #region Price

                    if (shopId == 21) // notecomp.az
                    {
                        i++;
                    }


                    var priceNode = nodes[i].SelectSingleNode(priceXpath);

                    #region custom code
                    if ((shopId == 8 || shopId == 29 || shopId == 30 || shopId == 34 || shopId == 37) && priceNode == null) // nix.az, compus.az, bestshop.az
                    {
                        priceNode = nodes[i].SelectSingleNode(priceXpath.Replace("/span[contains(@class, 'price-new')]", ""));
                    }

                    #endregion custom code

                    if (priceNode == null)
                    {
                        continue;
                    }

                    string sprice;


                    if (shopId == 42)
                    {
                        sprice = "0";

                        foreach (var item in nodes[i].SelectNodes(priceXpath))
                        {
                            if (item.ChildNodes[0].InnerText.Contains("Nağd"))
                            {
                                sprice = item.ChildNodes[0].InnerText.Replace("Nağd", "").Replace("&#x20bc;", "");
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (shopId == 15)
                        {
                            childNode = 0;
                        }
                        //else if (shopId == 46)
                        //{
                        //    childNode = 3;
                        //}

                        if (childNode == null)
                        {
                            sprice = priceNode.InnerText;
                        }
                        else
                        {
                            sprice = priceNode.ChildNodes[childNode.Value].InnerText;
                        }
                    }

                    if (shopId == 19)
                    {
                        sprice = sprice.Replace(".", "");
                    }

                    sprice = sprice.ToLower().Replace("m", "").Replace("azn.", "").Replace("azn", "").Trim().Replace('.', ',').Replace("₼", "").Replace(" ", "");

                    #region custom code
                    //if (shopId == 22 || shopId == 31 || shopId == 32) // maxi.az, onlinepc.az, giftshop.az
                    //{
                    //    sprice = sprice.Replace(" ", "");
                    //}
                    //else 
                    if (shopId == 27 || shopId == 29 || shopId == 30 || shopId == 37 || shopId == 8 || shopId == 40) // smartel.az, nix.az, compus.az
                    {
                        sprice = sprice.Replace(",", "");
                    }
                    else if (shopId == 28) // mycomp.az
                    {
                        sprice = sprice.Replace("&nbsp;", "");
                    }
                    #endregion custom code

                    if (sprice.IndexOf(' ') > 0)
                    {
                        sprice = sprice.Substring(0, sprice.IndexOf(' '));
                    }

                    float fprice;
                    if (!float.TryParse(sprice, out fprice))
                    {
                        continue;
                    }

                    int price;
                    if (shopId == 1)
                    {
                        price = (int)(fprice * (sprice.Contains('.') ? 100 : 1));
                    }
                    else
                    {
                        price = (int)(fprice * (isPriceWithPenny ? 1 : 100));
                    }


                    #endregion Price

                    if (shopProductsScanned.FirstOrDefault(x => x.URL == productUrl) == null)
                    {
                        shopProductsScanned.Add(new ShopProduct()
                        {
                            ShopID = shopId,
                            //  CategoryID = categoryId,
                            Name = title,
                            Price = price,
                            URL = productUrl,
                            UpdateDate = scanDateTime
                        });
                    }
                    else
                    {
                        repeat++;
                    }

                    if (shopId == 21) // notecomp.az
                    {
                        i++;
                    }
                }

            }

            var scannedUrls = shopProductsScanned.Select(x => x.URL).ToList();
            var inDbUrls = db.ShopProduct.Where(x => x.ShopID == shopId).Select(x => x.URL).ToList();
            var toAdd = shopProductsScanned.Where(x => !inDbUrls.Contains(x.URL)).ToList();

            // Price updated rows
            foreach (var item in shopProductsInDatabase.Where(x => scannedUrls.Contains(x.URL)).ToList())
            {
                var ss = shopProductsScanned.First(z => z.URL == item.URL);
                item.Price = ss.Price;
                item.UpdateDate = scanDateTime;
                item.Name = ss.Name;
                item.DeleteDate = null;
            }


            //db.ShopProduct.RemoveRange(toRemove);
            db.ShopProduct.AddRange(toAdd);

            db.SaveChanges();

        }

        private static string GetIrTelecomProductName(int productId)
        {
            var web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36";

            HtmlAgilityPack.HtmlDocument doc = web.Load("https://irtelecom.az/product/index/" + productId);
            //return doc.DocumentNode.SelectSingleNode("//h2[@class='flypage_product_name']").InnerText.Trim();
            return doc.DocumentNode.SelectSingleNode("//div[contains(@class,'f_product_heading')]").InnerText.Trim();
        }






        public void Crawle(string url, NumericUpDown from, NumericUpDown to, NumericUpDown step)
        {
            ModelPA db = new ModelPA();
            var web = new HtmlWeb();

            var scanned = new List<ScannedProduct>();

            long i = (long)from.Value;

            while (true)
            {
                if (i > to.Value)
                {
                    break;
                }

                from.Value = i;
                Application.DoEvents();
                string content;

                try
                {
                    var doc = web.Load(url.Replace("#ID#", i.ToString()));

                    content = doc.DocumentNode.InnerHtml;
                }
                catch
                {
                    System.Threading.Thread.Sleep(10000);
                    continue;
                }

                scanned.Add(new ScannedProduct()
                {
                    ID = i,
                    Content = content
                });

                i = i + (long)step.Value;

                if (scanned.Count == 100)
                {
                    db.ScannedProduct.AddRange(scanned);
                    db.SaveChanges();
                    scanned.Clear();
                }

            }

            db.ScannedProduct.AddRange(scanned);
            db.SaveChanges();
            MessageBox.Show("DONE " + DateTime.Now.ToShortTimeString());

        }


    }
}
