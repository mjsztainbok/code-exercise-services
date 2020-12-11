namespace ProductIngestion.Types
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [DebuggerDisplay("value = {DebuggerDisplay,nq}")]
    public class Flags : IFieldType<ImmutableArray<bool>>
    {
        // The default number of flags
        internal const int DefaultNumFlags = 9;

        // The flags
        private readonly ImmutableArray<bool> flags;

        public Flags(ImmutableArray<bool> flags)
        {
            this.flags = flags;
        }

        public ImmutableArray<bool> Value => this.flags;

        private string DebuggerDisplay
        {
            get => string.Join(string.Empty, this.flags.Select(b => b ? 'Y' : 'N').ToArray());
        }

        public bool this[int index] => this.flags[index - 1];

        public bool this[Flag flag] => this.flags[(int)flag - 1];
    }
}
