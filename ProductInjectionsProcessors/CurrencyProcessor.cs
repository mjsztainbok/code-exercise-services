// <copyright file="CurrencyProcessor.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion.Processors
{
    using ProductIngestion.Types;

    /// <summary>
    /// A processor for currency field data.
    /// </summary>
    /// <seealso cref="IProcessor{T}" />
    public class CurrencyProcessor : IProcessor<Currency>
    {
        /// <summary>Processes the string data to the output field type.</summary>
        /// <param name="data">The data.</param>
        /// <returns>An object representing the parsed string data.</returns>
        /// <exception cref="InvalidDataException">The specified data is invalid.</exception>
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
