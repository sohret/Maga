namespace PaWinAdmin
{
    partial class frmShopProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spinProductID = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.entityServerModeSource1 = new DevExpress.Data.Linq.EntityServerModeSource();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.shopProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pADataSet = new PaWinAdmin.PADataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShopID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupShop = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.esmsShop = new DevExpress.Data.Linq.EntityServerModeSource();
            this.colProductFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColorID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupColor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.esmsColor = new DevExpress.Data.Linq.EntityServerModeSource();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colURL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInsertDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookupCategory = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.esmsCategory = new DevExpress.Data.Linq.EntityServerModeSource();
            this.shopProductTableAdapter = new PaWinAdmin.PADataSetTableAdapters.v_ShopProductTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spinProductID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityServerModeSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esmsShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esmsColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.esmsCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // colProductID
            // 
            this.colProductID.Caption = "ProductID";
            this.colProductID.ColumnEdit = this.spinProductID;
            this.colProductID.FieldName = "ProductID";
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 2;
            // 
            // spinProductID
            // 
            this.spinProductID.AutoHeight = false;
            this.spinProductID.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinProductID.Name = "spinProductID";
            // 
            // entityServerModeSource1
            // 
            this.entityServerModeSource1.DefaultSorting = "ID ASC";
            this.entityServerModeSource1.ElementType = typeof(PA.Data.Models.ShopProduct);
            this.entityServerModeSource1.KeyExpression = "ID";
            // 
            // grid
            // 
            this.grid.DataSource = this.shopProductBindingSource;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.gridView1;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSpinEdit1,
            this.lookupColor,
            this.lookupCategory,
            this.lookupShop,
            this.spinProductID});
            this.grid.Size = new System.Drawing.Size(802, 442);
            this.grid.TabIndex = 0;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // shopProductBindingSource
            // 
            this.shopProductBindingSource.DataMember = "v_ShopProduct";
            this.shopProductBindingSource.DataSource = this.pADataSet;
            // 
            // pADataSet
            // 
            this.pADataSet.DataSetName = "PADataSet";
            this.pADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colShopID,
            this.colProductID,
            this.colProductFullName,
            this.colColorID,
            this.colPrice,
            this.colURL,
            this.colName,
            this.colComment,
            this.colInsertDate});
            gridFormatRule1.ApplyToRow = true;
            gridFormatRule1.Column = this.colProductID;
            gridFormatRule1.Name = "Format0";
            formatConditionRuleValue1.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            formatConditionRuleValue1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            formatConditionRuleValue1.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue1.Appearance.Options.UseForeColor = true;
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.NotEqual;
            gridFormatRule1.Rule = formatConditionRuleValue1;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.GridControl = this.grid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.gridView1.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.gridView1.OptionsEditForm.ActionOnModifiedRowChange = DevExpress.XtraGrid.Views.Grid.EditFormModifiedAction.Save;
            this.gridView1.OptionsEditForm.BindingMode = DevExpress.XtraGrid.Views.Grid.EditFormBindingMode.Direct;
            this.gridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.FindClick;
            this.gridView1.OptionsLayout.LayoutVersion = "1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colShopID
            // 
            this.colShopID.Caption = "Shop";
            this.colShopID.ColumnEdit = this.lookupShop;
            this.colShopID.FieldName = "ShopID";
            this.colShopID.Name = "colShopID";
            this.colShopID.OptionsColumn.AllowEdit = false;
            this.colShopID.Visible = true;
            this.colShopID.VisibleIndex = 1;
            // 
            // lookupShop
            // 
            this.lookupShop.AutoHeight = false;
            this.lookupShop.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupShop.DataSource = this.esmsShop;
            this.lookupShop.DisplayMember = "Name";
            this.lookupShop.DropDownRows = 15;
            this.lookupShop.KeyMember = "ID";
            this.lookupShop.Name = "lookupShop";
            this.lookupShop.NullText = "";
            this.lookupShop.ValueMember = "ID";
            // 
            // esmsShop
            // 
            this.esmsShop.DefaultSorting = "ID ASC";
            this.esmsShop.KeyExpression = "ID";
            // 
            // colProductFullName
            // 
            this.colProductFullName.Caption = "Product Full Name";
            this.colProductFullName.FieldName = "FullName";
            this.colProductFullName.Name = "colProductFullName";
            this.colProductFullName.OptionsColumn.AllowEdit = false;
            this.colProductFullName.Visible = true;
            this.colProductFullName.VisibleIndex = 9;
            // 
            // colColorID
            // 
            this.colColorID.Caption = "Color";
            this.colColorID.ColumnEdit = this.lookupColor;
            this.colColorID.FieldName = "ColorID";
            this.colColorID.Name = "colColorID";
            this.colColorID.Visible = true;
            this.colColorID.VisibleIndex = 3;
            // 
            // lookupColor
            // 
            this.lookupColor.AutoHeight = false;
            this.lookupColor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupColor.DataSource = this.esmsColor;
            this.lookupColor.DisplayMember = "Name";
            this.lookupColor.DropDownRows = 15;
            this.lookupColor.KeyMember = "ID";
            this.lookupColor.Name = "lookupColor";
            this.lookupColor.NullText = "";
            this.lookupColor.ValueMember = "ID";
            // 
            // esmsColor
            // 
            this.esmsColor.DefaultSorting = "ID ASC";
            this.esmsColor.KeyExpression = "ID";
            // 
            // colPrice
            // 
            this.colPrice.Caption = "Price";
            this.colPrice.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.OptionsColumn.AllowEdit = false;
            this.colPrice.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 4;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.IsFloatValue = false;
            this.repositoryItemSpinEdit1.Mask.EditMask = "N00";
            this.repositoryItemSpinEdit1.MaxLength = 7;
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // colURL
            // 
            this.colURL.Caption = "URL";
            this.colURL.FieldName = "URL";
            this.colURL.Name = "colURL";
            this.colURL.OptionsColumn.AllowEdit = false;
            this.colURL.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colURL.Visible = true;
            this.colURL.VisibleIndex = 5;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 6;
            // 
            // colComment
            // 
            this.colComment.Caption = "Comment";
            this.colComment.FieldName = "Comment";
            this.colComment.Name = "colComment";
            this.colComment.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colComment.Visible = true;
            this.colComment.VisibleIndex = 7;
            // 
            // colInsertDate
            // 
            this.colInsertDate.Caption = "InsertDate";
            this.colInsertDate.FieldName = "InsertDate";
            this.colInsertDate.Name = "colInsertDate";
            this.colInsertDate.OptionsColumn.AllowEdit = false;
            this.colInsertDate.Visible = true;
            this.colInsertDate.VisibleIndex = 8;
            // 
            // lookupCategory
            // 
            this.lookupCategory.AutoHeight = false;
            this.lookupCategory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupCategory.DataSource = this.esmsCategory;
            this.lookupCategory.DisplayMember = "Name";
            this.lookupCategory.DropDownRows = 15;
            this.lookupCategory.KeyMember = "ID";
            this.lookupCategory.Name = "lookupCategory";
            this.lookupCategory.NullText = "";
            this.lookupCategory.ValueMember = "ID";
            // 
            // esmsCategory
            // 
            this.esmsCategory.DefaultSorting = "ID ASC";
            this.esmsCategory.KeyExpression = "ID";
            // 
            // shopProductTableAdapter
            // 
            this.shopProductTableAdapter.ClearBeforeFill = true;
            // 
            // frmShopProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 442);
            this.Controls.Add(this.grid);
            this.Name = "frmShopProduct";
            this.Text = "ShopProduct";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmShopProduct_FormClosing);
            this.Load += new System.EventHandler(this.frmShopProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spinProductID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entityServerModeSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shopProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esmsShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esmsColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.esmsCategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Data.Linq.EntityServerModeSource entityServerModeSource1;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colShopID;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraGrid.Columns.GridColumn colColorID;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colURL;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colComment;
        private DevExpress.XtraGrid.Columns.GridColumn colInsertDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.Data.Linq.EntityServerModeSource esmsColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookupColor;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookupShop;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lookupCategory;
        private DevExpress.Data.Linq.EntityServerModeSource esmsShop;
        private DevExpress.Data.Linq.EntityServerModeSource esmsCategory;
        private PADataSet pADataSet;
        private System.Windows.Forms.BindingSource shopProductBindingSource;
        private PADataSetTableAdapters.v_ShopProductTableAdapter shopProductTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colProductFullName;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinProductID;
    }
}

