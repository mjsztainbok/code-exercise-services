using ProductIngestion.Processors;
using ProductIngestion.Types;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductIngestion
{
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
            init => inputDataFormat = value;
            get => inputDataFormat;
        }

        public FieldProcessors FieldProcessors
        {
            init => fieldProcessors = value;
            get => fieldProcessors;
        }


        public void IngestProductData(string path)
        {
            using var fileStream = File.OpenRead(path);

            IngestProductData(fileStream);
        }

        public void IngestProductData(Stream stream)
        {
            using var bufferedStream = new BufferedStream(stream);
            using var sr = new StreamReader(bufferedStream);

            string line = sr.ReadLine();
            while (line != null)
            {
                ProcessLine(line);
                line = sr.ReadLine();
            }
        }

        private void ProcessLine(string line)
        {
            Dictionary<string, IFieldType> values = new Dictionary<string, IFieldType>();

            ImmutableList<FieldDescription> fieldDescriptions = inputDataFormat.FieldDescriptions;
            foreach (var fieldDescription in fieldDescriptions)
            {
                ProcessField(line, fieldDescription, values);
            }
        }

        private void ProcessField(string line, FieldDescription fieldDescription, Dictionary<string, IFieldType> values)
        {
            IProcessor<IFieldType> processor = fieldProcessors[fieldDescription.FieldType];
            IFieldType value = processor.ProcessString(line.Substring(fieldDescription.Start, fieldDescription.Length));
            values[fieldDescription.Name] = value;
        }
    }
}
