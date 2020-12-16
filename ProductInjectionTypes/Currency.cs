// <copyright file="Currency.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion.Types
{
    using System.Diagnostics;

    /// <summary>A type which represents currency.</summary>
    [DebuggerDisplay("value = {Value}")]
    public class Currency : IFieldType<decimal>
    {
        /// <summary>Initializes a new instance of the <see cref="Currency" /> class.</summary>
        /// <param name="value">The value.</param>
        public Currency(decimal value)
        {
            this.Value = value;
        }

        /// <summary>Gets the value.</summary>
        /// <value>The value.</value>
        public decimal Value { get; }

        /// <summary>Performs an implicit conversion from <see cref="Currency" /> to <see cref="decimal" />.</summary>
        /// <param name="currency">The currency.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator decimal(Currency currency) => currency.Value;

        /// <summary>Implements the operator /.</summary>
        /// <param name="currency">The currency.</param>
        /// <param name="divisor">The divisor.</param>
        /// <returns>The result of the operator.</returns>
        public static Currency operator /(Currency currency, Number divisor) => currency.Divide(divisor);

        /// <summary>Implements the operator /.</summary>
        /// <param name="currency">The currency.</param>
        /// <param name="divisor">The divisor.</param>
        /// <returns>The result of the operator.</returns>
        public static Currency operator /(Currency currency, int divisor) => currency.Divide(divisor);

        /// <summary>Divides the currency by the specified divisor.</summary>
        /// <param name="divisor">The divisor.</param>
        /// <returns>The result of the division.</returns>
        public Currency Divide(Number divisor)
        {
            return this.Divide(divisor.Value);
        }

        /// <summary>Divides the currency by the specified divisor.</summary>
        /// <param name="divisor">The divisor.</param>
        /// <returns>The result of the division.</returns>
        public Currency Divide(int divisor)
        {
            // Round the result to 4 decimal places
            decimal newValue = CurrencyUtils.RoundHalfDownTo4Places(this.Value / divisor);
            return new Currency(newValue);
        }
    }
}
