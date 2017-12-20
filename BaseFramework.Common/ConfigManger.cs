using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Common
{
    public class ConfigManger
    {
        public static string WebSiteUrl
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["WebSiteUrl"];
            }
        }

        public static string VirtualUrl
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["VirtualUrl"];
            }
        }

        public static string CorpID
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["CorpID"];
            }
        }

        public static string Secret
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Secret"];
            }
        }

        public static string agentid
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Agentid"];
            }
        }
    }
}
