using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Echars 设置参数
    /// </summary>
    public class EcharsOption
    {
        /// <summary>
        /// 标题组件，包含主标题和副标题。
        /// </summary>
        public EcharsTitle title { get; set; }

        /// <summary>
        /// 提示框组件。
        /// </summary>
        public EcharsTooltip tooltip { get; set; }

        /// <summary>
        /// 图例组件。
        /// </summary>
        public EcharsLegend legend { get; set; }

        /// <summary>
        /// 直角坐标系内绘图网格，单个 grid 内最多可以放置上下两个 X 轴，左右两个 Y 轴。
        /// 可以在网格上绘制折线图，柱状图，散点图（气泡图）。
        /// </summary>
        public EcharsGrid grid { get; set; }

        /// <summary>
        /// 直角坐标系 grid 中的 x 轴，一般情况下单个 grid 组件最多只能放左右两个 x 轴，
        /// 多于两个 x 轴需要通过配置 offset 属性防止同个位置多个 x 轴的重叠。
        /// </summary>
        public EcharsXAxis xAxis { get; set; }

        /// <summary>
        /// 直角坐标系 grid 中的 y 轴，一般情况下单个 grid 组件最多只能放左右两个 y 轴，
        /// 多于两个 y 轴需要通过配置 offset 属性防止同个位置多个 Y 轴的重叠。
        /// </summary>
        public EcharsYAxis yAxis { get; set; }

        /// <summary>
        /// 系列列表。每个系列通过 type 决定自己的图表类型
        /// </summary>
        public IList<EcharsSeries> series { get; set; }
    }
}
