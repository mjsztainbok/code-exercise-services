namespace ProductIngestion.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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

        public static decimal RoundHalfDownTo4Places(decimal value)
        {
            return RoundHalfDown(value, 4);
        }

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
