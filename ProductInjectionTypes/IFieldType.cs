using System;

namespace ProductIngestion.Types
{
    public interface IFieldType
    {
    }

    public interface IFieldType<T> : IFieldType
    {
        T Value
        {
            get;
        }
    }
}
