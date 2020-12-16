// <copyright file="StringProcessor.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion.Processors
{
    using String = ProductIngestion.Types.String;

    /// <summary>
    /// A processor for string field data.
    /// </summary>
    /// <seealso cref="IProcessor{T}" />
    public class StringProcessor : IProcessor<String>
    {
        /// <summary>Processes the string data to the output field type.</summary>
        /// <param name="data">The data.</param>
        /// <returns>An object representing the parsed string data.</returns>
        /// <exception cref="InvalidDataException">The specified data is invalid.</exception>
        public String ProcessString(string data)
        {
            return new String(data);
        }
    }
}
