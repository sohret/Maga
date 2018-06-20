using PA.Data.Models.PAX;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using Z.EntityFramework.Plus;

namespace PaWebsite
{
    public class Helper
    {
        public static List<string> Folders { get; set; }

        //public static List<Brand> Brands = new List<Brand>();

        static Helper()
        {
            Folders = new List<string>();
            for (int i = 0; i < 1000000; i++)
            {
                string s = System.IO.Path.GetRandomFileName().Substring(0, 2);
                if (!Folders.Contains(s))
                {
                    Folders.Add(s);
                }

                if (Folders.Count == 1024)
                {
                    break;
                }
            }

            Folders.Sort(StringComparer.Create(new CultureInfo("en-US"), true));


            var db = new ModelPAX();
            //Brands = db.Language.AsNoTracking().FromCache().Where(x => x.LanguageForID == LangID && x.LanguageID != LangID).ToList();
        }


        public static string CreateThumbImagePath(int productID)
        {
            return "/img/s/"+Folders[productID / 1024]+"/"+productID+".jpg";
        }


        public static string CreateBigImagePath(int productID)
        {
            return "/img/b/" + Folders[productID / 1024] + "/" + productID + ".jpg";
        }
    }
}