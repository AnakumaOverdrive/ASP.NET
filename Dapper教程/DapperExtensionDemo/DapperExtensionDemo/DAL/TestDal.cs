
using Dapper;
using DapperExtensionDemo.Common;
using DapperExtensionDemo.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExtensionDemo.DAL
{
    /// <summary>
    /// 模块名称：测试用, 与程序,业务,逻辑无关. 数据访问层
    /// 作    者：Esint
    /// 生成日期：2018年05月23日
    /// </summary>
    public partial class TestDal : BaseDal
    {
        
        #region 查询 

        /// <summary>
        /// 获得 测试用, 与程序,业务,逻辑无关.(t_test)的数量
        /// </summary>
        public int GetTestInfoCount()
        {
            string strSql = "SELECT count(*) FROM t_test WHERE 1=1 ";
            int results;
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                results = conn.Query<int>(strSql).FirstOrDefault();
            }
            return results;
        }


        /// <summary>
        /// 获得 测试用, 与程序,业务,逻辑无关.(t_test)列表数据
        /// </summary>
        public IList<TestInfo> GetTestInfoList(int pageIndex, int pageSize)
        {
            string strSql = "SELECT * FROM t_test WHERE 1=1 limit @pageIndex,@pageSize ";
            IList<TestInfo> results;
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                results = conn.Query<TestInfo>(strSql, new { pageIndex = pageIndex, pageSize = pageSize }).ToList();
            }
            return results;
        }

      

        /// <summary>
        /// 根据主键获得 测试用, 与程序,业务,逻辑无关.(t_test) 对象信息
        /// </summary>
        public TestInfo GetTestInfoById(int Id, string Did)
        {
            string strSql = "SELECT * FROM t_test WHERE col_Id = @Id and col_did = @Did ";
            TestInfo entity;
            using (IDbConnection conn = ConnectionFactory.Creator())
            {
                entity = conn.Query<TestInfo>(strSql, new { Id = Id, Did = Did }).SingleOrDefault();
            }
            return entity;
        }

       
        #endregion

        #region 插入数据 
        

        #endregion

        #region 修改 

   

        #endregion

        #region 删除 

 
        #endregion
    }
}
