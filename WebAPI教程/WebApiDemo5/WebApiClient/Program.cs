using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //var credCache = new CredentialCache();
            //credCache.Add(new Uri("http://192.168.3.23:8080"), "Digest", new NetworkCredential("admin", "admin", "iMC RESTful Web Services"));
            //var httpClient = new HttpClient(new HttpClientHandler { Credentials = credCache });
            //httpClient.BaseAddress = new Uri("http://192.168.3.23:8080");
            //// 为JSON格式添加一个Accept报头
            //httpClient.DefaultRequestHeaders.Accept.Add(
            //    new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = httpClient.GetAsync("http://192.168.3.23:8080/imcrs/plat/res/device").Result;

            var helper = new HttpClientHelper("http://192.168.3.23:8080/imcrs", "admin", "admin");

            string uri = "plat/res/device";

            string returnJson = helper.Get(uri);
            var deviceList = JsonConvert.DeserializeObject<DeviceList>(returnJson.Replace("@", ""));
            foreach (var deviceInfo in deviceList.device)
            {
                Console.WriteLine("{0}-{1}-{2}-{3}-{4}", deviceInfo.id, deviceInfo.label, deviceInfo.label, deviceInfo.ip, deviceInfo.Link.href);
            }

            //添加设配
            var jSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            //var data = JsonConvert.SerializeObject(new {nameOrIp = "192.168.3.165"},Formatting.Indented, jSetting);
            //returnJson = helper.Post(uri, data);

            //删除设备
            //var data = JsonConvert.SerializeObject(new { id = "4" }, Formatting.Indented, jSetting);
            //returnJson = helper.Delete(uri, data);

            //uri = string.Format("plat/res/device/{0}/delete", 4);
            //returnJson = helper.Put(uri, "");

            Console.WriteLine(returnJson);
            Console.WriteLine("==完成==");
            Console.Read();
        }
    }

    public class DeviceList
    {
        public IEnumerable<DeviceInfo> device { get; set; }
    }
}
