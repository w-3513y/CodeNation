using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Globalization;

namespace codeNationChallenge
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {

            var token = "?token=c91593ad6e9402f3ed01eb61096bc444f61e5ef5";
            var url = "https://api.codenation.dev/v1/challenge/dev-ps/";


            using var client = new HttpClient();
            //request
            string contentGet = await client.GetStringAsync(url + "generate-data" + token);
            ResponseJson responseJson = JsonConvert.DeserializeObject<ResponseJson>(contentGet);
            var jsonPost = JsonConvert.SerializeObject(responseJson);
            if (File.Exists(@"E:\answer.json"))
            {
                File.Delete(@"E:\answer.json");
            }
            File.AppendAllText(@"E:\answer.json", jsonPost);
            Console.WriteLine(responseJson);

            //post            
            byte[] byteArray = File.ReadAllBytes(@"E:\answer.json");
            using var contentPost = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture))
                {
                    { new StreamContent(new MemoryStream(byteArray)), "answer", "answer" }
                };

            using HttpResponseMessage message = await client.PostAsync(url + "submit-solution" + token, contentPost);
            string input = await message.Content.ReadAsStringAsync();
            Console.WriteLine("\n"+message);
            Console.WriteLine("\n"+input);
            Console.ReadLine();
        }        
    }

}
