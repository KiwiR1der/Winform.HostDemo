using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform.HostDemo.ZC
{
    public class ApiResponse
    {
        public int code { get; set; }
        public object data { get; set; } // 使用 object 方便直接塞入匿名类或字典
        public string msg { get; set; }
        public bool success { get; set; }
    }
}
