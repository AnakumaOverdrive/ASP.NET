using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esint.Common.Data
{
    public class WhereParameter
    {
        public WhereParameter(string whereExpression, string parameterName, object value, bool nullAndQuery)
        {
            ParameterName = parameterName;
            Value = value;
            WhereExpression = whereExpression;
            NullAndQuery = nullAndQuery;
        }

        public WhereParameter(string whereExpression, string parameterName, object value)
        {
            ParameterName = parameterName;
            Value = value;
            WhereExpression = whereExpression;
            NullAndQuery = false;
        }

        public WhereParameter(string parameterName, object value)
        {
            ParameterName = parameterName;
            Value = value;
            WhereExpression = "";
            NullAndQuery = false;
        }

        public string WhereExpression { get; set; }
        public string ParameterName { get; set; }
        public object Value { get; set; }
        public bool NullAndQuery { get; set; }
    }
}
