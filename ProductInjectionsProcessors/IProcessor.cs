using ProductIngestion.Types;

using System;

namespace ProductIngestion.Processors
{
    public interface IProcessor<out T> where T : IFieldType
    {
        T ProcessString(string data);

        Type OutputType => typeof(T);
    }
}
