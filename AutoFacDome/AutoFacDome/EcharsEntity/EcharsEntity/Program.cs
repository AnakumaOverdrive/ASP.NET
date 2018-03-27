using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace EcharsEntity
{
    class Program
    {
        static void Main(string[] args)
        {

            var option = new EcharsOption()
            {
                title = new EcharsTitle() { text = "asdasd" },
                tooltip = new EcharsTooltip()
                {
                    trigger = EcharsTooltipTarget.axis,
                    axisPointer = new EcharsAxisPointer() { type =EcharsAxisPointerType.shadow }
                },
                legend = new EcharsLegend() { data = new object[] { "满意", "不满意" } },
                grid = new EcharsGrid()
                {
                    left = "3%",
                    //left = EcharsGridLeft.left,
                    right = "4%",
                    bottom = "3%",
                    containLabel = true
                },
                xAxis = new EcharsXAxis()
                {
                    type =EcharsXAxisType.value
                },
                yAxis = new EcharsYAxis()
                {
                    type =EcharsYAxisType.category,
                    data = new object[] { "一月", "二月", "三月", "四月", "五月", "六月", "七月" }
                },
                series = new List<EcharsSeries>()
                {
                    new EcharsSeries()
                    {
                        name= "满意",
                        type= "bar",
                        stack= "总量",
                        label = new EcharsLabel()
                        {
                            normal = new EcharsNormal()
                            {
                                show = true,
                                position = "insideRight"
                            }
                        },
                        data  = new object[]{120, 132, 101, 134, 90, 230, 210}
                    },
                    new EcharsSeries()
                    {
                        name= "不满意",
                        type= "bar",
                        stack= "总量",
                        label = new EcharsLabel()
                        {
                            normal = new EcharsNormal()
                            {
                                show = true,
                                position = "insideRight"
                            }
                        },
                        data  = new object[]{320, 302, 301, 334, 390, 330, 320}
                    }
                }


            };
            Console.WriteLine(ConvertTJson(option));
            Console.Read();
        }

        /// 将对象转换为JSON串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ConvertTJson(Object obj)
        {
            string JsonStr = JsonConvert.SerializeObject(obj, Formatting.None);
            JsonStr = JsonStr.Replace(":null,", ":\"\",");
            return JsonStr;
        }
    }
}
