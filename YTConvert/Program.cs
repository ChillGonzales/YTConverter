using Conversion;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Topshelf;

namespace YTConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            const string baseAdddr = "http://localhost:8000/";
            //const string testURL = "https://www.youtube.com/watch?v=v4NENjt4KYE";
            HostFactory.Run(x =>
            {
                x.Service<Host>(s =>
                {
                    s.ConstructUsing(name => new YTConvert.Host(baseAdddr));
                    s.WhenStarted(h => h.Start());
                    s.WhenStopped(h => h.Stop());
                });
                x.RunAsLocalSystem();
                x.SetDescription("Youtube Convert Service");
                x.SetDisplayName("Youtube Converter");
                x.SetServiceName("YTConverter");
            });
            //var host = new Host(baseAdddr);
            //host.Start();
            //HttpClient client = new HttpClient();
            //JsonMediaTypeFormatter jtf = new JsonMediaTypeFormatter();
            //var res = client.PostAsync<string>(baseAdddr + "api/convert", testURL, jtf).Result;
            //res.EnsureSuccessStatusCode();
            //Console.WriteLine(res.Headers.ToString());
            ////Console.ReadLine();
            //host.Stop();
        }
    }
}
