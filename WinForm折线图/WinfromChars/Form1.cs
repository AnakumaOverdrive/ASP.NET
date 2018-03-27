using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinfromChars
{
    public partial class Form1 : Form
    {
        private static DataTable dt = default(DataTable);
       
        public Form1()
        {
            InitializeComponent();
            InitChart();
            timer1.Start();
        }

       
 
        private void InitChart()
        {
            dt = CreateDataTable();
            
            //设置图表的数据源
            //ct.DataSource = dt;

            ////设置图表Y轴对应项
            //ct.Series[0].YValueMembers = "Volume1";
            ////设置图表X轴对应项
            //ct.Series[0].XValueMember = "Date";
            ////图类型(折线)
            //ct.Series[0].ChartType = SeriesChartType.Line;

            ct.ChartAreas[0].AxisX.ScaleView.Size = 5;  
            ct.Series.Clear();
            //第一条数据
            Series ss1 = new Series("CPU");   //这里 dt1 ,dt2 任意取名称，但要唯一
            ss1.Points.DataBind(dt.AsEnumerable(), "Date", "Volume1", "");
            ss1.XValueType = ChartValueType.DateTime; //设置X轴
            ss1.ChartType = SeriesChartType.Spline;   //设置Y轴为折线
            ct.Series.Add(ss1);
            //绑定数据
            ct.DataBind();


            //第二条数据
            Series ss2 = new Series("GPU");   //这里 dt1 ,dt2 任意取名称，但要唯一
            ss2.Points.DataBind(dt.AsEnumerable(), "Date", "Volume2", "");
            ss2.XValueType = ChartValueType.DateTime; //设置X轴
            ss2.ChartType = SeriesChartType.Spline;   //设置Y轴为折线
            ct.Series.Add(ss2);
            //绑定数据
            ct.DataBind();

            //保存图片
            //chart1.SaveImage(@"e:\1.bmp ", ImageFormat.Bmp);
        }

        private DataTable CreateDataTable()
        {
            Random random = new Random(DateTime.Now.GetHashCode());
            DataTable dt = new DataTable();

            dt.Columns.Add("Date");
            dt.Columns.Add("Volume1");
            dt.Columns.Add("Volume2");
            DataRow dr;
            for (int i = 0; i < 50; i++)
            {
                dr = dt.NewRow();
                dr["Date"] =DateTime.Now.AddMinutes(i).ToString("HH:mm:ss");
                dr["Volume1"] = random.NextDouble();
                dr["Volume2"] = random.NextDouble();
                dt.Rows.Add(dr);
            }

            return dt;
        }

        /// <summary>
        /// 时间控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random(DateTime.Now.GetHashCode());

            Series series = ct.Series[0];
            series.Points.AddXY(DateTime.Now.ToString("HH:mm:ss"), random.NextDouble());

            Series series1 = ct.Series[1];
            series1.Points.AddXY(DateTime.Now.ToString("HH:mm:ss"), random.NextDouble());

            ct.ChartAreas[0].AxisX.ScaleView.Position = series.Points.Count - 5;  
        }
    }
}
