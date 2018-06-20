using DevExpress.XtraEditors;
using PA.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaWinAdmin
{
    public partial class frmShopProduct : Form
    {
        ModelPA _db = new ModelPA();

        public frmShopProduct()
        {
            InitializeComponent();

            entityServerModeSource1.QueryableSource = _db.ShopProduct;
            esmsColor.QueryableSource = _db.ColorTranslate.Where(x => x.LanguageID == 1)
                .Select(x => new { ID = x.ColorID, Name = x.Name });
            esmsCategory.QueryableSource = _db.CategoryTranslate.Where(x => x.LanguageID == 1)
                .Select(x => new { ID = x.CategoryID, Name = x.Name });
            esmsShop.QueryableSource = _db.Shop//.Where(x => x.LanguageID == 1)
                .Select(x => new { ID = x.ID, Name = x.URL });


            spinProductID.Enter += spinProductID_Enter;
            spinProductID.DoubleClick += spinProductID_DoubleClick;
        }

     
        private void frmShopProduct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pADataSet.ShopProduct' table. You can move, or remove it, as needed.
            this.shopProductTableAdapter.Fill(this.pADataSet.v_ShopProduct);
            try
            {
                gridView1.RestoreLayoutFromXml(Path.Combine(Application.StartupPath, "grid.layout"));
            }
            catch { }
        }

        private void frmShopProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridView1.SaveLayoutToXml(Path.Combine(Application.StartupPath, "grid.layout"));
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

            try
            {
                long mid = _db.Product.First(z => z.ID == productId).MID;
                int id = (int)gridView1.GetFocusedRowCellValue("ID");
                ((PADataSet.v_ShopProductRow)pADataSet.v_ShopProduct.Select("id=" + id)[0]).FullName
                    = _db.ScannedProduct.Where(x => x.ID == mid).Select(x=>x.FullName).First();
            }
            catch
            {

            }
            shopProductTableAdapter.Update(pADataSet.v_ShopProduct);
        }


        long productId;
        string productName;
        private void spinProductID_Enter(object sender, EventArgs e)
        {
            
        }

        private void spinProductID_DoubleClick(object sender, EventArgs e)
        {
            frmSearchLookupTest f = new frmSearchLookupTest();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                (sender as SpinEdit).Value = f.ProductID;

                productId = f.ProductID;
                productName = f.ProductName;
            }
        }


    }
}
