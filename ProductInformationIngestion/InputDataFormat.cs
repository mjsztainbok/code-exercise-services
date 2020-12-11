namespace ProductIngestion
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ProductIngestion.Types;

    using String = ProductIngestion.Types.String;

    public class InputDataFormat
    {
        // This could potentially be read from an initialization file so that it could be updated without required code changes
        private static readonly List<FieldDescription> DefaultDataFormat = new List<FieldDescription>
            {
                new FieldDescription(1, 8, FieldNames.ProductId, typeof(Number)),
                new FieldDescription(10, 68, FieldNames.ProductDescription, typeof(String)),
                new FieldDescription(70, 77, FieldNames.RegularEachPrice, typeof(Currency)),
                new FieldDescription(79, 86, FieldNames.SaleEachPrice, typeof(Currency)),
                new FieldDescription(88, 95, FieldNames.RegularSplitPrice, typeof(Currency)),
                new FieldDescription(97, 104, FieldNames.SaleSplitPrice, typeof(Currency)),
                new FieldDescription(106, 113, FieldNames.RegularSplitQuantity, typeof(Number)),
                new FieldDescription(115, 122, FieldNames.SaleSplitQuantity, typeof(Number)),
                new FieldDescription(124, 132, FieldNames.Flags, typeof(Flags)),
                new FieldDescription(134, 142, FieldNames.ProductSize, typeof(String)),
            };

        private ImmutableList<FieldDescription> fieldDescriptions;

        public InputDataFormat()
            : this(DefaultDataFormat)
        {
        }

        public InputDataFormat(List<FieldDescription> fieldDescriptions)
        {
            this.ValidateFieldDescriptions(fieldDescriptions);
            this.fieldDescriptions = fieldDescriptions.ToImmutableList();
        }

        public ImmutableList<FieldDescription> FieldDescriptions => this.fieldDescriptions;

        internal InputData CreateInputData()
        {
            var inputData = new InputData();

            // Preinitialize the data with the field names
            foreach (var fieldDescription in this.fieldDescriptions)
            {
                inputData.Set(fieldDescription.Name, null);
            }

            return inputData;
        }

        private void ValidateFieldDescriptions(List<FieldDescription> fieldDescriptions)
        {
            // TODO: Add validation code here
        }
    }
}
