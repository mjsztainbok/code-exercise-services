namespace ProductIngestion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ProductIngestion.Types;

    internal class InputData
    {
        private readonly Dictionary<string, IFieldType> values = new ();

        public IReadOnlySet<string> ValueNames => this.values.Keys.ToHashSet();

        public T Get<T>(string name)
            where T : IFieldType
        {
            return (T)this.values[name];
        }

        public T GetValue<T>(string name)
        {
            return ((IFieldType<T>)this.values[name]).Value;
        }

        public void Set(string name, IFieldType value)
        {
            this.values[name] = value;
        }
    }
}
