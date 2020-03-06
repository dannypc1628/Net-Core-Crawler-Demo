using System;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;


namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();

            string url = "https://dannyliu.me";
            var responseMessage = await httpClient.GetAsync(url); //發送請求

            //檢查回應的伺服器狀態StatusCode是否是200 OK
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string response = responseMessage.Content.ReadAsStringAsync().Result;//取得內容
                
                Console.WriteLine(response);

                // 使用AngleSharp時的前置設定
                var config = Configuration.Default;
                var context = BrowsingContext.New(config);

                //將我們用httpclient拿到的資料放入res.Content中())
                var document = await context.OpenAsync(res => res.Content(response));

                //QuerySelector("head")找出<head></head>元素
                var head = document.QuerySelector("head");
                Console.WriteLine(head.ToHtml());

                //QuerySelector(".entry-content")找出class="entry-content"的所有元素
                var contents = document.QuerySelectorAll(".entry-content");

                foreach (var c in contents)
                {
                    //取得每個元素的TextContent
                    Console.WriteLine(c.TextContent);
                }

            }
            
            Console.ReadKey();
        }
    }
}
