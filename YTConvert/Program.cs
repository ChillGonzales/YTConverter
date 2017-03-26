using Conversion;
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
            const string baseAdddr = "http://*:8000/";
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
        }
    }
}
