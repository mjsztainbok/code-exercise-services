using ProductIngestion.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductIngestion.Processors
{
    public class NumberProcessor : IProcessor<Number>
    {
        public Number ProcessString(string data)
        {
            // Numbers can only be positive so make sure the first character is a digit as a - should not be accepted
            if (!char.IsDigit(data[0]))
            {
                throw new InvalidDataException("The number string is not valid");
            }

            if (!int.TryParse(data, out int value))
            {
                throw new InvalidDataException("The number string is not valid");
            }

            return new Number(value);
        }
    }
}
