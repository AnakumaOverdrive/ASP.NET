using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Model
{
    public class EcharsTitle
    {
        /// <summary>
        /// 主标题文本，支持使用 \n 换行。
        /// </summary>
        public string text { get; set; }

        private bool _show = true;
        /// <summary>
        /// 是否显示标题组件。
        /// </summary>
        public bool show
        {
            get { return _show; }
            set { _show = value; }
        }

        private EcharsTitleTarget _target = EcharsTitleTarget.blank;
        /// <summary>
        /// 指定窗口打开主标题超链接。
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public EcharsTitleTarget Target
        {
            get { return _target; }
            set { _target = value; }
        }
    }

    public enum EcharsTitleTarget
    {
        /// <summary>
        /// 当前窗口打开
        /// </summary>
        self,
        /// <summary>
        ///  新窗口打开
        /// </summary>
        blank
    }
}
