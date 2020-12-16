// <copyright file="Flags.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion.Types
{
    using System.Collections.Immutable;
    using System.Diagnostics;
    using System.Linq;

    /// <summary> A type which represents flags.</summary>
    [DebuggerDisplay("value = {DebuggerDisplay,nq}")]
    public class Flags : IFieldType<ImmutableArray<bool>>
    {
        /// <summary>The default number of flags.</summary>
        internal const int DefaultNumFlags = 9;

        // The flags
        private readonly ImmutableArray<bool> flags;

        /// <summary>Initializes a new instance of the <see cref="Flags" /> class.</summary>
        /// <param name="flags">The flags.</param>
        public Flags(ImmutableArray<bool> flags)
        {
            this.flags = flags;
        }

        /// <summary>Gets the value.</summary>
        /// <value>The value.</value>
        public ImmutableArray<bool> Value => this.flags;

        private string DebuggerDisplay
        {
            get => string.Join(string.Empty, this.flags.Select(b => b ? 'Y' : 'N').ToArray());
        }

        /// <summary>Gets the flag at the specified index.</summary>
        /// <param name="index">The index.</param>
        /// <value>Indicates whether the flag is set or not.</value>
        /// <returns>The flag value.</returns>
        public bool this[int index] => this.flags[index - 1];

        /// <summary>Gets the flag for the specified flag value.</summary>
        /// <param name="flag">The flag.</param>
        /// <value>Indicates whether the flag is set or not.</value>
        /// <returns>The flag value.</returns>
        public bool this[Flag flag] => this.flags[(int)flag - 1];
    }
}
