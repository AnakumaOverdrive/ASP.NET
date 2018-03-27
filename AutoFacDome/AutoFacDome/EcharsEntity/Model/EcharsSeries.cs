using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 系列列表。每个系列通过 type 决定自己的图表类型
    /// </summary>
    public class EcharsSeries
    {
        private string _type = "line";

        /// <summary>
        /// 系列名称，用于tooltip的显示，legend 的图例筛选，在 setOption 更新数据和配置项时用于指定对应的系列。
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 系列类型 默认line
        /// </summary>
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        
        /// <summary>
        /// 数据堆叠，同个类目轴上系列配置相同的stack值后，后一个系列的值会在前一个系列的值上相加。
        /// </summary>
        public string stack { get; set; }

        /// <summary>
        /// 系列中的数据内容数组。数组项通常为具体的数据项。
        /// </summary>
        public object[] data { get; set; }

        /// <summary>
        /// 图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等，
        /// label选项在 ECharts 2.x 中放置于itemStyle.normal下，
        /// 在 ECharts 3 中为了让整个配置项结构更扁平合理，label 被拿出来跟 itemStyle 平级，
        /// 并且跟 itemStyle 一样拥有 normal, emphasis 两个状态。
        /// </summary>
        public EcharsLabel label { get; set; }

        
    }
}
