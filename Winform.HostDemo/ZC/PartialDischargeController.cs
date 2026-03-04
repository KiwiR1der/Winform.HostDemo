using System;
using System.Web.Http;

namespace Winform.HostDemo.ZC
{
    [RoutePrefix("iIOT/partialDischarge")]
    public class PartialDischargeController : ApiController
    {
        [HttpPost]
        [Route("send_partial_discharge_data")]
        public IHttpActionResult SenData([FromBody] PartialDischargeRequest request)
        {
            if (request == null)
            {
                return Ok(new ApiResponse
                {
                    code = 400,
                    data = new { },
                    msg = "请求数据不能为空",
                    success = false
                });
            }

            // 2. 这里可以加点控制台打印，方便你在测试时看到数据真的进来了
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] 收到局放数据上传请求！");
            Console.WriteLine($"产品编码: {request.product_code}, 起始电压: {request.pdiv}");

            // 3. 构造模拟的成功返回数据
            var response = new ApiResponse
            {
                code = 200,
                data = new
                {
                    // 模拟生成一个流水号返回给调用方
                    record_id = "REC_" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper()
                },
                msg = "数据上传成功 (OWin Mock后端)",
                success = true
            };

            // 4. 返回 200 OK 状态码以及 JSON 数据
            return Ok(response);
        }
    }
}
