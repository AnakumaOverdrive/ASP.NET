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
    public partial class MainForm : Form
    {
        private WinProgressBar winProgress;

        public MainForm()
        {
            winProgress = new WinProgressBar();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            //winProgress.ShowDialog();
            winProgress.Show();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            winProgress.Current = 50;
            winProgress.AddValue("");
        }
    }
}
