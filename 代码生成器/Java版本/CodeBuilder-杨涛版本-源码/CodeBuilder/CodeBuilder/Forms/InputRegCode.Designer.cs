namespace Esint.CodeBuilder.Forms
{
    partial class InputRegCode
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_RequestCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Returncode = new System.Windows.Forms.TextBox();
            this.btn_Reg = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "机器码:";
            // 
            // txt_RequestCode
            // 
            this.txt_RequestCode.BackColor = System.Drawing.Color.White;
            this.txt_RequestCode.Location = new System.Drawing.Point(66, 23);
            this.txt_RequestCode.Name = "txt_RequestCode";
            this.txt_RequestCode.ReadOnly = true;
            this.txt_RequestCode.Size = new System.Drawing.Size(270, 21);
            this.txt_RequestCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "注册码:";
            // 
            // txt_Returncode
            // 
            this.txt_Returncode.Location = new System.Drawing.Point(66, 62);
            this.txt_Returncode.Name = "txt_Returncode";
            this.txt_Returncode.Size = new System.Drawing.Size(270, 21);
            this.txt_Returncode.TabIndex = 1;
            this.txt_Returncode.TextChanged += new System.EventHandler(this.txt_Returncode_TextChanged);
            // 
            // btn_Reg
            // 
            this.btn_Reg.Location = new System.Drawing.Point(242, 129);
            this.btn_Reg.Name = "btn_Reg";
            this.btn_Reg.Size = new System.Drawing.Size(75, 23);
            this.btn_Reg.TabIndex = 2;
            this.btn_Reg.Text = "注册";
            this.btn_Reg.UseVisualStyleBackColor = true;
            this.btn_Reg.Click += new System.EventHandler(this.btn_Reg_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(323, 129);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "退出";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "注册电话:58595422";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(343, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 3;
            // 
            // InputRegCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 164);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Reg);
            this.Controls.Add(this.txt_Returncode);
            this.Controls.Add(this.txt_RequestCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InputRegCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_RequestCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Returncode;
        private System.Windows.Forms.Button btn_Reg;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}