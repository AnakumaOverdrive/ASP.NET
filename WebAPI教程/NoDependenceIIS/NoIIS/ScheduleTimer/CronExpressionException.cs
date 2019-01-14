using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NoIIS.ScheduleTimer
{
    // // string exp=(string) CronExpression.CreateInstance().Seconds(t => t.Define(0)).Minutes(t => t.Define(0)).Hours(t => t.Define(12)).DayofMonth(t=>t.Any()).Month(t=>t.Define(1)).DayofWeek(t=>t.Analysis("1","6")).ToString();
    public class CronExpressionException : Exception
    {
        public CronExpressionException(string error)
            : base(error)
        { }
    }
    public class Token
    {
        public string First { get; set; }
        public string Second { get; set; }
        public string Sep { get; set; }
    }
    public class CronOperation
    {
        /// <summary>
        /// -表示一个指定的范围
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Token Range(string start, string end)
        {
            Token token = new Token();
            token.First = start;
            token.Second = end;
            token.Sep = "-";
            return token;
        }
        /// <summary>
        /// * 表示所有值
        /// </summary>
        /// <returns></returns>
        public Token Any()
        {
            Token token = new Token();
            token.First = "";
            token.Second = "";
            token.Sep = "*";
            return token;
        }
        public Token Define(int num)
        {
            Token token = new Token();
            token.First = num.ToString();
            token.Second = "";
            token.Sep = "";
            return token;
        }
        //  ?  未说明的值   不关心 它为何值   ?
        public Token UnDefine()
        {
            Token token = new Token();
            token.First = "";
            token.Second = "";
            token.Sep = "?";
            return token;
        }
        //  , 表示一个附件的可能值
        public Token Analysis(params string[] args)
        {
            Token token = new Token();

            token.Second = "";
            foreach (var item in args)
            {
                token.First += item + ",";
            }
            token.First = token.First.TrimEnd(','); ;
            token.Sep = ",";
            return token;
        }
        //  /  符号钱表示开始时间  付好后表示每次递增的值
        public Token Loop(int start, int space)
        {
            Token token = new Token();
            token.First = start.ToString();
            token.Second = space.ToString();
            token.Sep = "/";
            return token;
        }
        // # 字符可用于“周几”字段。该字符表示“该月第几个周×”，比如"6#3"表示该月第三个周五( 6表示周五而"#3"该月第三个)。再比如: "2#1" = 表示该月第一个周一而 "4#5" = 该月第五个周三。注意如果你指定"#5"该月没有第五个“周×”，该月是不会触发的。
        public Token Specify(int day, int dayinmonth)
        {
            Token token = new Token();
            token.First = day.ToString();
            token.Second = dayinmonth.ToString();
            token.Sep = "#";
            return token;
        }
        // L 字符可用在“日”和“周几”这两个字段。它是"last"的缩写, 但是在这两个字段中有不同的含义。例如,“日”字段中的"L"表示"一个月中的最后一天" —— 对于一月就是31号对于二月来说就是28号（非闰年）。而在“周几”字段中, 它简单的表示"7" or "SAT"，但是如果在“周几”字段中使用时跟在某个数字之后, 它表示"该月最后一个星期×" —— 比如"6L"表示"该月最后一个周五"。当使用'L'选项时,指定确定的列表或者范围非常重要，否则你会被结果搞糊涂的。 
        public Token Last(int weekday = 0)
        {
            Token token = new Token();
            token.First = "";
            token.Second = "";
            if (weekday == 0)
            {

            }
            else
            {
                token.First = weekday.ToString();
            }
            token.Sep = "L";
            return null;
        }
        // 可用于“日”字段。用来指定历给定日期最近的工作日(周一到周五) 。比如你将“日”字段设为"15W"，意为: "离该月15号最近的工作日"。因此如果15号为周六，触发器会在14号即周五调用。如果15号为周日, 触发器会在16号也就是周一触发。如果15号为周二,那么当天就会触发。然而如果你将“日”字段设为"1W", 而一号又是周六, 触发器会于下周一也就是当月的3号触发,因为它不会越过当月的值的范围边界。'W'字符只能用于“日”字段的值为单独的一天而不是一系列值的时候。 
        public Token Weekday(int daymonth)
        {
            Token token = new Token();
            token.First = daymonth.ToString();
            token.Second = "";
            token.Sep = "W";
            return token;
        }
        //“L”和“W”可以组合用于“日”字段表示为'LW'，意为"该月最后一个工作日"。 
        public Token LastWeekday()
        {
            Token token = new Token();
            token.First = "";
            token.Second = "";
            token.Sep = "LW";
            return token;
        }
        // 字符可用于“日”和“周几”字段，它是"calendar"的缩写。 它表示为基于相关的日历所计算出的值（如果有的话）。如果没有关联的日历, 那它等同于包含全部日历。“日”字段值为"5C"表示"日历中的第一天或者5号以后"，“周几”字段值为"1C"则表示"日历中的第一天或者周日以后"。 对于“月份”字段和“周几”字段来说合法的字符都不是大小写敏感的。

        public Token Calendar(int daymonth)
        {
            Token token = new Token();
            token.First = daymonth.ToString();
            token.Second = "";
            token.Sep = "C";
            return token;
        }
    }
    //Quartz.net Cron表达式
    public interface ICronExpression
    {

        //0-59  , - * /
        ICronExpression Seconds(Expression<Func<CronOperation, Token>> arg);
        //0-59  ,- * /
        ICronExpression Minutes(Expression<Func<CronOperation, Token>> arg);
        //0-23  , - * /
        ICronExpression Hours(Expression<Func<CronOperation, Token>> arg);
        //1-31  , - * ? / L W
        ICronExpression DayofMonth(Expression<Func<CronOperation, Token>> arg);
        //1-12 or JAN-DEC  , - * /
        ICronExpression Month(Expression<Func<CronOperation, Token>> arg);
        // 1-7 or SUN-SAT , - * ? / L #
        ICronExpression DayofWeek(Expression<Func<CronOperation, Token>> arg);
        //可选 empty,1970-2099  , - * /
        ICronExpression Year(Expression<Func<CronOperation, Token>> arg);

    }
    public class CronExpression : ICronExpression
    {
        public string[] _express = new string[7];
        public CronExpression()
        {
            for (int i = 0; i < 6; i++)
            {

                _express[i] = "*";
            }
            _express[6] = "";
        }
        public static ICronExpression CreateInstance()
        {
            return new CronExpression();
        }
        public bool CheckSep(string codetype, string sep)
        {
            string[] seps = null;
            bool result = true;
            if (sep == string.Empty)
            {
                return true;
            }
            switch (codetype.ToLower())
            {
                case "seconds":

                    seps = new string[4] { ",", "-", "*", "/" };
                    if (!seps.Contains(sep))
                    {
                        result = false;
                    }

                    break;
                case "minutes":

                    seps = new string[4] { ",", "-", "*", "/" };
                    if (!seps.Contains(sep))
                    {
                        result = false;
                    }
                    break;
                case "hours":

                    seps = new string[4] { ",", "-", "*", "/" };
                    if (!seps.Contains(sep))
                    {
                        result = false;
                    }
                    break;
                case "month":

                    string[] mons = new string[12] { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };
                    seps = new string[8] { ",", "-", "*", "/", "?", "L", "W", "LW" };
                    if (!seps.Contains(sep))
                    {
                        result = false;
                    }
                    break;
                case "dayofweek":
                    seps = new string[7] { ",", "-", "*", "/", "?", "L", "#" };
                    if (!seps.Contains(sep))
                    {
                        result = false;
                    }
                    string[] days = new string[7] { "SUN", "MON", "TUES", "WED", "THUR", "FRI", "SAT" };
                    break;
                case "year":
                    seps = new string[4] { ",", "-", "*", "/" };
                    if (!seps.Contains(sep))
                    {
                        result = false;
                    }
                    break;
                case "dayofmonth":

                    seps = new string[8] { ",", "-", "*", "/", "?", "L", "W", "LW" };
                    if (!seps.Contains(sep))
                    {
                        result = false;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in _express)
            {
                builder.Append(item + " ");
            }
            return builder.ToString().TrimEnd();
        }

        public string CheckAllowedValue(string codetype, Token token)
        {
            string error = string.Empty;

            string[] seps = null;
            switch (codetype.ToLower())
            {
                case "seconds":
                    if (Regex.IsMatch(token.First, @"^\d*$") && Regex.IsMatch(token.Second, @"^\d*$"))
                    {
                        int first = Convert.ToInt32(token.First);
                        int second = Convert.ToInt32(token.Second);
                        if (first < 0 || first > 59)
                        {
                            error = "秒数设置错误";
                        }
                        if (second > 59 || second < 0)
                        {
                            error = "秒数设置错误";
                        }
                        if (second < first)
                        {
                            error = "秒数设置错误";
                        }
                    }
                    else
                    {
                        error = "秒数需要数字";
                    }


                    break;
                case "minutes":
                    if (Regex.IsMatch(token.First, @"^\d*$") && Regex.IsMatch(token.Second, @"^\d*$"))
                    {
                        int first = Convert.ToInt32(token.First);
                        int second = Convert.ToInt32(token.Second);
                        if (first < 0 || first > 59)
                        {
                            error = "分钟设置错误";
                        }
                        if (second > 59 || second < 0)
                        {
                            error = "分钟设置错误";
                        }
                        if (second < first)
                        {
                            error = "分钟设置错误";
                        }
                    }
                    else
                    {
                        error = "分钟需要数字";
                    }
                    break;
                case "hours":
                    if (Regex.IsMatch(token.First, @"^\d*$") && Regex.IsMatch(token.Second, @"^\d*$"))
                    {
                        int first = Convert.ToInt32(token.First);
                        int second = Convert.ToInt32(token.Second);
                        if (first < 0 || first > 23)
                        {
                            error = "小时设置错误";
                        }
                        if (second > 23 || second < 0)
                        {
                            error = "小时设置错误";
                        }
                        if (second < first)
                        {
                            error = "小时设置错误";
                        }
                        seps = new string[4] { ",", "-", "*", "/" };
                        if (!seps.Contains(token.Sep))
                        {
                            error = "小时设置错误";
                        }
                    }
                    else
                    {
                        error = "小时需要数字";
                    }
                    break;
                case "month":
                    if (Regex.IsMatch(token.First, @"^\d*$") && Regex.IsMatch(token.Second, @"^\d*$"))
                    {
                        int first = Convert.ToInt32(token.First);
                        int second = Convert.ToInt32(token.Second);
                        if (first < 1 || first > 12)
                        {
                            error = "月设置错误";
                        }
                        if (second > 12 || second < 1)
                        {
                            error = "月设置错误";
                        }
                        if (second < first)
                        {
                            error = "月设置错误";
                        }
                    }
                    else
                    {
                        string[] mons = new string[12] { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };
                        if (mons.Contains(token.First) && mons.Contains(token.Second))
                        {
                            int fir = mons.ToList().IndexOf(token.First);
                            int sec = mons.ToList().IndexOf(token.First);
                            if (fir > sec)
                            {
                                error = "月标示错误";
                            }
                        }
                        else
                        {
                            error = "月需要数字";
                        }
                    }


                    break;
                case "dayofweek":
                    if (Regex.IsMatch(token.First, @"^\d*$") && Regex.IsMatch(token.Second, @"^\d*$"))
                    {
                        int first = Convert.ToInt32(token.First);
                        int second = Convert.ToInt32(token.Second);
                        if (first < 1 || first > 7)
                        {
                            error = "周天设置错误";
                        }
                        if (second > 7 || second < 1)
                        {
                            error = "周天设置错误";
                        }
                        if (second < first)
                        {
                            error = "周天设置错误";
                        }
                    }
                    else
                    {
                        string[] days = new string[7] { "SUN", "MON", "TUES", "WED", "THUR", "FRI", "SAT" };
                        if (days.Contains(token.First) && days.Contains(token.Second))
                        {
                            int fir = days.ToList().IndexOf(token.First);
                            int sec = days.ToList().IndexOf(token.First);
                            if (fir > sec)
                            {
                                error = "周天标示错误";
                            }
                        }
                        else
                        {
                            error = "周天需要数字";
                        }
                    }

                    break;
                case "year":
                    if (Regex.IsMatch(token.First, @"^\d*$") && Regex.IsMatch(token.Second, @"^\d*$"))
                    {
                        int first = Convert.ToInt32(token.First);
                        int second = Convert.ToInt32(token.Second);
                        if (first < 1970 || first > 2099)
                        {
                            error = "年设置错误";
                        }
                        if (second > 2099 || second < 1970)
                        {
                            error = "年设置错误";
                        }
                        if (second < first)
                        {
                            error = "年设置错误";
                        }
                    }
                    else
                    {
                        error = "年设置错误";
                    }
                    break;
                case "dayofmonth":
                    if (Regex.IsMatch(token.First, @"^\d*$") && Regex.IsMatch(token.Second, @"^\d*$"))
                    {
                        int first = Convert.ToInt32(token.First);
                        int second = Convert.ToInt32(token.Second);
                        if (first < 1 || first > 31)
                        {
                            error = "月日设置错误";
                        }
                        if (second > 31 || second < 1)
                        {
                            error = "月日设置错误";
                        }
                        if (second < first)
                        {
                            error = "月日设置错误";
                        }
                    }
                    else
                    {
                        error = "月日需要数字";
                    }
                    break;
                default:
                    break;
            }
            return error;

        }

        public string CheckDefine(string codetype, Token token)
        {
            string error = string.Empty;


            switch (codetype.ToLower())
            {
                case "seconds":
                    if (Regex.IsMatch(token.First, @"^\d*$"))
                    {
                        int first = Convert.ToInt32(token.First);

                        if (first < 0 || first > 59)
                        {
                            error = "秒数设置错误";
                        }

                    }
                    else
                    {
                        error = "秒数需要数字";
                    }


                    break;
                case "minutes":
                    if (Regex.IsMatch(token.First, @"^\d*$"))
                    {
                        int first = Convert.ToInt32(token.First);

                        if (first < 0 || first > 59)
                        {
                            error = "分钟设置错误";
                        }

                    }
                    else
                    {
                        error = "分钟需要数字";
                    }
                    break;
                case "hours":
                    if (Regex.IsMatch(token.First, @"^\d*$"))
                    {
                        int first = Convert.ToInt32(token.First);

                        if (first < 0 || first > 23)
                        {
                            error = "小时设置错误";
                        }

                    }
                    else
                    {
                        error = "小时需要数字";
                    }
                    break;
                case "month":
                    if (Regex.IsMatch(token.First, @"^\d*$"))
                    {
                        int first = Convert.ToInt32(token.First);

                        if (first < 1 || first > 12)
                        {
                            error = "月设置错误";
                        }

                    }
                    else
                    {

                        error = "月标示错误";

                    }


                    break;
                case "dayofweek":
                    if (Regex.IsMatch(token.First, @"^\d*$"))
                    {
                        int first = Convert.ToInt32(token.First);

                        if (first < 1 || first > 7)
                        {
                            error = "周天设置错误";
                        }

                    }
                    else
                    {


                        error = "周天需要数字";

                    }

                    break;
                case "year":
                    if (Regex.IsMatch(token.First, @"^\d*$"))
                    {
                        int first = Convert.ToInt32(token.First);

                        if (first < 1970 || first > 2099)
                        {
                            error = "年设置错误";
                        }

                    }
                    else
                    {
                        error = "年设置错误";
                    }
                    break;
                case "dayofmonth":
                    if (Regex.IsMatch(token.First, @"^\d*$"))
                    {
                        int first = Convert.ToInt32(token.First);

                        if (first < 1 || first > 31)
                        {
                            error = "月日设置错误";
                        }

                    }
                    else
                    {
                        error = "月日需要数字";
                    }
                    break;
                default:
                    break;
            }
            return error;
        }


        public Token Process(Expression<Func<CronOperation, Token>> arg)
        {
            Func<CronOperation, Token> result = arg.Compile();
            CronOperation oper = new CronOperation();
            Token token = result(oper);
            return token;
        }
        public void CheckChain(string codetype, Token token)
        {
            if (token.Sep == "-")
            {
                string result = this.CheckAllowedValue(codetype, token);
                if (result != string.Empty)
                {
                    throw new CronExpressionException(result);
                }
            }
            if (token.Sep == "")
            {
                string result = this.CheckDefine(codetype, token);
                if (result != string.Empty)
                {
                    throw new CronExpressionException(result);
                }
            }
            if (token.Sep == ",")
            {
                string[] list = token.First.Split(',');
                foreach (var item in list)
                {
                    Token token1 = new Token();
                    token1.First = item;
                    string result = this.CheckDefine(codetype, token1);
                    if (result != string.Empty)
                    {
                        throw new CronExpressionException(result);
                    }
                }

            }
        }
        public ICronExpression Seconds(Expression<Func<CronOperation, Token>> arg)
        {

            Token token = this.Process(arg);
            if (this.CheckSep("seconds", token.Sep))
            {
                CheckChain("seconds", token);
                _express[0] = token.First + token.Sep + token.Second;
                _express[0] = _express[0].TrimEnd(',');
            }
            else
            {
                throw new CronExpressionException("描述不支持该符号");
            }
            return this;
        }

        public ICronExpression Minutes(Expression<Func<CronOperation, Token>> arg)
        {
            Token token = this.Process(arg);
            if (this.CheckSep("minutes", token.Sep))
            {
                CheckChain("minutes", token);
                _express[1] = token.First + token.Sep + token.Second;
                _express[1] = _express[1].TrimEnd(',');
            }
            else
            {
                throw new CronExpressionException("描述不支持该符号");
            }
            return this;
        }

        public ICronExpression Hours(Expression<Func<CronOperation, Token>> arg)
        {
            Token token = this.Process(arg);
            if (this.CheckSep("hours", token.Sep))
            {
                CheckChain("hours", token);
                _express[2] = token.First + token.Sep + token.Second;
                _express[2] = _express[2].TrimEnd(',');
            }
            else
            {
                throw new CronExpressionException("描述不支持该符号");
            }
            return this;

        }

        public ICronExpression Month(Expression<Func<CronOperation, Token>> arg)
        {
            Token token = this.Process(arg);
            if (this.CheckSep("month", token.Sep))
            {
                CheckChain("month", token);
                _express[4] = token.First + token.Sep + token.Second;
                _express[4] = _express[4].TrimEnd(',');
            }
            else
            {
                throw new CronExpressionException("描述不支持该符号");
            }
            return this;
        }

        public ICronExpression DayofWeek(Expression<Func<CronOperation, Token>> arg)
        {
            Token token = this.Process(arg);
            if (this.CheckSep("dayofweek", token.Sep))
            {
                CheckChain("dayofweek", token);
                _express[5] = token.First + token.Sep + token.Second;
                _express[5] = _express[5].TrimEnd(',');
            }
            else
            {
                throw new CronExpressionException("描述不支持该符号");
            }
            return this;
        }

        public ICronExpression Year(Expression<Func<CronOperation, Token>> arg)
        {
            Token token = this.Process(arg);
            if (this.CheckSep("year", token.Sep))
            {
                CheckChain("year", token);
                _express[6] = token.First + token.Sep + token.Second;
                _express[6] = _express[6].TrimEnd(',');
            }
            else
            {
                throw new CronExpressionException("描述不支持该符号");
            }
            return this;
        }
        public ICronExpression DayofMonth(Expression<Func<CronOperation, Token>> arg)
        {
            Token token = this.Process(arg);
            if (this.CheckSep("dayofmonth", token.Sep))
            {
                CheckChain("dayofmonth", token);
                _express[3] = token.First + token.Sep + token.Second;
                _express[3] = _express[3].TrimEnd(',');
            }
            else
            {
                throw new CronExpressionException("描述不支持该符号");
            }
            return this;
        }
    }
}
