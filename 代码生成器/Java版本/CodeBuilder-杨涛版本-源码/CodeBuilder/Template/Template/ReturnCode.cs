using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;
namespace Esint.Template
{
    public class ReturnCode : IReturnCode
    {
        #region IReturnCode 成员

        public StringBuilder CodeText
        {
            get;
            set;
        }

        public string CodeType
        {
            get;
            set;
        }

        public string FileName
        {
            get;
            set;
        }

        public string FilePath
        {
            get;
            set;
        }

        #endregion
    }
}