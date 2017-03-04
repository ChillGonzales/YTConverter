using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTConvert
{
    public class Host
    {
        public string BaseAddress { get; private set; }
        private IDisposable _host;

        public Host(string baseAddress)
        {
            BaseAddress = baseAddress;
        }
        public void Start()
        {
            _host = WebApp.Start<Startup>(url: BaseAddress);
        }
        public void Stop()
        {
            _host.Dispose();
        }
    }
}
