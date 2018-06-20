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
    public partial class ListOfColor : System.Web.UI.Page
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

        private void FillGridCombos()
        {
            var combo = grid.Columns["LanguageID"] as GridViewDataComboBoxColumn;
            combo.PropertiesComboBox.DataSource = GetLanguageList("application", "language");
            combo.PropertiesComboBox.RequireDataBinding();

            combo = grid.Columns["ColorID"] as GridViewDataComboBoxColumn;
            combo.PropertiesComboBox.DataSource = GetColorList("application", "color");
            combo.PropertiesComboBox.RequireDataBinding();

        }

        protected void grid_Load(object sender, EventArgs e)
        {
            FillGridCombos();
        }

        protected void grid_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var grid = sender as ASPxGridView;



            var newColorTranslate = new ColorTranslate()
            {
                LanguageID = Convert.ToInt32(e.NewValues["LanguageID"]),
                Name = (string)e.NewValues["Name"],
            };

            int colorId;
            if (e.NewValues["ColorID"] == null)
            {
                var newColor = new Color()
                {
                    HexCode = (string)e.NewValues["HexCode"],
                    OrderNo = Convert.ToInt32(e.NewValues["OrderNo"])
                };
                _db.Color.Add(newColor);

                newColorTranslate.Color = newColor;
            }
            else
            {
                newColorTranslate.ColorID = Convert.ToInt32(e.NewValues["ColorID"]);
            }

            _db.ColorTranslate.Add(newColorTranslate);

            _db.SaveChanges();

            QueryCacheManager.ExpireTag("application", "color");

            grid.CancelEdit();
            e.Cancel = true;
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
            var grid = sender as ASPxGridView;

            int id = (int)e.Keys[0];

            var colorTranslate = _db.ColorTranslate.Where(x => x.ID == id).First();
            _db.ColorTranslate.Remove(colorTranslate);
            _db.SaveChanges();

            QueryCacheManager.ExpireTag("application", "color");

            grid.CancelEdit();
            e.Cancel = true;
        }

        protected void grid_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["OrderNo"] = 1;

        }

        protected void grid_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "LanguageID")
            {
                if (grid.IsNewRowEditing)
                {
                    e.Editor.ReadOnly = false;
                }
                else
                {
                    e.Editor.ReadOnly = true;
                }
            }
            else if (e.Column.FieldName == "ColorID")
            {
                if (grid.IsNewRowEditing)
                {
                    e.Editor.ReadOnly = false;
                }
                else
                {
                    e.Editor.ReadOnly = true;
                }
            }


            if (e.Editor is ASPxComboBox)
            {
                e.Editor.Width = 200;
            }
        }

    }
}