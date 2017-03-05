using Conversion;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace YTConvert
{
    [RoutePrefix("api")]
    public class ConvertController : ApiController
    {
        IConverter _converter;
        public ConvertController()//IConverter converter)
        {
            _converter = new Converter();
            //this._converter = converter;
        }
        [Route("convert")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]string url)
        {
            Debug.WriteLine($"URL is {url}");
            _converter.Convert(url);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}
