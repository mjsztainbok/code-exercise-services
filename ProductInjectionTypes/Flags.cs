using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductIngestion.Types
{
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

        public bool this[int index] => flags[index - 1];

        public bool this[Flag flag] => flags[(int)flag - 1];

        public ImmutableArray<bool> Value => flags;

        private string DebuggerDisplay
        {
            get => string.Join("", flags.Select(b => b ? 'Y' : 'N').ToArray());
        }
    }
}
