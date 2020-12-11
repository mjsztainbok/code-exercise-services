namespace ProductIngestion.Processors
{
    using System;

    using ProductIngestion.Types;

    public interface IProcessor<out T>
        where T : IFieldType
    {
        Type OutputType => typeof(T);

        T ProcessString(string data);
    }
}
