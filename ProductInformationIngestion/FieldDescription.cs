// <copyright file="FieldDescription.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion
{
    using System;

    /// <summary>
    ///   <para>A field description.</para>
    /// </summary>
    public class FieldDescription
    {
        /// <summary>Initializes a new instance of the <see cref="FieldDescription" /> class.</summary>
        /// <param name="start">Start index of the field (1 based).</param>
        /// <param name="end">End index of the field (1 based).</param>
        /// <param name="name">Name of the field.</param>
        /// <param name="fieldType">Type of the field.</param>
        public FieldDescription(int start, int end, string name, Type fieldType)
        {
            // Adjust the start and end by 1 as the actual data is 0 based
            this.Start = start - 1;
            this.End = end - 1;
            this.Name = name;
            this.FieldType = fieldType;
        }

        /// <summary>Gets the start index of the field (0 based).</summary>
        /// <value>The start index.</value>
        /// <remarks>This will be 1 less than the value passed into the constructor.</remarks>
        public int Start { get; }

        /// <summary>Gets the end index of the field (0 based).</summary>
        /// <value>The end index.</value>
        /// <remarks>This will be 1 less than the value passed into the constructor.</remarks>
        public int End { get; }

        /// <summary>Gets the name of the field.</summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>Gets the type of the field.</summary>
        /// <value>The type of the field.</value>
        public Type FieldType { get; }

        /// <summary>Gets the length of the field.</summary>
        /// <value>The length.</value>
        public int Length
        {
            get => this.End - this.Start + 1;
        }
    }
}
