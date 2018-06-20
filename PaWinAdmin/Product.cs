using PA.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PaWinAdmin
{
    public static class Product
    {
        public static List<string> Brands = new List<string>();

        static Product()
        {
            var db = new ModelPA();
            Brands = db.Brand.Select(x => x.Name).ToList();
        }


        public static PADataSet.ProductSearchResultDataTable Search(string findText)
        {
            findText = findText.Trim();

            if (string.IsNullOrEmpty(findText))
            {
                return null;
            }

            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ModelPA"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand comm = new SqlCommand();
            da.SelectCommand = comm;
            comm.CommandType = CommandType.Text;
            comm.Connection = conn;

            string[] s = findText.Replace("  ", " ").Split(' ');
            findText = "";
            string likeText = "";
            int iTry;
            for (int i = 0; i < s.Length; i++)
            {
                if ((s.Length > 1 || !Brands.Contains(s[i]) || s[i].Contains('-')) && ((i > 0 && s[i].Length <= 3) || int.TryParse(s[i], out iTry) || s[i].Contains('-')))
                {
                    likeText += " and FullName like N'%" + s[i] + "%'";
                }
                else
                {
                    findText += (string.IsNullOrEmpty(findText) ? "" : "&") + "\"" + (i == 0 ? "" : "*") + s[i] + (i == 0 ? "" : "*") + "\"";
                }
            }


            comm.CommandText = string.Format("set rowcount 100; Select p.ID, sp.FullName as Name from dbo.ScannedProduct sp inner join dbo.Product p on p.MID = sp.ID where contains(FullName, N'{0}') {1}", findText, likeText)
                .Replace("contains(FullName, N'')  and ", "");

            var dt = new PADataSet.ProductSearchResultDataTable();
            da.Fill(dt);

            return dt;
        }

    }
}


