using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Esint.CodeBuilder.Model;
using Esint.CodeBuilder.InterFace;
using System.Data;

namespace Esint.CodeBuilder.Model
{
    public interface ICodeBuilder
    {
        //测试数据库连接
        bool TestConnect(string connectString);

        //得到数据表列表
        List<IDbTable> GetTableList(string connectString);

        //得到视图列表
        List<IDbTable> GetViewList(string connectString);

        //根据表名,查询表详细信息
        IDbTable GetTableByTableName(string connectString, string tag);

        //得到代码列表
        DataTable GetCodeTypeList(string connectString);
    }
}
