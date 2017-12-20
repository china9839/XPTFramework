using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Common
{
    public static class LogHelper
    {
        public static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
        public static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");

        public static void Init()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void Init(FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.Configure(configFile);
        }

        /// <summary>
        /// 普通的文件记录日志
        /// </summary>
        /// <param name="info"></param>
        public static void Info(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }
        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="info"></param>
        /// <param name="se"></param>
        public static void Error(string info, Exception exp)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(info, exp);
            }
        }
    }
}
