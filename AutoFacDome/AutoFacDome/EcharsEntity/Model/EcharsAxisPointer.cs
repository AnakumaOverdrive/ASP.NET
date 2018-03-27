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
    /// 坐标轴指示器配置项，在 trigger 为 'axis' 时有效。
    /// </summary>
    public class EcharsAxisPointer
    {
        private EcharsAxisPointerType _type = EcharsAxisPointerType.line;
        /// <summary>
        /// 指示器类型
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EcharsAxisPointerType type
        {
            get { return _type; }
            set { _type = value; }
        }

        private EcharsAxisPointerAxis _axis = EcharsAxisPointerAxis.auto;
        /// <summary>
        /// 指示器的坐标轴。可以是 'x', 'y', 'radius', 'angle'。默认取类目轴或者时间轴。
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EcharsAxisPointerAxis axis
        {
            get { return _axis; }
            set { _axis = value; }
        }

        private bool _animation = true;
        /// <summary>
        /// 是否开启动画。
        /// </summary>
        public bool animation
        {
            get { return _animation; }
            set { _animation = value; }
        }
    }

    /// <summary>
    /// 指示器类型
    /// </summary>
    public enum EcharsAxisPointerType
    {
        /// <summary>
        /// 直线指示器
        /// </summary>
        line,
        /// <summary>
        /// 十字准星指示器
        /// </summary>
        cross,
        /// <summary>
        /// 阴影指示器
        /// </summary>
        shadow
    }

    /// <summary>
    /// 指示器的坐标轴。可以是 'x', 'y', 'radius', 'angle'。默认取类目轴或者时间轴。
    /// </summary>
    public enum EcharsAxisPointerAxis
    {
        x,
        y,
        radius,
        angle,
        auto
    }

}
