// <copyright file="InputData.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion
{
    using System.Collections.Generic;
    using System.Linq;

    using ProductIngestion.Types;

    /// <summary>
    /// The data read and parsed from the input.
    /// </summary>
    internal class InputData
    {
        private readonly Dictionary<string, IFieldType> values = new ();

        /// <summary>
        /// Gets the value names.
        /// </summary>
        /// <value>
        /// The value names.
        /// </value>
        public IReadOnlySet<string> ValueNames => this.values.Keys.ToHashSet();

        /// <summary>
        /// Gets the value of the field with specified name.
        /// </summary>
        /// <typeparam name="T">The type of the parsed field data.</typeparam>
        /// <param name="name">The name of the field.</param>
        /// <returns>The parsed field data.</returns>
        public T Get<T>(string name)
            where T : IFieldType
        {
            return (T)this.values[name];
        }

        /// <summary>
        /// Gets the raw value of the field with the specified name.
        /// </summary>
        /// <typeparam name="T">The type of the raw value.</typeparam>
        /// <param name="name">The name of the field.</param>
        /// <returns>The raw field data value.</returns>
        public T GetValue<T>(string name)
        {
            return ((IFieldType<T>)this.values[name]).Value;
        }

        /// <summary>
        /// Sets the value of the field with the specified name.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        /// <param name="value">The value of the field.</param>
        public void Set(string name, IFieldType value)
        {
            this.values[name] = value;
        }
    }
}
