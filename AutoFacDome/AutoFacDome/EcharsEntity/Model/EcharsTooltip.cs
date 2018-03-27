using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Model
{
    /// <summary>
    /// 图例的 tooltip 配置，配置项同 tooltip。
    /// 默认不显示，可以在 legend 文字很多的时候对文字做裁剪并且开启 tooltip，
    /// </summary>
    public class EcharsTooltip
    {
        private bool _show = true;
        /// <summary>
        /// 是否显示提示框组件，包括提示框浮层和 axisPointer。
        /// 默认 true
        /// </summary>
        public bool Show
        {
            get { return _show; }
            set { _show = value; }
        }

        private EcharsTooltipTarget _trigger = EcharsTooltipTarget.item;

        /// <summary>
        /// 触发类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EcharsTooltipTarget trigger
        {
            get { return _trigger; }
            set { _trigger = value; }
        }

        /// <summary>
        /// 坐标轴指示器配置项，在 trigger 为 'axis' 时有效。
        /// </summary>
        public EcharsAxisPointer axisPointer { get; set; }

        
    }

    public enum EcharsTooltipTarget
    {
        /// <summary>
        /// 数据项图形触发，主要在散点图，饼图等无类目轴的图表中使用。
        /// </summary>
        item,
        /// <summary>
        /// 坐标轴触发，主要在柱状图，折线图等会使用类目轴的图表中使用。
        /// </summary>
        axis
    }
}
