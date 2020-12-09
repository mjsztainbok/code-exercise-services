using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductIngestion.Types;

using String = ProductIngestion.Types.String;

namespace ProductIngestion.Processors
{
    public class StringProcessor : IProcessor<String>
    {
        public String ProcessString(string data)
        {
            return new String(data);
        }
    }
}
