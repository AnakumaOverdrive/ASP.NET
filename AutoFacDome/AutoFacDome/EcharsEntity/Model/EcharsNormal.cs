using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EcharsNormal
    {
        private bool _show = false;

        /// <summary>
        /// 标签的位置。
        /// 
        /// [x, y]
        ///通过相对的百分比或者绝对像素值表示标签相对于图形包围盒左上角的位置。 示例：
        ///  // 绝对的像素值
        ///  position: [10, 10],
        ///  // 相对的百分比
        ///  position: ['50%', '50%']
        ///'top'
        ///'left'
        ///'right'
        ///'bottom'
        ///'inside'
        ///'insideLeft'
        ///'insideRight'
        ///'insideTop'
        ///'insideBottom'
        ///'insideTopLeft'
        ///'insideBottomLeft'
        ///'insideTopRight'
        ///'insideBottomRight'
        /// </summary>
        public string position { get; set; }

        /// <summary>
        /// 是否显示标签。
        /// </summary>
        public bool show
        {
            get { return _show; }
            set { _show = value; }
        }
    }
}
