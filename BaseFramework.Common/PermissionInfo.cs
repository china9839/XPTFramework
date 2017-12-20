using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Common
{
    public class PermissionInfo
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsChecked { get; set; }

        public List<PermissionInfo> ChildPermissionInfo { get; set; }
    }
}
