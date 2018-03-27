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
    /// 直角坐标系内绘图网格，单个 grid 内最多可以放置上下两个 X 轴，左右两个 Y 轴。
    /// 可以在网格上绘制折线图，柱状图，散点图（气泡图）。
    /// </summary>
    public class EcharsGrid
    {
        private string _left = "auto";
        private string _right = "10%";
        private string _bottom = "60";
        private bool _containLabel = false;

        /// <summary>
        /// grid 组件离容器左侧的距离。
        /// left 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，
        /// 也可以是 'left', 'center', 'right'( EcharsGridLeft 枚举)
        /// </summary>
        public string left
        {
            get { return _left; }
            set { _left = value; }
        }

        /// <summary>
        /// grid 组件离容器右侧的距离。
        /// right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
        /// </summary>
        public string right
        {
            get { return _right; }
            set { _right = value; }
        }

        /// <summary>
        /// grid 组件离容器下侧的距离。
        /// bottom 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
        /// </summary>
        public string bottom
        {
            get { return _bottom; }
            set { _bottom = value; }
        }

        /// <summary>
        /// grid 区域是否包含坐标轴的刻度标签，在无法确定坐标轴标签的宽度，容器又比较小无法预留较多空间的时候，可以设为 true 防止标签溢出容器。
        /// </summary>
        public bool containLabel
        {
            get { return _containLabel; }
            set { _containLabel = value; }
        }
    }
}
