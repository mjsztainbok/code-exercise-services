// <copyright file="Flag.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion.Types
{
    /// <summary>The supported flags.</summary>
    public enum Flag
    {
        /// <summary>The item is per weight</summary>
        PerWeight = 3,

        /// <summary>The item is taxable</summary>
        Taxable = 5,
    }
}
