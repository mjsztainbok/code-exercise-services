using ProductIngestion.Types;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductIngestion.Processors
{
    public class FieldProcessors
    {
        private Dictionary<Type, IProcessor<IFieldType>> fieldProcessors;
        public FieldProcessors()
        {
            // This is candidate for dependency injection
            List<IProcessor<IFieldType>> processors = Assembly.GetExecutingAssembly().DefinedTypes
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IProcessor<>)))
                .Select(t => (IProcessor<IFieldType>) Activator.CreateInstance(t))
                .ToList();
            InitProcessorDictionary(processors);
        }

        public FieldProcessors(List<IProcessor<IFieldType>> processors)
        {
            InitProcessorDictionary(processors);
        }

        public IProcessor<IFieldType> this[Type fieldType] => fieldProcessors[fieldType];

        private void InitProcessorDictionary(List<IProcessor<IFieldType>> processors)
        {
            fieldProcessors = processors.ToDictionary(p => p.OutputType);
        }
    }
}
