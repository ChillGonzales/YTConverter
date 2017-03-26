using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversion
{
    public interface IConverter
    {
        ConversionResult Convert(string url);
    }
}
