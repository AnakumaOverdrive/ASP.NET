using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Esint.CodeBuilder.BLL;
using Esint.CodeBuilder.Public;
using Esint.CodeBuilder.Model;
using System.Xml;

namespace Esint.CodeBuilder.Forms
{
    public partial class InputRegCode : Form
    {
        Int64 requestCode;

        public InputRegCode()
        {
            InitializeComponent();

            requestCode = GetVol.GetVolOf("C");
            txt_RequestCode.Text = requestCode.ToString(); //函数GetVolOf()的调用方法 
        }


        private void btn_Reg_Click(object sender, EventArgs e)
        {
            if (label4.Text!= "正确")
            {
                MessageBox.Show("注册码错误,请重新输入!");
                return;
            }
            //打开系统配置XML文件 
            XmlDocument xDoc = XMLHelper.xmlDoc(Application.StartupPath + "\\Config\\SysConfig.xml");
            XMLHelper.UpdateNode(XMLHelper.GetNode(xDoc, "RegCode"), txt_Returncode.Text);
            //保存配置文件
            xDoc.Save(Application.StartupPath + "\\Config\\SysConfig.xml");

            MessageBox.Show("注册完成,请重新启动本软件!");
            this.Close();
        }

        private void txt_Returncode_TextChanged(object sender, EventArgs e)
        {
            if (!SecurityBLL.verifyMd5Hash(Convert.ToString(requestCode * 3 + 2011), txt_Returncode.Text))
            {
                label4.Text = "错误";
            }
            else
            {
                label4.Text = "正确";
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
