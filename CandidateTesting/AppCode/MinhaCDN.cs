using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.MatheusBauabBressan.AppCode
{
    public class MinhaCDN
    {
        public async Task<string> GetLog(string url)
        {
            string log = string.Empty;

            if (!string.IsNullOrEmpty(url))
            {
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage();

                request.RequestUri = new Uri(url);
                request.Method = HttpMethod.Get;

                var response = await httpClient.SendAsync(request);
                log = await response.Content.ReadAsStringAsync();
            }
            else
            {
                Console.WriteLine("Log Url is invalid");
            }

            return log;
        }
    }
}
