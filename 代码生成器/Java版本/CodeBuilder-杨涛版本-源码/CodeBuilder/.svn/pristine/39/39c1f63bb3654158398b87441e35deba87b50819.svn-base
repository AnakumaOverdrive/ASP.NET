using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.InterFace;
using System.Data;

namespace Esint.CodeBuilder.InterFace
{
    public interface ICodeBuilder
    {
 
        //数据库类型
        string DataBaseType { get; }

        //应用名称
        string AppName { get;  set;}

        //代码查询语句
        string CodeSQL { get; set; }

        //测试数据库连接
        bool TestConnect(string connectString);

        //得到数据表列表
        List<IDbTable> GetTableList(string connectString);

        //得到视图列表
        List<IDbTable> GetViewList(string connectString);

        //根据表名,查询表详细信息
        IDbTable GetTableByTableName(string connectString, string tag);

        //得到代码列表
        List<ICodeType> GetCodeTypeList(string connectString);

        List<IDbTable> GetSubTables(IDbTable returnTable, string connectString);
    }
}
