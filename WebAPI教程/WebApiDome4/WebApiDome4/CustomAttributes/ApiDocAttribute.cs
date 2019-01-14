using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDome4.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method)] 
    public class ApiDocAttribute : Attribute 
    {
        public ApiDocAttribute(string doc)
        {
            Documentation = doc;
        }
        public string Documentation { get; set; } 
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class ApiParameterDocAttribute : Attribute
    {
        public ApiParameterDocAttribute(string param, string doc)
        {
            Parameter = param;
            Documentation = doc;
        }
        public string Parameter { get; set; }
        public string Documentation { get; set; }
    }
}