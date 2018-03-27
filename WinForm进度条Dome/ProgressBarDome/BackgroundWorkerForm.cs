using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ProgressBarDome
{
    public partial class BackgroundWorkerForm : Form
    {
        public BackgroundWorkerForm()
        {
            InitializeComponent();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var count = (int)e.Argument;
            for (int i = 1; i <= count; i++)
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                bw.ReportProgress(i);
                Thread.Sleep(200);      // 模拟耗时的任务
            }     
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            resultTextBox.Text += DateTime.Now + Environment.NewLine;
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                resultTextBox.Text += "任务取消。" + Environment.NewLine;
            else if (e.Error != null)
                resultTextBox.Text += "出现异常: " + e.Error + Environment.NewLine;
            else
                resultTextBox.Text += "任务完成。 " + Environment.NewLine;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            progressBar.Maximum = 10;

            resultTextBox.Text = "任务开始..." + Environment.NewLine;
            bw.RunWorkerAsync(10);
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            bw.CancelAsync();
        }
    }
}
