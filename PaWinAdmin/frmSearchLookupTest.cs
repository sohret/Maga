using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaWinAdmin
{
    public partial class frmSearchLookupTest : Form
    {
        private MyGridLookUpEdit grid;
        public long ProductID { get; set; }
        //public string ProductName { get; set; }


        public frmSearchLookupTest()
        {
            InitializeComponent();

            grid = new MyGridLookUpEdit();

            grid.Popup += grid_Popup;
            grid.CloseUp += grid_CloseUp;
            grid.Width = 400;
            grid.Location = new Point(3, 3);

            // grid.Spin += grid_Spin;
            //grid.QueryPopUp += grid_QueryPopUp;

            this.Controls.Add(grid);
        }

        private void grid_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (findEdit != null)
            {
                findEdit.TextChanged -= findEdit_TextChanged;
                findEdit = (sender as IPopupControl).PopupWindow.Controls[2].Controls[0].Controls[7] as TextEdit;
                searchText = findEdit.Text;
            }
        }

        TextEdit findEdit;
        string searchText;
        private void grid_Popup(object sender, EventArgs e)
        {
            PopupSearchLookUpEditForm popupForm = (sender as IPopupControl).PopupWindow as PopupSearchLookUpEditForm;
            PropertyInfo pi = typeof(PopupSearchLookUpEditForm).GetProperty("FindEdit", BindingFlags.Instance | BindingFlags.NonPublic);
            findEdit = pi.GetValue(popupForm, null) as TextEdit;
            findEdit.TextChanged += findEdit_TextChanged;
            findEdit = (sender as IPopupControl).PopupWindow.Controls[2].Controls[0].Controls[7] as TextEdit;
            findEdit.Text = searchText;


            popupForm.KeyDown += popupForm_KeyDown;

        }

        private void popupForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                e.Handled = true;
                this.Close();
            }
        }

        private void findEdit_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(findEdit.Text))
            {
                grid.Properties.OnSearch(new SearchItem() { Key = findEdit.Text });
            }
        }

        public void CloseForm()
        {
            if (grid.EditValue == null)
            {
                return;
            }

            ProductID = (long)grid.EditValue;
            //ProductName = grid.Properties.GetDisplayValueByKeyValue(grid.EditValue).ToString();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void frmSearchLookupTest_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            grid.Focus();
        }

        private void frmSearchLookupTest_Shown(object sender, EventArgs e)
        {
            grid.ShowPopup();
        }

        private void frmSearchLookupTest_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void frmSearchLookupTest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                this.Close();
            }
        }









        //////private void SearchLookupTest_Load(object sender, EventArgs e)
        //////{

        //////}

        //////private void searchLookUpEdit1_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        //////{

        //////    //            e.DisplayValue
        //////}

        //////private void searchLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //////{

        //////}


        //////IPopupControl popup;

        //////void searchLookUpEdit1_Popup(object sender, EventArgs e)
        //////{
        //////    IPopupControl popupControl = sender as IPopupControl;
        //////    popup = popupControl;
        //////    LayoutControl layoutControl = popupControl.PopupWindow.Controls[2].Controls[0] as LayoutControl;
        //////    SimpleButton Button = ((LayoutControlItem)layoutControl.Items.FindByName("lciButtonFind")).Control as SimpleButton;

        //////    if (Button != null)
        //////    {
        //////        Button.Click -= new EventHandler(button_Click);
        //////        Button.Click += new EventHandler(button_Click);
        //////    }


        //////    PopupSearchLookUpEditForm popupWindow = (PopupSearchLookUpEditForm)popupControl.PopupWindow;
        //////    System.Reflection.PropertyInfo property = typeof(PopupSearchLookUpEditForm).GetProperty("FindEdit", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        //////    TextEdit textEdit = (TextEdit)property.GetValue(popupWindow, null);
        //////    textEdit.KeyDown += textEdit_KeyDown;

        //////}

        //////void search()
        //////{
        //////    string findText = (popup.PopupWindow as PopupSearchLookUpEditForm).Controls.Find("teFind", true)[0].Text;

        //////    if (findText.Length == 0)
        //////    {
        //////        return;
        //////    }

        //////    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ModelPA"].ConnectionString);
        //////    SqlDataAdapter da = new SqlDataAdapter();
        //////    SqlCommand comm = new SqlCommand();
        //////    da.SelectCommand = comm;
        //////    comm.CommandType = CommandType.Text;
        //////    comm.Connection = conn;

        //////    comm.CommandText = string.Format("Select top 100 ID, Name from Product where contains(name,N'{0}')", findText.Replace(' ', '&'));

        //////    var dt = new DataTable();
        //////    da.Fill(dt);

        //////    searchLookUpEdit1.Properties.DataSource = dt;
        //////}

        //////void button_Click(object sender, EventArgs e)
        //////{
        //////    search();
        //////}

        //////void searchLookUpEdit1_QueryCloseUp(object sender, System.ComponentModel.CancelEventArgs e)
        //////{
        //////    IPopupControl popupControl = sender as IPopupControl;
        //////    LayoutControl layoutControl = popupControl.PopupWindow.Controls[2].Controls[0] as LayoutControl;
        //////    SimpleButton Button = ((LayoutControlItem)layoutControl.Items.FindByName("lciButtonFind")).Control as SimpleButton;

        //////    if (Button != null)
        //////    {
        //////        Button.Click -= new EventHandler(button_Click);
        //////    }
        //////    e.Cancel = true;
        //////    //searchLookUpEdit1.ShowPopup();
        //////}

        //////void textEdit_KeyDown(object sender, KeyEventArgs e)
        //////{
        //////    if (e.KeyCode == Keys.Enter)
        //////    {
        //////        search();
        //////    }
        //////}

    }
}
