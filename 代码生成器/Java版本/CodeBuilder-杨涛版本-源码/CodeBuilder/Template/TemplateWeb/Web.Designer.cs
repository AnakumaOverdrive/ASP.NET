namespace Esint.Template.TemplateWeb
{
    partial class Web
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.gv_Setting = new System.Windows.Forms.DataGridView();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.C2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.c5 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.C4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cbx_Cols = new System.Windows.Forms.ComboBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ControlName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Setting)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(771, 74);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(771, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gv_Setting
            // 
            this.gv_Setting.AllowDrop = true;
            this.gv_Setting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gv_Setting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gv_Setting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_Setting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.C1,
            this.C2,
            this.C3,
            this.c5,
            this.C4,
            this.Column1});
            this.gv_Setting.Location = new System.Drawing.Point(12, 36);
            this.gv_Setting.Name = "gv_Setting";
            this.gv_Setting.RowTemplate.Height = 23;
            this.gv_Setting.Size = new System.Drawing.Size(746, 259);
            this.gv_Setting.TabIndex = 5;
            this.gv_Setting.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_Setting_CellValueChanged);
            this.gv_Setting.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_Setting_CellMouseDown);
            this.gv_Setting.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_Setting_CellMouseMove);
            this.gv_Setting.DragEnter += new System.Windows.Forms.DragEventHandler(this.gv_Setting_DragEnter);
            this.gv_Setting.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gv_Setting_DataError);
            this.gv_Setting.SelectionChanged += new System.EventHandler(this.gv_Setting_SelectionChanged);
            this.gv_Setting.DragDrop += new System.Windows.Forms.DragEventHandler(this.gv_Setting_DragDrop);
            // 
            // ColName
            // 
            this.ColName.Frozen = true;
            this.ColName.HeaderText = "Column1";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            this.ColName.Visible = false;
            // 
            // C1
            // 
            this.C1.Frozen = true;
            this.C1.HeaderText = "选择";
            this.C1.Name = "C1";
            this.C1.Width = 40;
            // 
            // C2
            // 
            this.C2.Frozen = true;
            this.C2.HeaderText = "B标签含义";
            this.C2.Name = "C2";
            // 
            // C3
            // 
            this.C3.Frozen = true;
            this.C3.HeaderText = "控件";
            this.C3.Items.AddRange(new object[] {
            "W文本框",
            "X下拉框",
            "R日期框",
            "F复选框",
            "Y隐藏域",
            "B标签",
            "D多行文本框"});
            this.C3.Name = "C3";
            // 
            // c5
            // 
            this.c5.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.c5.Frozen = true;
            this.c5.HeaderText = "代码项";
            this.c5.MaxDropDownItems = 30;
            this.c5.Name = "c5";
            this.c5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c5.Width = 150;
            // 
            // C4
            // 
            this.C4.Frozen = true;
            this.C4.HeaderText = "必填";
            this.C4.Name = "C4";
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "跨列";
            this.Column1.Items.AddRange(new object[] {
            "一列"});
            this.Column1.Name = "Column1";
            // 
            // cbx_Cols
            // 
            this.cbx_Cols.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_Cols.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Cols.FormattingEnabled = true;
            this.cbx_Cols.Items.AddRange(new object[] {
            "一列",
            "二列",
            "三列",
            "四列"});
            this.cbx_Cols.Location = new System.Drawing.Point(770, 128);
            this.cbx_Cols.Name = "cbx_Cols";
            this.cbx_Cols.Size = new System.Drawing.Size(77, 20);
            this.cbx_Cols.TabIndex = 6;
            this.cbx_Cols.SelectedIndexChanged += new System.EventHandler(this.cbx_Cols_SelectedIndexChanged);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 288);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(746, 295);
            this.webBrowser1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "控件名称：";
            // 
            // txt_ControlName
            // 
            this.txt_ControlName.Location = new System.Drawing.Point(80, 7);
            this.txt_ControlName.Name = "txt_ControlName";
            this.txt_ControlName.Size = new System.Drawing.Size(209, 21);
            this.txt_ControlName.TabIndex = 9;
            // 
            // Web
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 607);
            this.Controls.Add(this.txt_ControlName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.cbx_Cols);
            this.Controls.Add(this.gv_Setting);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Web";
            this.Text = "Web";
            ((System.ComponentModel.ISupportInitialize)(this.gv_Setting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView gv_Setting;
        private System.Windows.Forms.ComboBox cbx_Cols;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn C1;
        private System.Windows.Forms.DataGridViewTextBoxColumn C2;
        private System.Windows.Forms.DataGridViewComboBoxColumn C3;
        private System.Windows.Forms.DataGridViewComboBoxColumn c5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn C4;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ControlName;

    }
}