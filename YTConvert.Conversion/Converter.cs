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
            Process proc = null;
            string id = null;
            try
            {

                id = url.Split('=')[1];
                proc = new Process()
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
            }
            catch (Exception ex)
            {
                throw new Exception("An unknown error occurred while starting the command line process.", ex);
            }
            if (proc.ExitCode == 0)
                return new ConversionResult() { Extension = "m4a", FileName = $"{id}.m4a" };
            else
                throw new Exception("Command line process exited with error code: " + proc.ExitCode);
        }
    }
}
