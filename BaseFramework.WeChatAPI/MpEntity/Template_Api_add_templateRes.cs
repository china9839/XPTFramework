using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeChatAPI.Entity;

namespace WeChatAPI.MpEntity
{
    /// <summary>
    /// 获取模版Iid
    /// </summary>
    public class Template_Api_add_templateRes : BaseRes
    {
        public string template_id { get; set; }
    }
}
