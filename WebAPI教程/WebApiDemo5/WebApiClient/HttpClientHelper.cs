using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public class HttpClientHelper
    {
        /// <summary>
        /// 编码类型
        /// </summary>
        private const string _encoded = "UTF-8";

        /// <summary>
        /// 请求根目录
        /// </summary>
        private readonly string _baseUri;

        /// <summary>
        /// 需要授权的用户名
        /// </summary>
        private readonly string _baseUserName;

        /// <summary>
        /// 需要授权的密码
        /// </summary>
        private readonly string _basePassWord;

        /// <summary>
        /// 请求头
        /// 代表发送端（客户端）希望接受的数据类型。 
        /// </summary>
        public HttpType AcceptType = HttpType.Json;

        /// <summary>
        /// 实体头
        /// 代表发送端（客户端|服务器）发送的实体数据的数据类型。 
        /// </summary>
        public HttpType ContentType = HttpType.Json;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseUri">请求根目录</param>
        public HttpClientHelper(string baseUri)
            : this(baseUri,null,null)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="userName">授权用户名</param>
        /// <param name="passWord">授权密码</param>
        public HttpClientHelper(string baseUri, string userName, string passWord)
        {
            this._baseUri = baseUri;
            this._baseUserName = userName;
            this._basePassWord = passWord;
            
        }

        /// <summary>
        /// GET方式实现
        /// </summary>
        /// <param name="uri">接口地址</param>
        /// <returns>网络报文</returns>
        public string Get(string uri)
        {
            return CommonHttpRequest(uri);
        }

        /// <summary>
        /// POST方式实现
        /// </summary>
        /// <param name="uri">接口地址</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public string Post(string uri, string data)
        {
            return CommonHttpRequest(uri, "POST", data);
        }

        /// <summary>
        /// PUT方式实现
        /// </summary>
        /// <param name="uri">接口地址</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public string Put(string uri, string data)
        {
            return CommonHttpRequest(uri, "PUT", data);
        }

        /// <summary>
        /// DELETE方式实现
        /// </summary>
        /// <param name="uri">接口地址</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public string Delete(string uri, string data)
        {
            return CommonHttpRequest(uri, "DELETE", data);
        }

        #region private
        /// <summary>
        /// 实现请求
        /// </summary>
        /// <param name="uri">请求地址</param>
        /// <param name="type">请求方式</param>
        /// <param name="data">请求数据</param>
        /// <returns>请求内容</returns>
        private string CommonHttpRequest(string uri, string type = "GET", string data = "")
        {
            var url = string.Format("{0}/{1}", _baseUri, uri);

            //构造http请求的对象
            var myRequest = (HttpWebRequest)WebRequest.Create(url);
            //授权登录
            if (!string.IsNullOrEmpty(_baseUserName) && !string.IsNullOrEmpty(_basePassWord))
            {
                myRequest.Credentials = new NetworkCredential(_baseUserName, _basePassWord);
            }

            //设置请求头
            switch (AcceptType)
            {
                case HttpType.Json:
                    myRequest.Accept = "application/json";
                    break;
                case HttpType.Xml:
                    myRequest.Accept = "application/xml";
                    break;
                default:
                    myRequest.Accept = "application/json";
                    break;
            }

            //设置实体头
            switch (ContentType)
            {
                case HttpType.Json:
                    myRequest.ContentType = "application/json";
                    break;
                case HttpType.Xml:
                    myRequest.ContentType = "application/xml";
                    break;
                default:
                    myRequest.ContentType = "application/json";
                    break;     
            }

            myRequest.MaximumAutomaticRedirections = 1;
            myRequest.AllowAutoRedirect = true;

            if (!string.IsNullOrEmpty(data))
            {
                //转成网络流
                byte[] buf = Encoding.GetEncoding(_encoded).GetBytes(data);
                //设置
                myRequest.Method = type;
                myRequest.ContentLength = buf.Length;
                // 发送请求
                var newStream = myRequest.GetRequestStream();
                newStream.Write(buf, 0, buf.Length);
                newStream.Close();
            }
            // 获得接口返回值
            var myResponse = (HttpWebResponse)myRequest.GetResponse();

            // ReSharper disable once AssignNullToNotNullAttribute
            var reader = new StreamReader(stream: myResponse.GetResponseStream(), encoding: Encoding.UTF8);
            string results = reader.ReadToEnd();
            reader.Close();
            myResponse.Close();
            return results;

        }
        #endregion
    }

    ///<summary>
    ///http 格式
    ///</summary>
    public enum HttpType
    {
        /// <summary>
        /// xml格式
        /// </summary>
        Xml,
        /// <summary>
        /// json格式
        /// </summary>
        Json
    }

}
