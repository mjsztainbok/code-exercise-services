// <copyright file="CurrencyUtils.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion.Types
{
    using System;
    using System.Collections.Generic;

    /// <summary>Currency utility methods.</summary>
    internal static class CurrencyUtils
    {
        private static readonly Dictionary<int, decimal?> PlacesToPowers = new Dictionary<int, decimal?>();

        static CurrencyUtils()
        {
            // Precompute the powers for 0 to 10 decimal places
            for (int i = 0; i <= 10; i++)
            {
                PlacesToPowers[i] = Convert.ToDecimal(Math.Pow(10, i));
            }
        }

        /// <summary>Rounds a decimal value to 4 decimal places using round half down.</summary>
        /// <param name="value">The value.</param>
        /// <returns>The value rounded half down to 4 decimal places.</returns>
        public static decimal RoundHalfDownTo4Places(decimal value)
        {
            return RoundHalfDown(value, 4);
        }

        /// <summary>Rounds a decimal value to the specifed number of decimal places using round half down.</summary>
        /// <param name="value">The value.</param>
        /// <param name="decimalPlaces">The number of decimal places.</param>
        /// <returns>The value rounded half down to the specified number of decimal places.</returns>
        public static decimal RoundHalfDown(decimal value, int decimalPlaces)
        {
            decimal power = PlacesToPowers[decimalPlaces] ?? Convert.ToDecimal(Math.Pow(10, decimalPlaces));
            decimal scaledValue = value * power;
            if (value > 0)
            {
                if (scaledValue - Math.Truncate(scaledValue) <= 0.5m)
                {
                    return Math.Floor(scaledValue) / power;
                }
                else
                {
                    return Math.Ceiling(scaledValue) / power;
                }
            }
            else
            {
                if (Math.Abs(scaledValue - Math.Truncate(scaledValue)) < 0.5m)
                {
                    return Math.Ceiling(scaledValue) / power;
                }
                else
                {
                    return Math.Floor(scaledValue) / power;
                }
            }
        }
    }
}
