using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProductIngestion.Types;

using String = ProductIngestion.Types.String;

namespace ProductIngestion
{
    public class InputDataFormat
    {
        private static readonly List<FieldDescription> DEFAULT_DATA_FORMAT = new List<FieldDescription> 
            {
                new FieldDescription(1, 8, "Product ID", typeof(Number)),
                new FieldDescription(10, 68, "Product Description", typeof(String)),
                new FieldDescription(70, 77, "Regular Each Price", typeof(Currency)),
                new FieldDescription(79, 86, "Sale Each Price", typeof(Currency)),
                new FieldDescription(88, 95, "Regular Split Price", typeof(Currency)),
                new FieldDescription(97, 104, "Sale Split Price", typeof(Currency)),
                new FieldDescription(106, 113, "Regular Split Quantity", typeof(Number)),
                new FieldDescription(115, 122, "Sale Split Quantity", typeof(Number)),
                new FieldDescription(124, 132, "Flags", typeof(Flags)),
                new FieldDescription(134, 142, "Product Size", typeof(String)),

            };

        private ImmutableList<FieldDescription> fieldDescriptions;

        public InputDataFormat() : this(DEFAULT_DATA_FORMAT)
        {
        }

        public InputDataFormat(List<FieldDescription> fieldDescriptions)
        {
            ValidateFieldDescriptions(fieldDescriptions);
            this.fieldDescriptions = fieldDescriptions.ToImmutableList();
        }

        public ImmutableList<FieldDescription> FieldDescriptions => fieldDescriptions;

        private void ValidateFieldDescriptions(List<FieldDescription> fieldDescriptions)
        {
            // TODO: Add validation code here
        }
    }
}
