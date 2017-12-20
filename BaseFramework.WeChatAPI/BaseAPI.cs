using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeChatAPI.Entity;
using WeChatAPI.iUtil;

namespace WeChatAPI
{
    public class BaseAPI
    {
        #region Get请求并反馈解码后的Json对象
        /// <summary>
        /// Get请求并反馈解码后的Json对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T GetObject<T>(string url, string param = "")
            where T : BaseRes
        {
            TimeoutWebClient wc = ThreadWebClientFactory.GetWebClient();
            wc.Encoding = Encoding.UTF8;
            var json = wc.GetLoadString(url, param);
            var rel = JsonConvert.DeserializeObject<T>(json);
            if (string.IsNullOrEmpty(rel.errcode))
            {
                rel.errcode = "0";
            }
            return rel;
        }
        #endregion

        #region Post请求并反馈解码后的Json对象
        /// <summary>
        /// Post请求并反馈解码后的Json对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        public static T PostObject<T>(string url, string post)
            where T : BaseRes
        {
            TimeoutWebClient wc = ThreadWebClientFactory.GetWebClient();
            wc.Encoding = Encoding.UTF8;
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            var json = wc.PostLoadString(url, post);
            var rel = JsonConvert.DeserializeObject<T>(json);
            if (string.IsNullOrEmpty(rel.errcode))
            {
                rel.errcode = "0";
            }
            return rel;
        }
        #endregion

        #region Post请求并反馈解码后的Json对象
        /// <summary>
        /// Post请求并反馈解码后的Json对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="post"></param>
        /// <returns></returns>
        public static T PostObject<T>(string url, dynamic post)
            where T : BaseRes
        {
            string ps = JsonConvert.SerializeObject(post);
            return PostObject<T>(url, ps);
        }
        #endregion

        #region 上传文件
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="file"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T UploadFile<T>(string file, string url)
            where T : BaseRes
        {
            Process p = new Process();
            string fileargs = " -k -F media=@" + file + " \"" + url + "\"";
            p.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + @"Static\curl.exe";
            p.StartInfo.Arguments = fileargs;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();

            StreamReader reader = p.StandardOutput;
            string json = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
            reader.Close();

            T res = JsonConvert.DeserializeObject<T>(json);
            if (string.IsNullOrEmpty(res.errcode))
            {
                res.errcode = "0";
            }
            return res;
        }
        #endregion
    }
}
