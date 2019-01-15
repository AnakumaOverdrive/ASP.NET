using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esint.Common
{
    public static class StringExtend
    {
        /// <summary>
        /// 移除字符串最后一个字符
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        public static string RemoveLastChar(this string sourceStr)
        {
            if (!string.IsNullOrEmpty(sourceStr))
                return sourceStr.Substring(0, sourceStr.Length - 1);
            else
                return sourceStr;
        }

        public static string ToUnicode(this string s)
        {
            char[] charbuffers = s.ToCharArray();
            byte[] buffer;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < charbuffers.Length; i++)
            {
                buffer = System.Text.Encoding.Unicode.GetBytes(charbuffers[i].ToString());
                sb.Append(String.Format("\\u{0:X2}{1:X2}", buffer[1], buffer[0]));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 对超长文本进行格式化
        /// </summary>
        /// <param name="txt">要格式化的文本</param>
        /// <param name="num">保留的有效长度</param>
        /// <returns>格式化完成后的文本</returns>
        public static string FormattedText(this string txt, int num)
        {
            if (!string.IsNullOrEmpty(txt) && txt.Length > num)
            {
                return txt.Substring(0, num) + "....";
            }
            else
            {
                return txt;
            }
        }
    }
}
