using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace WeChatAPI.iUtil
{
    /// <summary>
    /// 扩展了自定超时时间的WebClient
    /// </summary>
    public class TimeoutWebClient : WebClient
    {
        public TimeoutWebClient(int TimeOut)
        {
            this.TimeOut = TimeOut;
        }
        public int TimeOut { get; set; }

        #region 重写GetWebRequest,添加WebRequest对象超时时间
        /// <summary>
        /// 重写GetWebRequest,添加WebRequest对象超时时间
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            request.Timeout = 1000 * TimeOut;
            request.ReadWriteTimeout = 1000 * TimeOut;
            return request;
        }
        #endregion

        #region POST提交数据并下载字节数组
        /// <summary>
        /// POST提交数据并下载字节数组
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] PostLoadData(string url, string data)
        {
            this.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            return this.UploadData(url, "POST", this.Encoding.GetBytes(data));
        }

        /// <summary>
        /// POST提交数据并下载字节数组
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] PostLoadData(string url, Dictionary<string, string> param)
        {
            string data = string.Join("&", param.Select(a => a.Key + "=" + System.Web.HttpUtility.UrlEncode(a.Value, this.Encoding)));
            return PostLoadData(url, data);
        }
        #endregion

        #region POST提交数据并下载字符串
        /// <summary>
        /// POST提交数据并下载字符串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public string PostLoadString(string url, string data)
        {
            return this.Encoding.GetString(PostLoadData(url, data));
        }

        /// <summary>
        /// POST提交数据并下载字符串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public string PostLoadString(string url, Dictionary<string, string> param)
        {
            string data = string.Join("&", param.Select(a => a.Key + "=" + System.Web.HttpUtility.UrlEncode(a.Value, this.Encoding)));
            return PostLoadString(url, data);
        }
        #endregion

        #region GET提交数据并下载字节数组
        /// <summary>
        /// GET提交数据并下载字节数组
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] GetLoadData(string url, string data)
        {
            this.Headers.Add("Content-Type", "text/html");
            var _url = url;
            if (!string.IsNullOrEmpty(data))
            {
                _url = _url + "?" + data;
            }
            return this.DownloadData(_url);
        }

        /// <summary>
        /// POST提交数据并下载字节数组
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] GetLoadData(string url, Dictionary<string, string> param)
        {
            string data = string.Join("&", param.Select(a => a.Key + "=" + System.Web.HttpUtility.UrlEncode(a.Value, this.Encoding)));
            return GetLoadData(url, data);
        }
        #endregion

        #region Get提交数据并下载字符串
        /// <summary>
        /// Get提交数据并下载字符串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public string GetLoadString(string url, string data)
        {
            return this.Encoding.GetString(GetLoadData(url, data));
        }

        /// <summary>
        /// Get提交数据并下载字符串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public string GetLoadString(string url, Dictionary<string, string> param)
        {
            string data = string.Join("&", param.Select(a => a.Key + "=" + System.Web.HttpUtility.UrlEncode(a.Value, this.Encoding)));
            return GetLoadString(url, data);
        }
        #endregion
    }
}
