using ProductIngestion.Types;

using System.Collections.Immutable;

namespace ProductIngestion.Processors
{
    public class FlagsProcessor : IProcessor<Flags>
    {
        public Flags ProcessString(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new InvalidDataException("The flags string cannot be null or empty");
            }

            var builder = ImmutableArray.CreateBuilder<bool>(data.Length);
            foreach (char c in data)
            {
                // Only Y and N are acceptable characters for a flag
                if (c is not ('Y' or 'N'))
                {
                    throw new InvalidDataException("The flags string contains invalid characters");
                }

                builder.Add(c == 'Y');
            }

            return new Flags(builder.ToImmutable());
        }
    }
}
