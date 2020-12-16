// <copyright file="FieldProcessors.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using ProductIngestion.Types;

    /// <summary>A collection of field processors.</summary>
    public class FieldProcessors
    {
        private Dictionary<Type, IProcessor<IFieldType>> fieldProcessors;

        /// <summary>Initializes a new instance of the <see cref="FieldProcessors" /> class by automatically finding all implemented processors.</summary>
        public FieldProcessors()
        {
            // This is a candidate for dependency injection
            List<IProcessor<IFieldType>> processors = Assembly.GetExecutingAssembly().DefinedTypes
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IProcessor<>)))
                .Select(t => (IProcessor<IFieldType>)Activator.CreateInstance(t))
                .ToList();
            this.InitProcessorDictionary(processors);
        }

        /// <summary>Initializes a new instance of the <see cref="FieldProcessors" /> class using the specified field processors.</summary>
        /// <param name="processors">The processors.</param>
        public FieldProcessors(List<IProcessor<IFieldType>> processors)
        {
            this.InitProcessorDictionary(processors);
        }

        /// <summary>Gets the processor for the specified field type.</summary>
        /// <param name="fieldType">Type of the field.</param>
        /// <value>A field processor.</value>
        /// <returns>The field processor for the specified field type.</returns>
        public IProcessor<IFieldType> this[Type fieldType] => this.fieldProcessors[fieldType];

        private void InitProcessorDictionary(List<IProcessor<IFieldType>> processors)
        {
            this.fieldProcessors = processors.ToDictionary(p => p.OutputType);
        }
    }
}
