using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "videos");
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            try
            {

                id = url.Split('=')[1];
                proc = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        WindowStyle = ProcessWindowStyle.Normal,
                        FileName = "CMD.exe",
                        Arguments = $@"/C youtube-dl -x --audio-quality 0 --audio-format m4a -o " + '"' + $@"{directory}\{id}.m4a" + '"' + $" {url}"
                    }
                };
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                throw new Exception("An unknown error occurred while starting the command line process.", ex);
            }
            var filename = Path.Combine(directory, id + ".m4a");
            if (proc.ExitCode > 1)
                return new ConversionResult() { Extension = "m4a", FileName = filename };
            else
                throw new Exception("Command line process exited with error code: " + proc.ExitCode);
        }
    }
}
