using Conversion;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace YTConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            const string baseAdddr = "http://localhost:8000/";
            const string testURL = "https://www.youtube.com/watch?v=8XPKrR_g7Mw";
            var host = new Host(baseAdddr);
            host.Start();
            HttpClient client = new HttpClient();
            var res = client.PostAsync(baseAdddr + "api/convert", new StringContent(testURL)).Result;
            res.EnsureSuccessStatusCode();
            Console.WriteLine(res.Headers.ToString());
            Console.ReadLine();
            host.Stop();
        }
    }
}
