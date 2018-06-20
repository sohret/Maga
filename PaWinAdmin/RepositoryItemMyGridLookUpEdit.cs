using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;


namespace PaWinAdmin
{

    public class SearchItem
    {
        public string Key { get; set; }
    }

    [UserRepositoryItem("RegisterMyGridLookUpEdit")]
    public class RepositoryItemMyGridLookUpEdit : RepositoryItemSearchLookUpEdit
    {
        //The unique name for the custom editor
        public const string MyGridLookUpEditName = "MyGridLookUpEdit";

        //Return the unique name
        public override string EditorTypeName { get { return MyGridLookUpEditName; } }

        //Register the editor
        public static void RegisterMyGridLookUpEdit()
        {
            Image img = null;

            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(MyGridLookUpEditName,
              typeof(MyGridLookUpEdit), typeof(RepositoryItemMyGridLookUpEdit),
              typeof(GridLookUpEditBaseViewInfo), new ButtonEditPainter(), true, img));
        }


        protected override void OnLookAndFeelChanged(object sender, System.EventArgs e)
        {
            base.OnLookAndFeelChanged(sender, e);
            MessageBox.Show("changed");
        }


        //Override the Assign method
        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                RepositoryItemMyGridLookUpEdit source =
                    item as RepositoryItemMyGridLookUpEdit;
                if (source == null) return;
            }
            finally
            {
                EndUpdate();
            }
        }

        protected override void OnLoaded()
        {
            base.OnLoaded();

            if (IsDesignMode) return;
            // Create two columns
            GridColumn colId = new GridColumn()
            {
                FieldName = "ID",
                Caption = "ID",
                VisibleIndex = 0,
                Width = 75,
            };

            GridColumn colName = new GridColumn()
            {
                FieldName = "Name",
                Caption = "Name",
                VisibleIndex = 2,
                Width = 250,
            };

            GridView gView = this.View;
            gView.Columns.Clear();
            gView.Columns.Add(colId);
            gView.Columns.Add(colName);
            // Hide the group panel
            gView.OptionsView.ShowGroupPanel = true;
            // Initialize data source
            DisplayMember = "Name";
            ValueMember = "ID";
            
        }

        public void OnSearch(SearchItem item)
        {
            this.DataSource = null;
            this.BeginUpdate();
            this.DataSource = Product.Search(item.Key);
            this.EndUpdate();
        }

    }
}
