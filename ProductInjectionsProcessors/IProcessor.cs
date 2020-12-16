// <copyright file="IProcessor.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion.Processors
{
    using System;

    using ProductIngestion.Types;

    /// <summary>A processor for field data.</summary>
    /// <typeparam name="T">The type of the field data.</typeparam>
    public interface IProcessor<out T>
        where T : IFieldType
    {
        /// <summary>Gets the type of the output from the processor.</summary>
        /// <value>The type of the output.</value>
        Type OutputType => typeof(T);

        /// <summary>Processes the string data to the output field type.</summary>
        /// <param name="data">The data.</param>
        /// <returns>An object representing the parsed string data.</returns>
        /// <exception cref="InvalidDataException">The specified data is invalid.</exception>
        T ProcessString(string data);
    }
}
