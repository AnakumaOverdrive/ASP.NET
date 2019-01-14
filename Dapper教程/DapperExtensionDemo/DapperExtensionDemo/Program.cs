using DapperExtensionDemo.Common;
using DapperExtensionDemo.DAL;
using DapperExtensionDemo.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DapperExtensionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDal testDal = new TestDal();
            List<TestInfo> list = new List<TestInfo>();

            //var result = testDal.Get<TestInfo>(1);

            //var result = testDal.GetList<TestInfo>();

            //TestInfo info = new TestInfo();
            //info.col_Id = 1;
            //info.col_did = "1";
            //info.col_name = "name6";
            //info.col_double = 3.17;
            //info.col_age = 18;
            //info.col_date = DateTime.Now;
            //var result = testDal.Insert(info);

            //list.Add(new TestInfo()
            //{
            //    col_Id = 7,
            //    col_did = "1",
            //    col_name = "name7",
            //    col_double = 3.17,
            //    col_age = 18,
            //    col_date = DateTime.Now
            //});
            //list.Add(new TestInfo()
            //{
            //    col_Id = 8,
            //    col_did = "1",
            //    col_name = "name8",
            //    col_double = 3.17,
            //    col_age = 18,
            //    col_date = DateTime.Now
            //});
            //var result = testDal.Insert<TestInfo>(list);

            //var entity = testDal.Get<TestInfo>(1);
            //entity.col_age = 17;
            //var result = testDal.Update<TestInfo>(entity);

            //var entity = testDal.Get<TestInfo>(7);
            //entity.col_age = 15;
            //list.Add(entity);
            //entity = testDal.Get<TestInfo>(8);
            //entity.col_age = 15;
            //list.Add(entity);
            //var result = testDal.Update<TestInfo>(list);

            //var entity = testDal.Get<TestInfo>(1);
            //var result = testDal.Delete<TestInfo>(entity);

            //var entity = testDal.Get<TestInfo>(7);
            //list.Add(entity);
            //entity = testDal.Get<TestInfo>(8);
            //list.Add(entity);
            //var result = testDal.Delete<TestInfo>(list);

            //TestInfo info = new TestInfo();
            //info.col_Id = 9;
            //info.col_did = "1";
            //info.col_name = "name6";
            //info.col_double = 3.17;
            //info.col_age = 18;
            //info.col_date = DateTime.Now;
            //testDal.Insert(info);
            //var result = testDal.DeleteAll<TestInfo>();

            //PageView pageView = new PageView()
            //{
            //    IsPageView = true,
            //    PageIndex = 1,
            //    PageSize = 5
            //};

            //DataQuery dataQuery = new DataQuery();
            //dataQuery.SqlText = "select * from t_demolitionpoint where 1=1 order by col_index";
            //dataQuery.PageView = pageView;

            ////dataQuery.SqlText += "and col_ID = @Id";
            ////dataQuery.WhereParameters.Add("Id", 57, DbType.Int32);

            //var result = testDal.ExecuteQuery<DemolitionpointInfo>(dataQuery);

            //Console.WriteLine(result);

            //var arr = new  string[]{ "a","b","c","d"};
            //var str = "1";
            //ILookup<string, string> map = arr.ToLookup(u => str);

            //foreach (var sameVals in map)
            //{
            //    Console.WriteLine(map);
            //    foreach (var value in sameVals)
            //    {
            //        Console.WriteLine(value);
            //    }
            //}

            //        Console.WriteLine(map);


            var str1 = "1234567890";
            var str2 = "567";
            var flag1 = str1.Contains(str2);
            var flag2 = str2.Contains(str1);


            var str3 = "棉一宿舍[]（铁路木材[]厂[]）";
            string ss = Regex.Replace(str3, @"\（[^\（]*\）", "");

        }
    }
}
