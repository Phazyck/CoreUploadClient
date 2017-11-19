using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreUploadClient
{
    class Program
    {
        static int WriteError()
        {
            Console.Error.WriteLine("usage: TODO");
            return -1;
        }

        static async Task UploadAsync(string endpoint)
        {
            

            var client = new HttpClient();
            int bufferSize = 1024 * 1024;
            HttpContent content = new StreamContent(Console.OpenStandardInput(), bufferSize);
            HttpResponseMessage response = await client.PostAsync(endpoint, content);
            
            if (response.IsSuccessStatusCode)
            {

            }
        }

        static int Main(string[] args)
        {
            if (args == null || args.Length <= 0)
            {
                return WriteError();
            }

            string endpoint = args[0];

            if(!Uri.IsWellFormedUriString(endpoint, UriKind.Absolute))
            {
                return WriteError();
            }

            UploadAsync(endpoint).Wait();
            return 0;
        }
    }
}
