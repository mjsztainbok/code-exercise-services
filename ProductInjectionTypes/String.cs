namespace ProductIngestion.Types
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [DebuggerDisplay("value = {Value}")]
    public class String : IFieldType<string>
    {
        public String(string value)
        {
            this.Value = value != null ? value.Trim() : value;
        }

        public string Value { get; }

        public static implicit operator string(String str) => str.Value;
    }
}
