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
        public int Convert(string url)
        {
            var proc = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    WindowStyle = ProcessWindowStyle.Normal,
                    FileName = "CMD.exe",
                    Arguments = $@"/C youtube-dl -x --audio-quality 0 --audio-format m4a -o Videos\%(title)s.%(ext)s {url}"
                }
            };
            proc.Start();
            proc.WaitForExit();
            return proc.ExitCode;
        }
    }
}
