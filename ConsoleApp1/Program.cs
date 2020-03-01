using System;
using System.Net.Http;
using System.Threading.Tasks;


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
            }

            Console.ReadKey();
        }
    }
}
