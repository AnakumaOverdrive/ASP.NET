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
    /// 直角坐标系 grid 中的 y 轴，一般情况下单个 grid 组件最多只能放左右两个 y 轴，多于两个 y 轴需要通过配置 offset 属性防止同个位置多个 Y 轴的重叠。
    /// </summary>
    public class EcharsYAxis
    {
        private EcharsYAxisType _type = EcharsYAxisType.value;

        /// <summary>
        /// 类目数据，在类目轴（type: 'category'）中有效。
        /// </summary>
        public object[] data { get; set; }

        /// <summary>
        /// 坐标轴类型。
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EcharsYAxisType type
        {
            get { return _type; }
            set { _type = value; }
        }
    }

    /// <summary>
    /// 坐标轴类型。
    /// </summary>
    public enum EcharsYAxisType
    {
        /// <summary>
        /// 数值轴，适用于连续数据。
        /// </summary>
        value,
        /// <summary>
        /// 类目轴，适用于离散的类目数据，为该类型时必须通过 data 设置类目数据。
        /// </summary>
        category,
        /// <summary>
        /// 时间轴，适用于连续的时序数据，与数值轴相比时间轴带有时间的格式化，在刻度计算上也有所不同，例如会根据跨度的范围来决定使用月，星期，日还是小时范围的刻度。
        /// </summary>
        time,
        /// <summary>
        /// 对数轴。适用于对数数据。
        /// </summary>
        log
    }
}
