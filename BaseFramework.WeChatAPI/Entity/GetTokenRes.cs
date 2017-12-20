using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 获取AccessToken
    /// </summary>
    public class GetTokenRes : BaseRes
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}
