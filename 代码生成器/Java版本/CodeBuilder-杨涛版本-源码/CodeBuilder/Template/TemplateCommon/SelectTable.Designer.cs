namespace Esint.TemplateCommon
{
    partial class SelectTable
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
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.txt_TableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gv_SubTable)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_SubTable
            // 
            this.gv_SubTable.AllowUserToAddRows = false;
            this.gv_SubTable.AllowUserToDeleteRows = false;
            this.gv_SubTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_SubTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.gv_SubTable.Location = new System.Drawing.Point(12, 61);
            this.gv_SubTable.Name = "gv_SubTable";
            this.gv_SubTable.RowTemplate.Height = 23;
            this.gv_SubTable.Size = new System.Drawing.Size(706, 341);
            this.gv_SubTable.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.FalseValue = "0";
            this.Column1.FillWeight = 40F;
            this.Column1.HeaderText = "选择";
            this.Column1.Name = "Column1";
            this.Column1.TrueValue = "1";
            this.Column1.Width = 40;
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
            this.btn_Ok.Location = new System.Drawing.Point(554, 420);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 2;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(643, 420);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // txt_TableName
            // 
            this.txt_TableName.Location = new System.Drawing.Point(70, 23);
            this.txt_TableName.Name = "txt_TableName";
            this.txt_TableName.Size = new System.Drawing.Size(214, 21);
            this.txt_TableName.TabIndex = 3;
            this.txt_TableName.TextChanged += new System.EventHandler(this.txt_TableName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "表名:";
            // 
            // SelectTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 455);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_TableName);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.gv_SubTable);
            this.Name = "SelectTable";
            this.Text = "SelectTable";
            ((System.ComponentModel.ISupportInitialize)(this.gv_SubTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_SubTable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox txt_TableName;
        private System.Windows.Forms.Label label1;
    }
}