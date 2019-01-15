namespace Esint.Template.TemplateWeb 
{
    partial class WebListJAVA
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_SelectTable = new System.Windows.Forms.TabPage();
            this.txt_MainTableAlias = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_MasterTableName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_AddTable = new System.Windows.Forms.Button();
            this.gv_SubTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tp_SelectField = new System.Windows.Forms.TabPage();
            this.gv_Cols = new System.Windows.Forms.DataGridView();
            this.col_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Import = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Meaning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Field = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Alias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_TableAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_IsCode = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_Code = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tp_SelectWhere = new System.Windows.Forms.TabPage();
            this.gv_ColsWhere = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_copy = new System.Windows.Forms.Button();
            this.txt_SqlText = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_FileName = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbx_IsImp = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_ImpRows = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbx_Page = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_PageSize = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbx_IsCheck = new System.Windows.Forms.CheckBox();
            this.cbx_IsNum = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_IsDelete = new System.Windows.Forms.CheckBox();
            this.cbx_IsEdit = new System.Windows.Forms.CheckBox();
            this.btn_BuilderCode = new System.Windows.Forms.Button();
            this.cbx_IsWhere = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_MName = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tp_SelectTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_SubTable)).BeginInit();
            this.tp_SelectField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Cols)).BeginInit();
            this.tp_SelectWhere.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_ColsWhere)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tp_SelectTable);
            this.tabControl1.Controls.Add(this.tp_SelectField);
            this.tabControl1.Controls.Add(this.tp_SelectWhere);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(816, 501);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tp_SelectTable
            // 
            this.tp_SelectTable.Controls.Add(this.txt_MainTableAlias);
            this.tp_SelectTable.Controls.Add(this.label3);
            this.tp_SelectTable.Controls.Add(this.lbl_MasterTableName);
            this.tp_SelectTable.Controls.Add(this.label1);
            this.tp_SelectTable.Controls.Add(this.btn_AddTable);
            this.tp_SelectTable.Controls.Add(this.gv_SubTable);
            this.tp_SelectTable.Location = new System.Drawing.Point(4, 22);
            this.tp_SelectTable.Name = "tp_SelectTable";
            this.tp_SelectTable.Padding = new System.Windows.Forms.Padding(3);
            this.tp_SelectTable.Size = new System.Drawing.Size(808, 475);
            this.tp_SelectTable.TabIndex = 0;
            this.tp_SelectTable.Text = "选择关联表";
            this.tp_SelectTable.UseVisualStyleBackColor = true;
            // 
            // txt_MainTableAlias
            // 
            this.txt_MainTableAlias.Location = new System.Drawing.Point(475, 16);
            this.txt_MainTableAlias.Name = "txt_MainTableAlias";
            this.txt_MainTableAlias.Size = new System.Drawing.Size(100, 21);
            this.txt_MainTableAlias.TabIndex = 3;
            this.txt_MainTableAlias.TextChanged += new System.EventHandler(this.txt_MainTableAlias_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "别名:";
            // 
            // lbl_MasterTableName
            // 
            this.lbl_MasterTableName.AutoSize = true;
            this.lbl_MasterTableName.Location = new System.Drawing.Point(93, 19);
            this.lbl_MasterTableName.Name = "lbl_MasterTableName";
            this.lbl_MasterTableName.Size = new System.Drawing.Size(59, 12);
            this.lbl_MasterTableName.TabIndex = 2;
            this.lbl_MasterTableName.Text = "主表表名:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "主表表名:";
            // 
            // btn_AddTable
            // 
            this.btn_AddTable.Location = new System.Drawing.Point(718, 408);
            this.btn_AddTable.Name = "btn_AddTable";
            this.btn_AddTable.Size = new System.Drawing.Size(75, 23);
            this.btn_AddTable.TabIndex = 1;
            this.btn_AddTable.Text = "添加表";
            this.btn_AddTable.UseVisualStyleBackColor = true;
            this.btn_AddTable.Click += new System.EventHandler(this.btn_AddTable_Click);
            // 
            // gv_SubTable
            // 
            this.gv_SubTable.AllowUserToAddRows = false;
            this.gv_SubTable.AllowUserToOrderColumns = true;
            this.gv_SubTable.AllowUserToResizeRows = false;
            this.gv_SubTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_SubTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column14});
            this.gv_SubTable.Location = new System.Drawing.Point(7, 52);
            this.gv_SubTable.Name = "gv_SubTable";
            this.gv_SubTable.RowTemplate.Height = 23;
            this.gv_SubTable.Size = new System.Drawing.Size(786, 321);
            this.gv_SubTable.TabIndex = 0;
            this.gv_SubTable.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gv_SubTable_CellBeginEdit);
            this.gv_SubTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_SubTable_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "选择";
            this.Column1.Name = "Column1";
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "连接方式";
            this.Column2.Items.AddRange(new object[] {
            "Inner Join",
            "Left Join",
            "Right Join",
            "Full Join"});
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "子表名称";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "别名";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "ON关联条件";
            this.Column5.Name = "Column5";
            this.Column5.Width = 350;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "子表过滤";
            this.Column14.Name = "Column14";
            // 
            // tp_SelectField
            // 
            this.tp_SelectField.Controls.Add(this.gv_Cols);
            this.tp_SelectField.Location = new System.Drawing.Point(4, 22);
            this.tp_SelectField.Name = "tp_SelectField";
            this.tp_SelectField.Padding = new System.Windows.Forms.Padding(3);
            this.tp_SelectField.Size = new System.Drawing.Size(808, 475);
            this.tp_SelectField.TabIndex = 1;
            this.tp_SelectField.Text = "选择字段";
            this.tp_SelectField.UseVisualStyleBackColor = true;
            // 
            // gv_Cols
            // 
            this.gv_Cols.AllowDrop = true;
            this.gv_Cols.AllowUserToAddRows = false;
            this.gv_Cols.AllowUserToDeleteRows = false;
            this.gv_Cols.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_Cols.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Select,
            this.col_Import,
            this.col_Meaning,
            this.col_Field,
            this.col_Alias,
            this.col_TableName,
            this.col_TableAlias,
            this.col_IsCode,
            this.col_Code});
            this.gv_Cols.Location = new System.Drawing.Point(6, 6);
            this.gv_Cols.Name = "gv_Cols";
            this.gv_Cols.RowTemplate.Height = 23;
            this.gv_Cols.Size = new System.Drawing.Size(796, 453);
            this.gv_Cols.TabIndex = 0;
            this.gv_Cols.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_Cols_CellMouseDown);
            this.gv_Cols.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_Cols_CellMouseMove);
            this.gv_Cols.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_Cols_CellValueChanged);
            this.gv_Cols.SelectionChanged += new System.EventHandler(this.gv_Cols_SelectionChanged);
            this.gv_Cols.DragDrop += new System.Windows.Forms.DragEventHandler(this.gv_Cols_DragDrop);
            this.gv_Cols.DragEnter += new System.Windows.Forms.DragEventHandler(this.gv_Cols_DragEnter);
            // 
            // col_Select
            // 
            this.col_Select.HeaderText = "选择";
            this.col_Select.Name = "col_Select";
            this.col_Select.Width = 40;
            // 
            // col_Import
            // 
            this.col_Import.HeaderText = "导出";
            this.col_Import.Name = "col_Import";
            this.col_Import.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_Import.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_Import.Width = 40;
            // 
            // col_Meaning
            // 
            this.col_Meaning.HeaderText = "字段含义";
            this.col_Meaning.Name = "col_Meaning";
            this.col_Meaning.Width = 130;
            // 
            // col_Field
            // 
            this.col_Field.HeaderText = "字段名";
            this.col_Field.Name = "col_Field";
            // 
            // col_Alias
            // 
            this.col_Alias.HeaderText = "字段别名";
            this.col_Alias.Name = "col_Alias";
            // 
            // col_TableName
            // 
            this.col_TableName.HeaderText = "表名";
            this.col_TableName.Name = "col_TableName";
            this.col_TableName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_TableName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_TableAlias
            // 
            this.col_TableAlias.HeaderText = "别名";
            this.col_TableAlias.MinimumWidth = 50;
            this.col_TableAlias.Name = "col_TableAlias";
            this.col_TableAlias.Width = 60;
            // 
            // col_IsCode
            // 
            this.col_IsCode.HeaderText = "是否代码";
            this.col_IsCode.Name = "col_IsCode";
            this.col_IsCode.Width = 40;
            // 
            // col_Code
            // 
            this.col_Code.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.col_Code.HeaderText = "代码";
            this.col_Code.Name = "col_Code";
            this.col_Code.ToolTipText = "代码表中字段";
            this.col_Code.Width = 140;
            // 
            // tp_SelectWhere
            // 
            this.tp_SelectWhere.Controls.Add(this.gv_ColsWhere);
            this.tp_SelectWhere.Location = new System.Drawing.Point(4, 22);
            this.tp_SelectWhere.Name = "tp_SelectWhere";
            this.tp_SelectWhere.Padding = new System.Windows.Forms.Padding(3);
            this.tp_SelectWhere.Size = new System.Drawing.Size(808, 475);
            this.tp_SelectWhere.TabIndex = 2;
            this.tp_SelectWhere.Text = "选择条件";
            this.tp_SelectWhere.UseVisualStyleBackColor = true;
            // 
            // gv_ColsWhere
            // 
            this.gv_ColsWhere.AllowDrop = true;
            this.gv_ColsWhere.AllowUserToAddRows = false;
            this.gv_ColsWhere.AllowUserToDeleteRows = false;
            this.gv_ColsWhere.AllowUserToResizeColumns = false;
            this.gv_ColsWhere.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_ColsWhere.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewComboBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.Column12,
            this.Column13});
            this.gv_ColsWhere.Location = new System.Drawing.Point(6, 6);
            this.gv_ColsWhere.Name = "gv_ColsWhere";
            this.gv_ColsWhere.RowTemplate.Height = 23;
            this.gv_ColsWhere.Size = new System.Drawing.Size(796, 453);
            this.gv_ColsWhere.TabIndex = 1;
            this.gv_ColsWhere.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_ColsWhere_CellEndEdit);
            this.gv_ColsWhere.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_ColsWhere_CellMouseDown);
            this.gv_ColsWhere.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_ColsWhere_CellMouseMove);
            this.gv_ColsWhere.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_ColsWhere_CellValueChanged);
            this.gv_ColsWhere.SelectionChanged += new System.EventHandler(this.gv_ColsWhere_SelectionChanged);
            this.gv_ColsWhere.DragDrop += new System.Windows.Forms.DragEventHandler(this.gv_ColsWhere_DragDrop);
            this.gv_ColsWhere.DragEnter += new System.Windows.Forms.DragEventHandler(this.gv_ColsWhere_DragEnter);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "选择";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 40;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "显示";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "字段含义";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "字段名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "别名";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "表名";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.HeaderText = "条件";
            this.dataGridViewComboBoxColumn1.Items.AddRange(new object[] {
            "=",
            "Like",
            ">",
            ">=",
            "<",
            "<=",
            "!="});
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "值";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 40;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "控件类型";
            this.Column12.Items.AddRange(new object[] {
            "W文本框",
            "X下拉框",
            "R日期框"});
            this.Column12.Name = "Column12";
            this.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column12.Width = 80;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "代码项";
            this.Column13.Name = "Column13";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_copy);
            this.tabPage2.Controls.Add(this.txt_SqlText);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(808, 475);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "SQL语句";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_copy
            // 
            this.btn_copy.Location = new System.Drawing.Point(715, 357);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(75, 23);
            this.btn_copy.TabIndex = 1;
            this.btn_copy.Text = "复制";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // txt_SqlText
            // 
            this.txt_SqlText.Location = new System.Drawing.Point(7, 7);
            this.txt_SqlText.Multiline = true;
            this.txt_SqlText.Name = "txt_SqlText";
            this.txt_SqlText.Size = new System.Drawing.Size(783, 344);
            this.txt_SqlText.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_MName);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txt_FileName);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btn_BuilderCode);
            this.tabPage1.Controls.Add(this.cbx_IsWhere);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(808, 475);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "其它设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "文件名：";
            // 
            // txt_FileName
            // 
            this.txt_FileName.Location = new System.Drawing.Point(316, 18);
            this.txt_FileName.Name = "txt_FileName";
            this.txt_FileName.Size = new System.Drawing.Size(429, 21);
            this.txt_FileName.TabIndex = 8;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbx_IsImp);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.txt_ImpRows);
            this.groupBox5.Location = new System.Drawing.Point(27, 350);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 100);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "导出Excel";
            // 
            // cbx_IsImp
            // 
            this.cbx_IsImp.AutoSize = true;
            this.cbx_IsImp.Checked = true;
            this.cbx_IsImp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_IsImp.Location = new System.Drawing.Point(18, 20);
            this.cbx_IsImp.Name = "cbx_IsImp";
            this.cbx_IsImp.Size = new System.Drawing.Size(96, 16);
            this.cbx_IsImp.TabIndex = 0;
            this.cbx_IsImp.Text = "是否生成导出";
            this.cbx_IsImp.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "行";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "导出行限制";
            // 
            // txt_ImpRows
            // 
            this.txt_ImpRows.Location = new System.Drawing.Point(83, 57);
            this.txt_ImpRows.Name = "txt_ImpRows";
            this.txt_ImpRows.Size = new System.Drawing.Size(69, 21);
            this.txt_ImpRows.TabIndex = 3;
            this.txt_ImpRows.Text = "60000";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbx_Page);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txt_PageSize);
            this.groupBox3.Location = new System.Drawing.Point(27, 239);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "分页";
            // 
            // cbx_Page
            // 
            this.cbx_Page.AutoSize = true;
            this.cbx_Page.Checked = true;
            this.cbx_Page.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_Page.Location = new System.Drawing.Point(18, 20);
            this.cbx_Page.Name = "cbx_Page";
            this.cbx_Page.Size = new System.Drawing.Size(96, 16);
            this.cbx_Page.TabIndex = 0;
            this.cbx_Page.Text = "是否分页查询";
            this.cbx_Page.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "行";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "每页";
            // 
            // txt_PageSize
            // 
            this.txt_PageSize.Location = new System.Drawing.Point(50, 57);
            this.txt_PageSize.Name = "txt_PageSize";
            this.txt_PageSize.Size = new System.Drawing.Size(69, 21);
            this.txt_PageSize.TabIndex = 3;
            this.txt_PageSize.Text = "10";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbx_IsCheck);
            this.groupBox2.Controls.Add(this.cbx_IsNum);
            this.groupBox2.Location = new System.Drawing.Point(27, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 87);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "行头";
            // 
            // cbx_IsCheck
            // 
            this.cbx_IsCheck.AutoSize = true;
            this.cbx_IsCheck.Location = new System.Drawing.Point(27, 42);
            this.cbx_IsCheck.Name = "cbx_IsCheck";
            this.cbx_IsCheck.Size = new System.Drawing.Size(66, 16);
            this.cbx_IsCheck.TabIndex = 0;
            this.cbx_IsCheck.Text = "F复选框";
            this.cbx_IsCheck.UseVisualStyleBackColor = true;
            // 
            // cbx_IsNum
            // 
            this.cbx_IsNum.AutoSize = true;
            this.cbx_IsNum.Checked = true;
            this.cbx_IsNum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_IsNum.Location = new System.Drawing.Point(111, 42);
            this.cbx_IsNum.Name = "cbx_IsNum";
            this.cbx_IsNum.Size = new System.Drawing.Size(60, 16);
            this.cbx_IsNum.TabIndex = 0;
            this.cbx_IsNum.Text = "序号列";
            this.cbx_IsNum.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_IsDelete);
            this.groupBox1.Controls.Add(this.cbx_IsEdit);
            this.groupBox1.Location = new System.Drawing.Point(27, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 87);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作列";
            // 
            // cbx_IsDelete
            // 
            this.cbx_IsDelete.AutoSize = true;
            this.cbx_IsDelete.Checked = true;
            this.cbx_IsDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_IsDelete.Location = new System.Drawing.Point(94, 42);
            this.cbx_IsDelete.Name = "cbx_IsDelete";
            this.cbx_IsDelete.Size = new System.Drawing.Size(48, 16);
            this.cbx_IsDelete.TabIndex = 0;
            this.cbx_IsDelete.Text = "删除";
            this.cbx_IsDelete.UseVisualStyleBackColor = true;
            // 
            // cbx_IsEdit
            // 
            this.cbx_IsEdit.AutoSize = true;
            this.cbx_IsEdit.Checked = true;
            this.cbx_IsEdit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_IsEdit.Location = new System.Drawing.Point(21, 42);
            this.cbx_IsEdit.Name = "cbx_IsEdit";
            this.cbx_IsEdit.Size = new System.Drawing.Size(48, 16);
            this.cbx_IsEdit.TabIndex = 0;
            this.cbx_IsEdit.Text = "修改";
            this.cbx_IsEdit.UseVisualStyleBackColor = true;
            // 
            // btn_BuilderCode
            // 
            this.btn_BuilderCode.Location = new System.Drawing.Point(710, 427);
            this.btn_BuilderCode.Name = "btn_BuilderCode";
            this.btn_BuilderCode.Size = new System.Drawing.Size(75, 23);
            this.btn_BuilderCode.TabIndex = 1;
            this.btn_BuilderCode.Text = "生成代码";
            this.btn_BuilderCode.UseVisualStyleBackColor = true;
            this.btn_BuilderCode.Click += new System.EventHandler(this.btn_BuilderCode_Click);
            // 
            // cbx_IsWhere
            // 
            this.cbx_IsWhere.AutoSize = true;
            this.cbx_IsWhere.Checked = true;
            this.cbx_IsWhere.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_IsWhere.Location = new System.Drawing.Point(27, 18);
            this.cbx_IsWhere.Name = "cbx_IsWhere";
            this.cbx_IsWhere.Size = new System.Drawing.Size(96, 16);
            this.cbx_IsWhere.TabIndex = 0;
            this.cbx_IsWhere.Text = "是否有查询项";
            this.cbx_IsWhere.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(246, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "模块名：";
            // 
            // txt_MName
            // 
            this.txt_MName.Location = new System.Drawing.Point(316, 87);
            this.txt_MName.Name = "txt_MName";
            this.txt_MName.Size = new System.Drawing.Size(429, 21);
            this.txt_MName.TabIndex = 11;
            // 
            // WebListJAVA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 532);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Name = "WebListJAVA";
            this.Text = "Web窗体列表页生成配置";
            this.tabControl1.ResumeLayout(false);
            this.tp_SelectTable.ResumeLayout(false);
            this.tp_SelectTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_SubTable)).EndInit();
            this.tp_SelectField.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Cols)).EndInit();
            this.tp_SelectWhere.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv_ColsWhere)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_SelectTable;
        private System.Windows.Forms.DataGridView gv_SubTable;
        private System.Windows.Forms.TabPage tp_SelectField;
        private System.Windows.Forms.TabPage tp_SelectWhere;
        private System.Windows.Forms.Button btn_AddTable;
        private System.Windows.Forms.TextBox txt_MainTableAlias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_MasterTableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gv_Cols;
        private System.Windows.Forms.DataGridView gv_ColsWhere;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_BuilderCode;
        private System.Windows.Forms.CheckBox cbx_IsWhere;
        private System.Windows.Forms.CheckBox cbx_IsCheck;
        private System.Windows.Forms.CheckBox cbx_IsEdit;
        private System.Windows.Forms.CheckBox cbx_IsNum;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column12;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column13;
        private System.Windows.Forms.CheckBox cbx_Page;
        private System.Windows.Forms.TextBox txt_PageSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txt_SqlText;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbx_IsDelete;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_FileName;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbx_IsImp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_ImpRows;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Select;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_Import;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Meaning;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Field;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Alias;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_TableAlias;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_IsCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_Code;
        private System.Windows.Forms.TextBox txt_MName;
        private System.Windows.Forms.Label label8;

    }
}