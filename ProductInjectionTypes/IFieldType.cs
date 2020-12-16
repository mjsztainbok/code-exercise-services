// <copyright file="IFieldType.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion.Types
{
    /// <summary>A field type marker interface.</summary>
    public interface IFieldType
    {
    }

    /// <summary>A field type interface which can return a value.</summary>
    /// <typeparam name="T">The type of the stored value.</typeparam>
    public interface IFieldType<T> : IFieldType
    {
        /// <summary>Gets the value.</summary>
        /// <value>The value.</value>
        T Value
        {
            get;
        }
    }
}
