namespace ShopCrawler
{
    partial class frmMain
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtFrom = new System.Windows.Forms.NumericUpDown();
            this.button4 = new System.Windows.Forms.Button();
            this.txtDirection = new System.Windows.Forms.NumericUpDown();
            this.txtTo = new System.Windows.Forms.NumericUpDown();
            this.txtCategory = new System.Windows.Forms.NumericUpDown();
            this.btnScanImages = new System.Windows.Forms.Button();
            this.btnScanMoreImages = new System.Windows.Forms.Button();
            this.btnScanMuaDefaultProperties = new System.Windows.Forms.Button();
            this.btnScanMuaDefaultPropertiesFull = new System.Windows.Forms.Button();
            this.btnCreateCategoriesFromDB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Scan azeri sites";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(0, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Scan m.ua";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(0, 186);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Scan m.ua local";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(81, 91);
            this.txtFrom.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.txtFrom.Minimum = new decimal(new int[] {
            100001,
            0,
            0,
            0});
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(120, 20);
            this.txtFrom.TabIndex = 3;
            this.txtFrom.Value = new decimal(new int[] {
            100001,
            0,
            0,
            0});
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.Location = new System.Drawing.Point(108, 186);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(142, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Scan m.ua local properties";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtDirection
            // 
            this.txtDirection.Location = new System.Drawing.Point(333, 91);
            this.txtDirection.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDirection.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txtDirection.Name = "txtDirection";
            this.txtDirection.Size = new System.Drawing.Size(41, 20);
            this.txtDirection.TabIndex = 5;
            this.txtDirection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(207, 91);
            this.txtTo.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.txtTo.Minimum = new decimal(new int[] {
            100001,
            0,
            0,
            0});
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(120, 20);
            this.txtTo.TabIndex = 6;
            this.txtTo.Value = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            // 
            // txtCategory
            // 
            this.txtCategory.Location = new System.Drawing.Point(268, 186);
            this.txtCategory.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(120, 20);
            this.txtCategory.TabIndex = 7;
            // 
            // btnScanImages
            // 
            this.btnScanImages.AutoSize = true;
            this.btnScanImages.Location = new System.Drawing.Point(2, 266);
            this.btnScanImages.Name = "btnScanImages";
            this.btnScanImages.Size = new System.Drawing.Size(91, 23);
            this.btnScanImages.TabIndex = 8;
            this.btnScanImages.Text = "Scan images";
            this.btnScanImages.UseVisualStyleBackColor = true;
            this.btnScanImages.Click += new System.EventHandler(this.btnScanImages_Click);
            // 
            // btnScanMoreImages
            // 
            this.btnScanMoreImages.AutoSize = true;
            this.btnScanMoreImages.Location = new System.Drawing.Point(110, 266);
            this.btnScanMoreImages.Name = "btnScanMoreImages";
            this.btnScanMoreImages.Size = new System.Drawing.Size(104, 23);
            this.btnScanMoreImages.TabIndex = 9;
            this.btnScanMoreImages.Text = "Scan more images";
            this.btnScanMoreImages.UseVisualStyleBackColor = true;
            this.btnScanMoreImages.Click += new System.EventHandler(this.btnScanMoreImages_Click);
            // 
            // btnScanMuaDefaultProperties
            // 
            this.btnScanMuaDefaultProperties.AutoSize = true;
            this.btnScanMuaDefaultProperties.Location = new System.Drawing.Point(2, 120);
            this.btnScanMuaDefaultProperties.Name = "btnScanMuaDefaultProperties";
            this.btnScanMuaDefaultProperties.Size = new System.Drawing.Size(171, 23);
            this.btnScanMuaDefaultProperties.TabIndex = 10;
            this.btnScanMuaDefaultProperties.Text = "Scan m.ua default properties";
            this.btnScanMuaDefaultProperties.UseVisualStyleBackColor = true;
            this.btnScanMuaDefaultProperties.Click += new System.EventHandler(this.btnScanMuaDefaultProperties_Click);
            // 
            // btnScanMuaDefaultPropertiesFull
            // 
            this.btnScanMuaDefaultPropertiesFull.AutoSize = true;
            this.btnScanMuaDefaultPropertiesFull.Location = new System.Drawing.Point(2, 149);
            this.btnScanMuaDefaultPropertiesFull.Name = "btnScanMuaDefaultPropertiesFull";
            this.btnScanMuaDefaultPropertiesFull.Size = new System.Drawing.Size(280, 23);
            this.btnScanMuaDefaultPropertiesFull.TabIndex = 11;
            this.btnScanMuaDefaultPropertiesFull.Text = "Scan m.ua default properties FULL";
            this.btnScanMuaDefaultPropertiesFull.UseVisualStyleBackColor = true;
            this.btnScanMuaDefaultPropertiesFull.Click += new System.EventHandler(this.btnScanMuaDefaultPropertiesFull_Click);
            // 
            // btnCreateCategoriesFromDB
            // 
            this.btnCreateCategoriesFromDB.AutoSize = true;
            this.btnCreateCategoriesFromDB.Location = new System.Drawing.Point(2, 344);
            this.btnCreateCategoriesFromDB.Name = "btnCreateCategoriesFromDB";
            this.btnCreateCategoriesFromDB.Size = new System.Drawing.Size(136, 23);
            this.btnCreateCategoriesFromDB.TabIndex = 12;
            this.btnCreateCategoriesFromDB.Text = "CreateCategoriesFromDB";
            this.btnCreateCategoriesFromDB.UseVisualStyleBackColor = true;
            this.btnCreateCategoriesFromDB.Click += new System.EventHandler(this.btnCreateCategoriesFromDB_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 420);
            this.Controls.Add(this.btnCreateCategoriesFromDB);
            this.Controls.Add(this.btnScanMuaDefaultPropertiesFull);
            this.Controls.Add(this.btnScanMuaDefaultProperties);
            this.Controls.Add(this.btnScanMoreImages);
            this.Controls.Add(this.btnScanImages);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtDirection);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.NumericUpDown txtFrom;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown txtDirection;
        private System.Windows.Forms.NumericUpDown txtTo;
        private System.Windows.Forms.NumericUpDown txtCategory;
        private System.Windows.Forms.Button btnScanImages;
        private System.Windows.Forms.Button btnScanMoreImages;
        private System.Windows.Forms.Button btnScanMuaDefaultProperties;
        private System.Windows.Forms.Button btnScanMuaDefaultPropertiesFull;
        private System.Windows.Forms.Button btnCreateCategoriesFromDB;
    }
}

