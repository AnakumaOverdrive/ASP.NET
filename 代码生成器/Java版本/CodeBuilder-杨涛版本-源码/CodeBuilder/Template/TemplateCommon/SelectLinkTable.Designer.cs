namespace Esint.TemplateCommon
{
    partial class SelectLinkTable
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
            this.gv_SubTable = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.cbx_MasterTable = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_BM = new System.Windows.Forms.TextBox();
            this.cbx_MasterCols = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbx_SubCols = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Filter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_TableName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gv_SubTable)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_SubTable
            // 
            this.gv_SubTable.AllowUserToAddRows = false;
            this.gv_SubTable.AllowUserToDeleteRows = false;
            this.gv_SubTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_SubTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3});
            this.gv_SubTable.Location = new System.Drawing.Point(12, 44);
            this.gv_SubTable.Name = "gv_SubTable";
            this.gv_SubTable.RowTemplate.Height = 23;
            this.gv_SubTable.Size = new System.Drawing.Size(706, 215);
            this.gv_SubTable.TabIndex = 1;
            this.gv_SubTable.SelectionChanged += new System.EventHandler(this.gv_SubTable_SelectionChanged);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TableName";
            this.Column2.FillWeight = 200F;
            this.Column2.HeaderText = "表名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TableDescription";
            this.Column3.FillWeight = 400F;
            this.Column3.HeaderText = "表含义";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 400;
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(554, 403);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 2;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(643, 403);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // cbx_MasterTable
            // 
            this.cbx_MasterTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_MasterTable.FormattingEnabled = true;
            this.cbx_MasterTable.Location = new System.Drawing.Point(78, 336);
            this.cbx_MasterTable.Name = "cbx_MasterTable";
            this.cbx_MasterTable.Size = new System.Drawing.Size(212, 20);
            this.cbx_MasterTable.TabIndex = 3;
            this.cbx_MasterTable.SelectedIndexChanged += new System.EventHandler(this.cbx_MasterTable_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "连接方式:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "连接主表:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Inner Join",
            "Left Join",
            "Right Join",
            "Full Join"});
            this.comboBox2.Location = new System.Drawing.Point(469, 335);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(191, 20);
            this.comboBox2.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "子表别名:";
            // 
            // txt_BM
            // 
            this.txt_BM.Location = new System.Drawing.Point(78, 274);
            this.txt_BM.Name = "txt_BM";
            this.txt_BM.Size = new System.Drawing.Size(212, 21);
            this.txt_BM.TabIndex = 5;
            // 
            // cbx_MasterCols
            // 
            this.cbx_MasterCols.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_MasterCols.FormattingEnabled = true;
            this.cbx_MasterCols.Location = new System.Drawing.Point(78, 366);
            this.cbx_MasterCols.Name = "cbx_MasterCols";
            this.cbx_MasterCols.Size = new System.Drawing.Size(211, 20);
            this.cbx_MasterCols.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "主表字段:";
            // 
            // cbx_SubCols
            // 
            this.cbx_SubCols.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_SubCols.FormattingEnabled = true;
            this.cbx_SubCols.Location = new System.Drawing.Point(469, 366);
            this.cbx_SubCols.Name = "cbx_SubCols";
            this.cbx_SubCols.Size = new System.Drawing.Size(191, 20);
            this.cbx_SubCols.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(404, 370);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "子表字段:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "过滤条件:";
            // 
            // txt_Filter
            // 
            this.txt_Filter.Location = new System.Drawing.Point(78, 305);
            this.txt_Filter.Name = "txt_Filter";
            this.txt_Filter.Size = new System.Drawing.Size(582, 21);
            this.txt_Filter.TabIndex = 7;
         
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "表名：";
            // 
            // txt_TableName
            // 
            this.txt_TableName.Location = new System.Drawing.Point(62, 12);
            this.txt_TableName.Name = "txt_TableName";
            this.txt_TableName.Size = new System.Drawing.Size(194, 21);
            this.txt_TableName.TabIndex = 9;
            this.txt_TableName.TextChanged += new System.EventHandler(this.txt_TableName_TextChanged);
            // 
            // SelectLinkTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 482);
            this.Controls.Add(this.txt_TableName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_Filter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_BM);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.cbx_SubCols);
            this.Controls.Add(this.cbx_MasterCols);
            this.Controls.Add(this.cbx_MasterTable);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.gv_SubTable);
            this.Name = "SelectLinkTable";
            this.Text = "选择关联数据表";
            ((System.ComponentModel.ISupportInitialize)(this.gv_SubTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_SubTable;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ComboBox cbx_MasterTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_BM;
        private System.Windows.Forms.ComboBox cbx_MasterCols;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbx_SubCols;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Filter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_TableName;
    }
}