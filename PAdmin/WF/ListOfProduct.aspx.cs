using DevExpress.Web;
using PA.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Z.EntityFramework.Plus;

namespace PAdmin.WF
{
    public partial class ListOfProduct : System.Web.UI.Page
    {
        ModelPA _db = new ModelPA();

        protected void Page_Init(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public class ComboBoxListItem
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        private List<ComboBoxListItem> GetLanguageList(params string[] tags)
        {
            int languageID = (int)Session["LanguageID"];
            return _db.LanguageTranslate.Where(x => x.LanguageForID == languageID).FromCache(DateTimeOffset.Now.AddMinutes(60), tags)
                .Select(x => new ComboBoxListItem { ID = x.ID, Name = x.Name }).ToList();
        }

        private List<ComboBoxListItem> GetColorList(params string[] tags)
        {
            int languageID = (int)Session["LanguageID"];
            return _db.ColorTranslate.Where(x => x.LanguageID == languageID).FromCache(DateTimeOffset.Now.AddMinutes(60), tags)
                .Select(x => new ComboBoxListItem { ID = x.ColorID, Name = x.Name }).ToList();
        }

        private List<ComboBoxListItem> GetShopList(params string[] tags)
        {
            int languageID = (int)Session["LanguageID"];
            return _db.ShopTranslate.Where(x => x.LanguageID == languageID).FromCache(DateTimeOffset.Now.AddMinutes(60), tags)
                .Select(x => new ComboBoxListItem { ID = x.ShopID, Name = x.Name }).ToList();
        }

        private List<ComboBoxListItem> GetCategoryList(params string[] tags)
        {
            int languageID = (int)Session["LanguageID"];
            return _db.CategoryTranslate.Where(x => x.LanguageID == languageID).FromCache(DateTimeOffset.Now.AddMinutes(60), tags)
                .Select(x => new ComboBoxListItem { ID = x.CategoryID, Name = x.Name }).ToList();
        }

        private List<ComboBoxListItem> GetProductList(params string[] tags)
        {
            return _db.ShopProduct.Where(x => x.ProductID != null).Distinct()
                .Select(x => new ComboBoxListItem { ID = (int)x.ProductID, Name = x.Product.Brand.Name + " " + x.Product.Name })
                .FromCache(DateTimeOffset.Now.AddMinutes(60), tags)
                .ToList();
        }

        private List<ComboBoxListItem> GetBrandList(params string[] tags)
        {
            return _db.Brand.FromCache(DateTimeOffset.Now.AddMinutes(60), tags)
                .Select(x => new ComboBoxListItem { ID = x.ID, Name = x.Name }).ToList();
        }

        private void FillGridCombos()
        {
            var combo = grid.Columns["ColorID"] as GridViewDataComboBoxColumn;
            combo.PropertiesComboBox.DataSource = GetColorList("application", "color");
            combo.PropertiesComboBox.RequireDataBinding();

            combo = grid.Columns["ShopID"] as GridViewDataComboBoxColumn;
            combo.PropertiesComboBox.DataSource = GetShopList("application", "shop");
            combo.PropertiesComboBox.RequireDataBinding();

            combo = grid.Columns["CategoryID"] as GridViewDataComboBoxColumn;
            combo.PropertiesComboBox.DataSource = GetCategoryList("application", "category");
            combo.PropertiesComboBox.RequireDataBinding();

            combo = grid.Columns["ProductID"] as GridViewDataComboBoxColumn;
            combo.PropertiesComboBox.DataSource = GetProductList("application", "product");
            combo.PropertiesComboBox.RequireDataBinding();
        }

        protected void grid_Load(object sender, EventArgs e)
        {
            FillGridCombos();
        }

        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
        }

        protected void grid_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var grid = sender as ASPxGridView;

            int id = (int)e.Keys[0];

            var colorTranslate = _db.ColorTranslate.Where(x => x.ColorID == id).First();
            colorTranslate.Name = (string)e.NewValues["Name"];

            var color = _db.Color.Where(x => x.ID == id).First();
            color.HexCode = (string)e.NewValues["HexCode"];
            color.OrderNo = Convert.ToInt32(e.NewValues["OrderNo"]);

            _db.SaveChanges();

            QueryCacheManager.ExpireTag("application", "color");

            grid.CancelEdit();
            e.Cancel = true;
        }

        protected void grid_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
        }

        protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
        }

        protected void grid_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
        }

        protected void grid_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            var IDs = e.UpdateValues.Select(x => (int)x.Keys[0]).ToList();

            var prods = _db.ShopProduct.Where(x => IDs.Contains(x.ID)).ToList();

            foreach (var item in e.UpdateValues)
            {
                int id = (int)item.Keys[0];
                var prod = prods.First(x => x.ID == id);
                prod.Comment = (string)item.NewValues["Comment"];
                prod.CategoryID = (int?)item.NewValues["CategoryID"];
                prod.ColorID = (int?)item.NewValues["ColorID"];
                prod.ProductID = (long?)item.NewValues["ProductID"];
            }

            _db.SaveChanges();

            e.Handled = true;
        }

        protected void glProduct_Load(object sender, EventArgs e)
        {
            var grid = sender as ASPxGridLookup;

            var combo = grid.Columns["BrandID"] as GridViewDataComboBoxColumn;
            combo.PropertiesComboBox.DataSource = GetBrandList("application", "brand");
            combo.PropertiesComboBox.RequireDataBinding();

            combo = grid.Columns["CategoryID"] as GridViewDataComboBoxColumn;
            combo.PropertiesComboBox.DataSource = GetCategoryList("application", "category");
            combo.PropertiesComboBox.RequireDataBinding();
        }

    }
}