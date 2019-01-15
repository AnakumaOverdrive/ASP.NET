namespace Esint.Template.Model
{
    partial class Model_01
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_AddTable = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.cbx_BaseModel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.gv_SubTable.Location = new System.Drawing.Point(30, 61);
            this.gv_SubTable.Name = "gv_SubTable";
            this.gv_SubTable.RowTemplate.Height = 23;
            this.gv_SubTable.Size = new System.Drawing.Size(683, 307);
            this.gv_SubTable.TabIndex = 0;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "关联子表:";
            // 
            // btn_AddTable
            // 
            this.btn_AddTable.Location = new System.Drawing.Point(638, 413);
            this.btn_AddTable.Name = "btn_AddTable";
            this.btn_AddTable.Size = new System.Drawing.Size(75, 23);
            this.btn_AddTable.TabIndex = 2;
            this.btn_AddTable.Text = "添加表";
            this.btn_AddTable.UseVisualStyleBackColor = true;
            this.btn_AddTable.Click += new System.EventHandler(this.btn_AddTable_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(557, 459);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 2;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(638, 459);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // cbx_BaseModel
            // 
            this.cbx_BaseModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_BaseModel.FormattingEnabled = true;
            this.cbx_BaseModel.Location = new System.Drawing.Point(491, 26);
            this.cbx_BaseModel.Name = "cbx_BaseModel";
            this.cbx_BaseModel.Size = new System.Drawing.Size(222, 20);
            this.cbx_BaseModel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(444, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "父类：";
            // 
            // Model_01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 504);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_BaseModel);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.btn_AddTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gv_SubTable);
            this.Name = "Model_01";
            this.Text = "Model层生成模板 V1.0";
            ((System.ComponentModel.ISupportInitialize)(this.gv_SubTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_SubTable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_AddTable;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ComboBox cbx_BaseModel;
        private System.Windows.Forms.Label label2;
    }
}