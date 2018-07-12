using YTConvert.Conversion;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

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
        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage();
            response.Content = new StringContent("<html><body>You have found the converter page!</body></html>");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }
        [HttpPost]
        [Route("convert")]
        public HttpResponseMessage Post([FromBody]string url)
        {
            var result = _converter.Convert(url);
            var audio = new AudioStream(result.FileName, result.Extension);
            var response = Request.CreateResponse();
            response.Content = new PushStreamContent(audio.GetStreamWriter(), new MediaTypeHeaderValue("audio/mp4"));
            return response;
        }
    }
}
