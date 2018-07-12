using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTConvert.Conversion
{
    public class Converter : IConverter
    {
        public ConversionResult Convert(string url)
        {
            var id = url.Split('=')[1];
            var proc = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    WindowStyle = ProcessWindowStyle.Normal,
                    FileName = "CMD.exe",
                    Arguments = $@"/C youtube-dl -x --audio-quality 0 --audio-format m4a -o Videos\%(id)s.%(ext)s {url}{Environment.NewLine}"
                }
            };
            proc.Start();
            proc.WaitForExit();
            if (proc.ExitCode == 0)
            {
                return new ConversionResult() { Extension = "m4a", FileName = $"{id}.m4a", Success = true };
            }
            else
            {
                return new ConversionResult() { Success = false };
            }
        }
    }
}
