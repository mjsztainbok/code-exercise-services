// <copyright file="ProductRecord.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion
{
    /// <summary>
    /// A product record.
    /// </summary>
    public class ProductRecord
    {
        /// <summary>Gets the product identifier.</summary>
        /// <value>The product identifier.</value>
        public int ProductID { init; get; }

        /// <summary>
        /// Gets the product description.
        /// </summary>
        /// <value>
        /// The product description.
        /// </value>
        public string ProductDescription { init; get; }

        /// <summary>
        /// Gets the regular display price.
        /// </summary>
        /// <value>
        /// The regular display price.
        /// </value>
        public string RegularDisplayPrice { init; get; }

        /// <summary>
        /// Gets the regular calculator price.
        /// </summary>
        /// <value>
        /// The regular calculator price.
        /// </value>
        public decimal RegularCalculatorPrice { init; get; }

        /// <summary>
        /// Gets the sale display price.
        /// </summary>
        /// <value>
        /// The sale display price.
        /// </value>
        public string SaleDisplayPrice { init; get; }

        /// <summary>
        /// Gets the sale calculator price.
        /// </summary>
        /// <value>
        /// The sale calculator price.
        /// </value>
        public decimal? SaleCalculatorPrice { init; get; }

        /// <summary>
        /// Gets the unit of measure.
        /// </summary>
        /// <value>
        /// The unit of measure.
        /// </value>
        public string UnitOfMeasure { init; get; }

        /// <summary>
        /// Gets the size of the product.
        /// </summary>
        /// <value>
        /// The size of the product.
        /// </value>
        public string ProductSize { init; get; }

        /// <summary>
        /// Gets the tax rate.
        /// </summary>
        /// <value>
        /// The tax rate.
        /// </value>
        public decimal TaxRate { init; get; }
    }
}
