namespace Esint.Template.Model
{
    partial class Mapper_Model
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
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_AddTable = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_BaseModel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gv_SubTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_Label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_IsNull = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.p_len = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_regx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p_regx_list = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_SubTable)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(634, 488);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 2;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(715, 488);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(789, 461);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(781, 435);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "实体属性";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.p_Name,
            this.p_Label,
            this.p_IsNull,
            this.p_len,
            this.p_regx,
            this.p_regx_list});
            this.dataGridView1.Location = new System.Drawing.Point(7, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(767, 410);
            this.dataGridView1.TabIndex = 0;
           // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_AddTable);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cbx_BaseModel);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.gv_SubTable);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(781, 435);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "关联实体";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_AddTable
            // 
            this.btn_AddTable.Location = new System.Drawing.Point(696, 392);
            this.btn_AddTable.Name = "btn_AddTable";
            this.btn_AddTable.Size = new System.Drawing.Size(75, 23);
            this.btn_AddTable.TabIndex = 9;
            this.btn_AddTable.Text = "添加表";
            this.btn_AddTable.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(422, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "父类：";
            // 
            // cbx_BaseModel
            // 
            this.cbx_BaseModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_BaseModel.FormattingEnabled = true;
            this.cbx_BaseModel.Location = new System.Drawing.Point(469, 13);
            this.cbx_BaseModel.Name = "cbx_BaseModel";
            this.cbx_BaseModel.Size = new System.Drawing.Size(222, 20);
            this.cbx_BaseModel.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "关联子表:";
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
            this.gv_SubTable.Location = new System.Drawing.Point(8, 48);
            this.gv_SubTable.Name = "gv_SubTable";
            this.gv_SubTable.RowTemplate.Height = 23;
            this.gv_SubTable.Size = new System.Drawing.Size(766, 335);
            this.gv_SubTable.TabIndex = 5;
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
            // p_Name
            // 
            this.p_Name.HeaderText = "属性名";
            this.p_Name.Name = "p_Name";
            // 
            // p_Label
            // 
            this.p_Label.HeaderText = "标签";
            this.p_Label.Name = "p_Label";
            this.p_Label.Width = 150;
            // 
            // p_IsNull
            // 
            this.p_IsNull.HeaderText = "非空";
            this.p_IsNull.Name = "p_IsNull";
            this.p_IsNull.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.p_IsNull.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.p_IsNull.Width = 60;
            // 
            // p_len
            // 
            this.p_len.HeaderText = "最大长度";
            this.p_len.Name = "p_len";
            this.p_len.Width = 80;
            // 
            // p_regx
            // 
            this.p_regx.HeaderText = "正则表达式";
            this.p_regx.Name = "p_regx";
            this.p_regx.Width = 200;
            // 
            // p_regx_list
            // 
            this.p_regx_list.HeaderText = "常用正则";
            this.p_regx_list.Name = "p_regx_list";
            this.p_regx_list.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.p_regx_list.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Ef_Model
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 523);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Name = "Ef_Model";
            this.Text = "Model层生成模板 V1.0";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_SubTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_AddTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_BaseModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gv_SubTable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_Label;
        private System.Windows.Forms.DataGridViewCheckBoxColumn p_IsNull;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_len;
        private System.Windows.Forms.DataGridViewTextBoxColumn p_regx;
        private System.Windows.Forms.DataGridViewComboBoxColumn p_regx_list;
    }
}