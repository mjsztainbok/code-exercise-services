// <copyright file="NumberProcessor.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion.Processors
{
    using ProductIngestion.Types;

    /// <summary>
    /// A processor for number field data.
    /// </summary>
    /// <seealso cref="IProcessor{T}" />
    public class NumberProcessor : IProcessor<Number>
    {
        /// <summary>Processes the string data to the output field type.</summary>
        /// <param name="data">The data.</param>
        /// <returns>An object representing the parsed string data.</returns>
        /// <exception cref="InvalidDataException">The specified data is invalid.</exception>
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
