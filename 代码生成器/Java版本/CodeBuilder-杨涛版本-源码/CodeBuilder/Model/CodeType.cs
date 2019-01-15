using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;

namespace Esint.CodeBuilder.Model
{
    public class CodeType:ICodeType
    {

        #region ICodeType 成员

        public string Flag
        {
            get;
            set;
        }

        public string Meaning
        {
            get;
            set;
        }

        #endregion
    }
}
