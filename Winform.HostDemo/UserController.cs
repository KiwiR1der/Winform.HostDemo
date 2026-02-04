using System;
using System.Web.Http;

namespace Winform.HostDemo
{
    public class UserData
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    [RoutePrefix("iIot/api/user")]   // 设置路由前缀，用于区分不同的控制器，匹配路径 iIot/api/user
    public class UserController : ApiController
    {
        // GET 
        [HttpGet]
        [Route("status")]   // 完整路径为 iIot/api/user/status
        public IHttpActionResult GetStatus()
        {
            return Ok(new { Message = "服务正在运行", Time = DateTime.Now });
        }

        // Post 
        [HttpPost]
        [Route("post")] // 完整路径为 iIot/api/user/post
        public IHttpActionResult ReceiveData([FromBody] UserData data)
        {
            if (data == null)
            {
                return BadRequest("数据不能为空");
            }
                
            // 这里处理接收到的数据，例如显示在消息框中
            // 注意：在实际应用中，避免在Web API中使用MessageBox，因为它会阻塞线程
            // 注意：如果你需要更新 WinForm UI，必须适用 Invoke，因为这里是后台线程

            string responseMsg = $"收到数据: Name = {data.Name}, Age = {data.Age}";
            return Ok(new { Result = true, Message = responseMsg });
        }
    }
}
