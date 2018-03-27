using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProgressBarDome
{
    public partial class WinProgressBar : Form
    {
        #region 属性
        private string content = "请稍等...";

        /// <summary>  
        /// 当前值  
        /// </summary>  
        public int Current
        {
            get { return this.progressBar1.Value; }
            set
            {
                this.progressBar1.Value = value;
                AddValue();
            }
        }

        private int _max = 100;
        /// <summary>  
        /// 最大值  
        /// </summary>  
        public int Max
        {
            get { return _max; }
            set
            {
                _max = value;
                this.progressBar1.Maximum = _max;
                this.progressBar1.Value = 0;
            }
        }

        /// <summary>
        /// 步进长度
        /// </summary>
        public int Step
        {
            get { return this.progressBar1.Step; }
            set
            {
                this.progressBar1.Step = value;
            }
        }


        #endregion

        public WinProgressBar(string text = "")
        {
            InitializeComponent();
            //更新文字
            content = string.IsNullOrEmpty(text) ? content : text;
            this.label1.Text = content;
        }

        /// <summary>  
        /// 给进度条加值的方法  
        /// </summary>  
        public void AddValue(string text = "")
        {
            //更新文字
            content = string.IsNullOrEmpty(text) ? content : text;
            this.label1.Text = content;
            //步进进度条
            this.progressBar1.PerformStep();

            //判断是否应该关闭窗体
            if (this.progressBar1.Value >= this.progressBar1.Maximum)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
        /// <summary>  
        /// 取消按钮的方法  
        /// </summary>  
        private void Cancel()
        {
            //father.CreateThesisIsRuning = false;
            //progressBar1.Style = ProgressBarStyle.Marquee;
            //label1.Text = "取消中，请稍等...";
            //while (true)
            //{
            //    if (!father.CreateThesisTh.IsAlive)
            //        break;
            //    Application.DoEvents();
            //}
        }  
    }
}
