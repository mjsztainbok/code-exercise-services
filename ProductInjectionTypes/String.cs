// <copyright file="String.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion.Types
{
    using System.Diagnostics;

    /// <summary>A type which represents a string.</summary>
    [DebuggerDisplay("value = {Value}")]
    public class String : IFieldType<string>
    {
        /// <summary>Initializes a new instance of the <see cref="String" /> class.</summary>
        /// <param name="value">The value.</param>
        public String(string value)
        {
            this.Value = value != null ? value.Trim() : value;
        }

        /// <summary>Gets the value.</summary>
        /// <value>The value.</value>
        public string Value { get; }

        /// <summary>Performs an implicit conversion from <see cref="String" /> to <see cref="string" />.</summary>
        /// <param name="str">The string.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator string(String str) => str.Value;
    }
}
