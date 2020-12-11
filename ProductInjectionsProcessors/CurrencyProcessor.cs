﻿namespace ProductIngestion.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ProductIngestion.Types;

    public class CurrencyProcessor : IProcessor<Currency>
    {
        public Currency ProcessString(string data)
        {
            if (data[0] is not('-' or '0'))
            {
                throw new InvalidDataException("The currency string is invalid");
            }

            if (!decimal.TryParse(data, out decimal value))
            {
                throw new InvalidDataException("The currency string is invalid");
            }

            // The last 2 digits are actually the cents values
            if (value != 0m)
            {
                value /= 100;
            }

            return new Currency(value);
        }
    }
}
