using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.Common.Data.SqlDAL;
using System.Configuration;

namespace Esint.CodeSite.SqlDAL
{
   
    internal class BasicDataAccess : RootSqlDataAccess
    {
        public BasicDataAccess()
        {
            if (!RootSqlDataAccess.ConnectString.ContainsKey("Default"))
            {
                RootSqlDataAccess.ConnectString["Default"] = ConfigurationSettings.AppSettings["SqlDBConn"];

            }
            CurrentConn = "Default";

            if (string.IsNullOrEmpty(RootSqlDataAccess.IsRecordSQL))
                RootSqlDataAccess.IsRecordSQL = ConfigurationSettings.AppSettings["IsRecordSQL"];
        }

        public BasicDataAccess(string DbConn)
        {
            if (!RootSqlDataAccess.ConnectString.ContainsKey(DbConn))
            {
                RootSqlDataAccess.ConnectString[DbConn] = ConfigurationSettings.AppSettings[DbConn];
            }

            CurrentConn = DbConn;
            if (string.IsNullOrEmpty(RootSqlDataAccess.IsRecordSQL))
                RootSqlDataAccess.IsRecordSQL = ConfigurationSettings.AppSettings["IsRecordSQL"];
        }

    }
}
