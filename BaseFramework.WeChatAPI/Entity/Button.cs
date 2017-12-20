using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatAPI.Entity
{
    /// <summary>
    /// 应用菜单按钮
    /// </summary>
    public class Button
    {
        public string name { get; set; }
        public string type { get; set; }
        public string key { get; set; }
        public string url { get; set; }

        public List<Button> sub_button { get; set; }

    }
}
