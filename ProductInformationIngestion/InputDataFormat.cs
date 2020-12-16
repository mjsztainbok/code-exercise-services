// <copyright file="InputDataFormat.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion
{
    using System.Collections.Generic;
    using System.Collections.Immutable;

    using ProductIngestion.Types;

    using String = ProductIngestion.Types.String;

    /// <summary>The description of the input data format.</summary>
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

        /// <summary>Initializes a new instance of the <see cref="InputDataFormat" /> class using the default input data format.</summary>
        public InputDataFormat()
            : this(DefaultDataFormat)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="InputDataFormat" /> class using the specified field descriptions.</summary>
        /// <param name="fieldDescriptions">The field descriptions.</param>
        public InputDataFormat(List<FieldDescription> fieldDescriptions)
        {
            // TODO: The field descriptions should be validated here to ensure they don't overlap or have duplicate names
            this.fieldDescriptions = fieldDescriptions.ToImmutableList();
        }

        /// <summary>Gets the field descriptions.</summary>
        /// <value>The field descriptions.</value>
        public ImmutableList<FieldDescription> FieldDescriptions => this.fieldDescriptions;

        /// <summary>Creates an input data object prepopulate with the fields from the input data.</summary>
        /// <returns>An input data object.</returns>
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
    }
}
