using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductIngestion.Types
{
    [DebuggerDisplay("value = {Value}")]
    public class Currency : IFieldType<decimal>
    {
        public Currency(decimal value)
        {
            this.Value = value;
        }

        public decimal Value { get; }

        public Currency Divide(Number num)
        {
            return Divide(num.Value);
        }

        public Currency Divide(int num)
        {
            // Round the result to 4 decimal places
            decimal newValue = CurrencyUtils.RoundHalfDownTo4Places(Value / num);
            return new Currency(newValue);
        }

        public static Currency operator /(Currency currency, Number num) => currency.Divide(num);

        public static Currency operator /(Currency currency, int num) => currency.Divide(num);

        public static implicit operator decimal(Currency currency) => currency.Value;
    }
}
