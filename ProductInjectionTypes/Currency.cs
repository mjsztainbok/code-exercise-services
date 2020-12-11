namespace ProductIngestion.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [DebuggerDisplay("value = {Value}")]
    public class Currency : IFieldType<decimal>
    {
        public Currency(decimal value)
        {
            this.Value = value;
        }

        public decimal Value { get; }

        public static implicit operator decimal(Currency currency) => currency.Value;

        public static Currency operator /(Currency currency, Number num) => currency.Divide(num);

        public static Currency operator /(Currency currency, int num) => currency.Divide(num);

        public Currency Divide(Number num)
        {
            return this.Divide(num.Value);
        }

        public Currency Divide(int num)
        {
            // Round the result to 4 decimal places
            decimal newValue = CurrencyUtils.RoundHalfDownTo4Places(this.Value / num);
            return new Currency(newValue);
        }
    }
}
