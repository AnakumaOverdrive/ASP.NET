using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
 

namespace Esint.CodeBuilder.Model
{
    public class Uitility
    {
        public static string ConvertToCSharp(string dataType)
        {
            foreach (DataType dType in PublicClass.DataTypeList)
            {
                if (dType.DbDataType.ToLower() == dataType.ToLower())
                {
                    return dType.CSharpType;
                }
            }
            return "Unknown DataType!";
        }

        public static string ConvertToDbType(string dataType)
        {

            foreach (DataType dType in PublicClass.DataTypeList)
            {
                if (dType.DbDataType.ToLower() == dataType.ToLower())
                {
                    return dType.DbType;
                }
            }
            return "Unknown DataType!";
        }

        /// <summary>
        /// 首字符小写 .
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ConvertToCamel(string str)
        {
            if (string.IsNullOrEmpty(str) || str.Trim() == "")
                return "";
            string returnstr = "";
          //  string[] name = str.Split('_');
          //  if (name.Length > 1)
          //  {
          //      foreach (string t in name)
         //     {
           //         returnstr += t.Substring(0, 1).ToLower() + t.Substring(1).ToLower();
         //       }
          //  }
         //   else
         //   {
                if (str == str.ToUpper())
                {
                    returnstr = str.Substring(0, 1).ToLower() + str.Substring(1).ToLower();
                }
                else
                {
                    returnstr = str.Substring(0, 1).ToLower() + str.Substring(1);
                }
          //  }
            return returnstr;
        }

        /// <summary>
        ///  首字符大写 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ConvertToPascal(string str)
        {
            if (string.IsNullOrEmpty(str) || str.Trim() == "")
                return "";
            string returnstr = "";
            //string[] name = str.Split('_');
            //if (name.Length > 1)
            //{
            //    foreach (string t in name)
            //    {
            //        if (!string.IsNullOrEmpty(t))
            //            returnstr += t.Substring(0, 1).ToUpper() + t.Substring(1).ToLower();
            //    }
            //}
            //else
            //{
            //if (str == str.ToUpper())
            //{
            //    returnstr = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
            //}
            //else
            //{
            //    returnstr = str.Substring(0, 1).ToUpper() + str.Substring(1);
            //}
            //}
            returnstr = StringSplit(str);
            return returnstr;
        }
        /// <summary>
        /// 将字符串转换成首字母大写，其他字母小写
        /// </summary>
        /// <returns></returns>
        public static string StringToTitleCase(string StringCode)
        {
            StringCode = StringCode.ToLower();
            System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;
            return textInfo.ToTitleCase(StringCode);
        }
        /// <summary>
        /// 分割表字符串
        /// </summary>
        /// <param name="_StringSplit"></param>
        /// <returns></returns>
        public static string StringSplit(string _StringSplit)
        { 
            string TableName = _StringSplit;
            string[] TableName_array = TableName.Split(new char[] { '_' });
            TableName = "";
            for (int i = 0; i < TableName_array.Length; i++)
            {
                //转换字母大小写
                TableName += StringToTitleCase(TableName_array[i].ToString());
            }
            return TableName;
        }

        public static string GetColumnString(DbTable db, string HeaderStr, bool IsIndentity, bool IsPrimaryKey, bool IsForeignKey)
        {
            string returnString = "";
            foreach (Column col in db.Columns)
            {
                if (col.IsIndentity)
                {
                    if (IsIndentity)
                        returnString += HeaderStr + col.ColumnName + ",";
                    continue;

                }
                else

                    if (col.IsPrimaryKey)
                    {
                        if (IsPrimaryKey)
                            returnString += HeaderStr + col.ColumnName + ",";
                        continue;
                    }
                    else


                        if (col.IsForeignKey)
                        {
                            if (IsForeignKey)
                                returnString += HeaderStr + col.ColumnName + ",";
                            continue;
                        }
                        else
                            returnString += HeaderStr + col.ColumnName + ",";
            }

            if (returnString != "")
                return returnString.Substring(0, returnString.Length - 1);
            else
                return "";
        }




        public static List<Column> GetColumnList(DbTable db, bool IsIndentity, bool IsPrimaryKey, bool IsForeignKey)
        {
            List<Column> returnList = new List<Column>();
            foreach (Column col in db.Columns)
            {
                if (col.IsIndentity)
                {
                    if (IsIndentity)
                        returnList.Add(col);
                    continue;

                }
                else

                    if (col.IsPrimaryKey)
                    {
                        if (IsPrimaryKey)
                            returnList.Add(col);
                        continue;
                    }
                    else


                        if (col.IsForeignKey)
                        {
                            if (IsForeignKey)
                                returnList.Add(col);
                            continue;
                        }
                        else
                            returnList.Add(col);
            }
            return returnList;
        }

        public static List<Column> GetNoIndentityColumns(DbTable db)
        {
            return GetColumnList(db, false, true, true);
        }

        public static string GetConvertString(string dataType)
        {
            foreach (DataType dType in PublicClass.DataTypeList)
            {
                if (dType.DbDataType.ToLower() == dataType.ToLower())
                {
                    return dType.ConvertString;
                }
            }
            return "Unknown DataType!";
        }


        public static bool GetIsAutoWidth(string dataType)
        {
            foreach (DataType dType in PublicClass.DataTypeList)
            {
                if (dType.DbDataType.ToLower() == dataType.ToLower())
                {
                    return dType.AutoWidth;
                }
            }
            return false;
        }


        public static string GetNoIndentityColumnsString(DbTable db, string headerStr)
        {
            return GetColumnString(db, headerStr, false, true, true);
        }

        public static string AddString(params string[] str)
        {
            string st = "";
            foreach (string s in str)
            {
                st += s;
            }
            return st;
        }

        public static string GetSubstring(string sourcestr, int startindex, int span)
        {
            return sourcestr.Substring(startindex, sourcestr.Length + span);
        }
    }
}
