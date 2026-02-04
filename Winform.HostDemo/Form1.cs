using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace Winform.HostDemo
{
    public partial class Form1 : Form
    {
        private IDisposable _webApp;
        private const string BaseAddress = "http://localhost:9000/";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWebApp_Click(object sender, EventArgs e)
        {
            try
            {
                // 启动 Web 服务
                _webApp = WebApp.Start<StartUp>(url: BaseAddress);
                txtMessageLog.AppendText("Web 服务已启动，监听地址: " + BaseAddress + Environment.NewLine);
                btnWebApp.Enabled = false;
            }
            catch (Exception ex)
            {
                txtMessageLog.AppendText("启动 Web 服务失败: " + ex.Message + Environment.NewLine);
            }
        }

        private const string BaseApiUrl = BaseAddress + "iIot/api/user/";
        private void btnGet_Click(object sender, EventArgs e)
        {
            string getUrl = BaseApiUrl + "status";
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(getUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    txtMessageLog.AppendText("GET 响应: " + result + Environment.NewLine);
                }
                else
                {
                    txtMessageLog.AppendText("GET 请求失败: " + response.StatusCode + Environment.NewLine);
                }
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            string postUrl = BaseApiUrl + "post";

            var postData = new
            {
                Name = "张三",
                Age = 30
            };

            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(postUrl, postData).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    txtMessageLog.AppendText("POST 响应: " + result + Environment.NewLine);
                }
                else
                {
                    txtMessageLog.AppendText("POST 请求失败: " + response.StatusCode + Environment.NewLine);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 释放资源，停止 Web 服务
            if (_webApp != null)
            {
                _webApp.Dispose();
            }
        }
    }
}
