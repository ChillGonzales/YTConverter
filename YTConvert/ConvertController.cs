using Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
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
            this._converter = converter;
        }
        [Route("api/convert")]
        public void Post([FromBody]string url)
        {
            bool result = _converter.Convert(url);
        }
    }
}
