namespace Esint.CodeBuilder.Forms
{
    partial class frm_SysConfig
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
            this.lbl_Oper = new System.Windows.Forms.Label();
            this.txt_OperName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_TableHead = new System.Windows.Forms.TextBox();
            this.txt_DbName = new System.Windows.Forms.TextBox();
            this.txt_SqlText = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_AppName = new System.Windows.Forms.TextBox();
            this.cbx_IsOpen = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_CodeSql = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_Oper
            // 
            this.lbl_Oper.AutoSize = true;
            this.lbl_Oper.Location = new System.Drawing.Point(60, 31);
            this.lbl_Oper.Name = "lbl_Oper";
            this.lbl_Oper.Size = new System.Drawing.Size(47, 12);
            this.lbl_Oper.TabIndex = 0;
            this.lbl_Oper.Text = "操作者:";
            // 
            // txt_OperName
            // 
            this.txt_OperName.Location = new System.Drawing.Point(130, 28);
            this.txt_OperName.Name = "txt_OperName";
            this.txt_OperName.Size = new System.Drawing.Size(146, 21);
            this.txt_OperName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "表头字串:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "数据库名:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "代码类查询语句:";
            // 
            // txt_TableHead
            // 
            this.txt_TableHead.Location = new System.Drawing.Point(130, 64);
            this.txt_TableHead.Name = "txt_TableHead";
            this.txt_TableHead.Size = new System.Drawing.Size(146, 21);
            this.txt_TableHead.TabIndex = 1;
            // 
            // txt_DbName
            // 
            this.txt_DbName.Location = new System.Drawing.Point(130, 100);
            this.txt_DbName.Name = "txt_DbName";
            this.txt_DbName.Size = new System.Drawing.Size(146, 21);
            this.txt_DbName.TabIndex = 1;
            // 
            // txt_SqlText
            // 
            this.txt_SqlText.Location = new System.Drawing.Point(130, 159);
            this.txt_SqlText.Multiline = true;
            this.txt_SqlText.Name = "txt_SqlText";
            this.txt_SqlText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_SqlText.Size = new System.Drawing.Size(325, 56);
            this.txt_SqlText.TabIndex = 1;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(132, 291);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(262, 291);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "应用名称";
            // 
            // txt_AppName
            // 
            this.txt_AppName.Location = new System.Drawing.Point(130, 132);
            this.txt_AppName.Name = "txt_AppName";
            this.txt_AppName.Size = new System.Drawing.Size(146, 21);
            this.txt_AppName.TabIndex = 1;
            // 
            // cbx_IsOpen
            // 
            this.cbx_IsOpen.AutoSize = true;
            this.cbx_IsOpen.Location = new System.Drawing.Point(301, 32);
            this.cbx_IsOpen.Name = "cbx_IsOpen";
            this.cbx_IsOpen.Size = new System.Drawing.Size(168, 16);
            this.cbx_IsOpen.TabIndex = 3;
            this.cbx_IsOpen.Text = "保存后是否自动打开文件夹";
            this.cbx_IsOpen.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "代码查询语句:";
            // 
            // txt_CodeSql
            // 
            this.txt_CodeSql.Location = new System.Drawing.Point(130, 221);
            this.txt_CodeSql.Multiline = true;
            this.txt_CodeSql.Name = "txt_CodeSql";
            this.txt_CodeSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_CodeSql.Size = new System.Drawing.Size(325, 56);
            this.txt_CodeSql.TabIndex = 1;
            // 
            // frm_SysConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 346);
            this.Controls.Add(this.cbx_IsOpen);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.txt_CodeSql);
            this.Controls.Add(this.txt_SqlText);
            this.Controls.Add(this.txt_AppName);
            this.Controls.Add(this.txt_DbName);
            this.Controls.Add(this.txt_TableHead);
            this.Controls.Add(this.txt_OperName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Oper);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_SysConfig";
            this.Text = "系统配置";
            this.Load += new System.EventHandler(this.frm_SysConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Oper;
        private System.Windows.Forms.TextBox txt_OperName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_TableHead;
        private System.Windows.Forms.TextBox txt_DbName;
        private System.Windows.Forms.TextBox txt_SqlText;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_AppName;
        private System.Windows.Forms.CheckBox cbx_IsOpen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_CodeSql;
    }
}