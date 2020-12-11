namespace ProductIngestion.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [DebuggerDisplay("value = {Value}")]
    public class Number : IFieldType<int>
    {
        public Number(int value)
        {
            this.Value = value;
        }

        public int Value { get; }

        public static implicit operator int(Number number) => number.Value;
    }
}
