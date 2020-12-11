namespace ProductIngestion
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ProductIngestion.Processors;
    using ProductIngestion.Types;

    using InvalidDataException = ProductIngestion.Processors.InvalidDataException;

    public class ProductDataIngestor
    {
        private InputDataFormat inputDataFormat;
        private FieldProcessors fieldProcessors;

        public ProductDataIngestor()
        {
            this.inputDataFormat = new InputDataFormat();
            this.fieldProcessors = new FieldProcessors();
        }

        public InputDataFormat InputDataFormat
        {
            init => this.inputDataFormat = value;
            get => this.inputDataFormat;
        }

        public FieldProcessors FieldProcessors
        {
            init => this.fieldProcessors = value;
            get => this.fieldProcessors;
        }

        public List<ProductRecord> IngestProductData(string path)
        {
            using var fileStream = File.OpenRead(path);

            return this.IngestProductData(fileStream);
        }

        public List<ProductRecord> IngestProductData(Stream stream)
        {
            using var bufferedStream = new BufferedStream(stream);
            using var sr = new StreamReader(bufferedStream);

            var productRecords = new List<ProductRecord>();

            string line = sr.ReadLine();
            while (line != null)
            {
                // Only add the record if there was no invalid data
                ProductRecord productRecord = this.ProcessLine(line);
                if (productRecord != null)
                {
                    productRecords.Add(productRecord);
                }

                line = sr.ReadLine();
            }

            return productRecords;
        }

        private ProductRecord ProcessLine(string line)
        {
            var values = this.inputDataFormat.CreateInputData();

            ImmutableList<FieldDescription> fieldDescriptions = this.inputDataFormat.FieldDescriptions;
            try
            {
                foreach (var fieldDescription in fieldDescriptions)
                {
                    this.ProcessField(line, fieldDescription, values);
                }

                return InputDataConverter.ConvertInputDataToProductRecord(values);
            }
            catch (InvalidDataException)
            {
                // If there is any invalid data then return null so the line of data can be ignored
                return null;
            }
        }

        private void ProcessField(string line, FieldDescription fieldDescription, InputData values)
        {
            IProcessor<IFieldType> processor = this.fieldProcessors[fieldDescription.FieldType];
            IFieldType value = processor.ProcessString(line.Substring(fieldDescription.Start, fieldDescription.Length));
            values.Set(fieldDescription.Name, value);
        }
    }
}
