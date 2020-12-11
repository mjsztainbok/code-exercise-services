namespace ProductIngestion
{
    using System;

    public class FieldDescription
    {
        public FieldDescription(int start, int end, string name, Type fieldType)
        {
            // Adjust the start and end by 1 as the actual data is 0 based
            this.Start = start - 1;
            this.End = end - 1;
            this.Name = name;
            this.FieldType = fieldType;
        }

        public int Start { get; }

        public int End { get; }

        public string Name { get; }

        public Type FieldType { get; }

        public int Length
        {
            get => this.End - this.Start + 1;
        }
    }
}
