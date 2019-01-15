using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;

namespace Esint.CodeBuilder.Model
{
    public class ControlProperty : IControlProperty
    {
        public bool IsVisible { get; set; }
        //控件类型
        public string ControlType { get; set; }
        //附加信息
        public string Tag { get; set; }
        //是否允许为空
        public bool IsEnabledNull { get; set; }
        public string ControlName
        {
            get
            {
                if (ControlType == "W文本框"||ControlType=="D多行文本框")
                    return "txt_";
                if (ControlType == "R日期框")
                    return "txt_";
                if (ControlType == "X下拉框")
                    return "drp_";
                if (ControlType == "F复选框")
                    return "cbx_";
                if (ControlType == "Y隐藏域")
                    return "hdn_";
                if (ControlType == "B标签")
                    return "lbl_";

                return "";
            }
        }

        public string ControlValueStr
        {
            get
            {
                if (ControlType == "W文本框"||ControlType=="D多行文本框")
                    return ".Text";
                if (ControlType == "R日期框")
                    return ".Text";
                if (ControlType == "X下拉框")
                    return ".SelectedValue";
                if (ControlType == "F复选框")
                    return ".Checked";
                if (ControlType == "Y隐藏域")
                    return ".Value";
                if (ControlType == "B标签")
                    return ".Text";
                return "";
            }
        }
    }
}
