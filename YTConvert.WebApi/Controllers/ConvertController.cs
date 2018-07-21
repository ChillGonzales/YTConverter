using YTConvert.Conversion;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using YTConvert.WebApi.Models;
using System.Threading.Tasks;

namespace YTConvert
{
    [RoutePrefix("api/v1")]
    public class ConvertController : ApiController
    {
        private static readonly IConverter _converter;
        // TODO: Setup DI
        static ConvertController()
        {
            _converter = new Converter();
        }
        [HttpGet]
        [Route("convert")]
        public async Task<HttpResponseMessage> Get()
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent("<html><body>You have found the converter page!</body></html>");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return await Task.FromResult(response);
        }
        [HttpPost]
        [Route("convert")]
        public HttpResponseMessage Post(ConvertRequest request)
        {
            try
            {
                if (request == null || String.IsNullOrWhiteSpace(request.Url))
                    throw new ArgumentNullException("url");
                var result = _converter.Convert(request.Url);
                //var audio = new AudioStream(result.FileName);
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var fileStream = File.Open(result.FileName, FileMode.Open, FileAccess.Read);
                var memStream = new MemoryStream();
                fileStream.CopyTo(memStream);

                response.Content = new ByteArrayContent(memStream.Write)
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("audio/mp4");
                //response.Content = new PushStreamContent((outputStream, content, context) =>
                //{
                //    try
                //    {
                //        var buffer = new byte[65536];
                //        using (var audioFile = File.Open(result.FileName, FileMode.Open, FileAccess.Read))
                //        {
                //            audioFile.CopyTo(outputStream);
                //            //var length = (int)audioFile.Length;
                //            //var bytesRead = 1;

                //            //while (length > 0 && bytesRead > 0)
                //            //{
                //            //    bytesRead = audioFile.ReadAsync(buffer, 0, Math.Min(length, buffer.Length));
                //            //    await outputStream.WriteAsync(buffer, 0, bytesRead);
                //            //    length -= bytesRead;
                //            //}
                //            outputStream.Flush();
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        throw new Exception("An error occurred while trying to create audio stream from video file.", ex);
                //    }
                //    finally
                //    {
                //        outputStream.Close();
                //    }
                //}, new MediaTypeHeaderValue("audio/mp4"));
                return response;
            }
            catch (Exception ex)
            {
                var ret = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                ret.Content = new StringContent(ex.ToString());
                return ret;
            }
        }
    }
}
