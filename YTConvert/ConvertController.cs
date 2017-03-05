using Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace YTConvert
{
    public class ConvertController : ApiController
    {
        IConverter _converter;
        public ConvertController(IConverter converter)
        {
            if (converter == null)
            {
                throw new Exception("DI isn't working!");
            }
            this._converter = converter;
        }
        [Route("api/convert")]
        public HttpResponseMessage Post([FromBody]string url)
        {
            _converter.Convert(url);
            return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
        }
    }
}
