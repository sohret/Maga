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
    public class MyGridLookUpEdit : SearchLookUpEdit
    {
        private RepositoryItemSearchLookUpEdit fProperties;
        private GridView gridView1;
        private GridView fPropertiesView;
    
        public MyGridLookUpEdit()
            : base()
        {
            InitializeComponent();
            // this.PopupForm.TextChanged += PopupForm_TextChanged;
        }

        protected override void OnPropertiesChanged_SyncPopup()
        {
            //empty
        }


        void PopupForm_TextChanged(object sender, System.EventArgs e)
        {

        }

        void MyGridLookUpEdit_TextChanged(object sender, System.EventArgs e)
        {
            //MessageBox.Show(this.Text);
        }

        protected override void OnEditorKeyPress(KeyPressEventArgs e)
        {
            // MessageBox.Show(e.KeyChar.ToString());
            //if (e.KeyChar == (char)Keys.Escape)
            //{
            //    ((frmSearchLookupTest)this.Parent).Close();
            //}
            //else
            //{
                base.OnEditorKeyPress(e);
            //}
        }
        public override string EditorTypeName
        {
            get
            {
                return RepositoryItemMyGridLookUpEdit.MyGridLookUpEditName;
            }
        }

        static MyGridLookUpEdit()
        {
            RepositoryItemMyGridLookUpEdit.RegisterMyGridLookUpEdit();
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemMyGridLookUpEdit Properties
        {
            get { return base.Properties as RepositoryItemMyGridLookUpEdit; }
        }

        private void InitializeComponent()
        {
            this.fProperties = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.fPropertiesView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fPropertiesView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fProperties
            // 
            this.fProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fProperties.Name = "fProperties";
            this.fProperties.View = this.gridView1;
            // 
            // fPropertiesView
            // 
            this.fPropertiesView.Name = "fPropertiesView";
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // MyGridLookUpEdit
            // 
            this.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.MyGridLookUpEdit_Closed);
            this.EditValueChanged += new System.EventHandler(this.MyGridLookUpEdit_EditValueChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyGridLookUpEdit_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.fProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fPropertiesView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private void MyGridLookUpEdit_EditValueChanged(object sender, System.EventArgs e)
        {
            
        }

        private void MyGridLookUpEdit_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            ((frmSearchLookupTest)this.Parent).CloseForm();
        }

        private void MyGridLookUpEdit_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

    }
}
