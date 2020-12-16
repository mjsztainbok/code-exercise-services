// <copyright file="Number.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion.Types
{
    using System.Diagnostics;

    /// <summary>A type which represents a number.</summary>
    [DebuggerDisplay("value = {Value}")]
    public class Number : IFieldType<int>
    {
        /// <summary>Initializes a new instance of the <see cref="Number" /> class.</summary>
        /// <param name="value">The value.</param>
        public Number(int value)
        {
            this.Value = value;
        }

        /// <summary>Gets the value.</summary>
        /// <value>The value.</value>
        public int Value { get; }

        /// <summary>Performs an implicit conversion from <see cref="Number" /> to <see cref="int" />.</summary>
        /// <param name="number">The number.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator int(Number number) => number.Value;
    }
}
