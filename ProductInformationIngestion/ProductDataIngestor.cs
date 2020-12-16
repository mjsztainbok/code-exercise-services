// <copyright file="ProductDataIngestor.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.IO;

    using ProductIngestion.Processors;
    using ProductIngestion.Types;

    using InvalidDataException = ProductIngestion.Processors.InvalidDataException;

    /// <summary>
    /// Class to ingest the product data from a specified file or stream.
    /// </summary>
    public class ProductDataIngestor
    {
        private InputDataFormat inputDataFormat;
        private FieldProcessors fieldProcessors;

        /// <summary>Initializes a new instance of the <see cref="ProductDataIngestor" /> class.</summary>
        public ProductDataIngestor()
        {
            this.inputDataFormat = new InputDataFormat();
            this.fieldProcessors = new FieldProcessors();
        }

        /// <summary>Gets the input data format.</summary>
        /// <value>The input data format.</value>
        public InputDataFormat InputDataFormat
        {
            init => this.inputDataFormat = value;
            get => this.inputDataFormat;
        }

        /// <summary>
        /// Gets the field processors.
        /// </summary>
        /// <value>
        /// The field processors.
        /// </value>
        public FieldProcessors FieldProcessors
        {
            init => this.fieldProcessors = value;
            get => this.fieldProcessors;
        }

        /// <summary>
        /// Ingests the product data from a file.
        /// </summary>
        /// <param name="path">The path to a file containing the product data.</param>
        /// <returns>A list of product records for the product data.</returns>
        public List<ProductRecord> IngestProductData(string path)
        {
            using var fileStream = File.OpenRead(path);

            return this.IngestProductData(fileStream);
        }

        /// <summary>
        /// Ingests the product data from a stream.
        /// </summary>
        /// <param name="stream">The stream containing the product data.</param>
        /// <returns>A list of product records for the product data.</returns>
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
