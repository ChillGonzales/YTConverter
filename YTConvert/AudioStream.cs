using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YTConvert
{
    public class AudioStream
    {
        string _filelocation;
        string _ext;
        public AudioStream(string filename, string ext)
        {
            _ext = ext;
            _filelocation = Assembly.GetExecutingAssembly().Location + @"\" + filename + "." + _ext;
        }
        public async void WriteToStream(Stream outputStream, HttpContent content, TransportContext context)
        {
            try
            {
                var buffer = new byte[65536];

                using (var audio = File.Open(_filelocation, FileMode.Open, FileAccess.Read))
                {
                    var length = (int)audio.Length;
                    var bytesRead = 1;

                    while (length > 0 && bytesRead > 0)
                    {
                        bytesRead = audio.Read(buffer, 0, Math.Min(length, buffer.Length));
                        await outputStream.WriteAsync(buffer, 0, bytesRead);
                        length -= bytesRead;
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                outputStream.Close();
            }
        }
    }
}
