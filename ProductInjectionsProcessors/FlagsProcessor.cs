// <copyright file="FlagsProcessor.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion.Processors
{
    using System.Collections.Immutable;

    using ProductIngestion.Types;

    /// <summary>
    /// A processor for flag field data.
    /// </summary>
    /// <seealso cref="IProcessor{T}" />
    public class FlagsProcessor : IProcessor<Flags>
    {
        /// <summary>Processes the string data to the output field type.</summary>
        /// <param name="data">The data.</param>
        /// <returns>An object representing the parsed string data.</returns>
        /// <exception cref="InvalidDataException">The specified data is invalid.</exception>
        public Flags ProcessString(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new InvalidDataException("The flags string cannot be null or empty");
            }

            var builder = ImmutableArray.CreateBuilder<bool>(data.Length);
            foreach (char c in data)
            {
                // Only Y and N are acceptable characters for a flag
                if (c != 'Y' && c != 'N')
                {
                    throw new InvalidDataException("The flags string contains invalid characters");
                }

                builder.Add(c == 'Y');
            }

            return new Flags(builder.ToImmutable());
        }
    }
}
