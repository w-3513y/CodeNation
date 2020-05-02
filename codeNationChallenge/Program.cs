using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace codeNationChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var requisicaoWeb = WebRequest.CreateHttp("https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token=getToken");
            requisicaoWeb.Method = "GET";            
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                var post = JsonConvert.DeserializeObject<Post>(objResponse.ToString());
                Console.WriteLine("número de casas:      " + post.numero_casas + "\n" +
                                  "token:                " + post.Token + "\n" +
                                  "cifrado:              " + post.Cifrado + "\n" +
                                  "decifrado:            " + post.decifrado + "\n" +
                                  "resumo criptografico: " + post.resumo_criptografico);
                Console.WriteLine();
                Console.ReadLine();
                streamDados.Close();
                resposta.Close();
            }
            Console.ReadLine();
        }

    }

}
