using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversion
{
    public class Converter : IConverter
    {
        public void Convert(string url)
        {
            var proc = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    WindowStyle = ProcessWindowStyle.Normal,
                    FileName = "CMD.exe",
                    Arguments = $"youtube-dl -x --audio-quality 0 {url}"
                }
            };
            proc.Start();
        }
    }
}
