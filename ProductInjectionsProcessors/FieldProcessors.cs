namespace ProductIngestion.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    using ProductIngestion.Types;

    public class FieldProcessors
    {
        private Dictionary<Type, IProcessor<IFieldType>> fieldProcessors;

        public FieldProcessors()
        {
            // This is candidate for dependency injection
            List<IProcessor<IFieldType>> processors = Assembly.GetExecutingAssembly().DefinedTypes
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IProcessor<>)))
                .Select(t => (IProcessor<IFieldType>)Activator.CreateInstance(t))
                .ToList();
            this.InitProcessorDictionary(processors);
        }

        public FieldProcessors(List<IProcessor<IFieldType>> processors)
        {
            this.InitProcessorDictionary(processors);
        }

        public IProcessor<IFieldType> this[Type fieldType] => this.fieldProcessors[fieldType];

        private void InitProcessorDictionary(List<IProcessor<IFieldType>> processors)
        {
            this.fieldProcessors = processors.ToDictionary(p => p.OutputType);
        }
    }
}
