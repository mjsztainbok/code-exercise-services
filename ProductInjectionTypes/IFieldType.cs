namespace ProductIngestion.Types
{
    using System;

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
