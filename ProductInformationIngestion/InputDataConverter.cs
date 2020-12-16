// <copyright file="InputDataConverter.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductIngestion
{
    using ProductIngestion.Types;

    /// <summary>Utility class to convert the input data to product records.</summary>
    internal class InputDataConverter
    {
        // This value should come from an initalization file so that it can be changed easily without code changes
        private const decimal TaxRate = 7.775m;

        /// <summary>Converts an input data to a product record.</summary>
        /// <param name="inputData">The input data.</param>
        /// <returns>A product record corresponding to the input data.</returns>
        public static ProductRecord ConvertInputDataToProductRecord(InputData inputData)
        {
            // Process the regular prices
            decimal regularEachPrice = inputData.GetValue<decimal>(FieldNames.RegularEachPrice);
            Currency regularSplitPrice = inputData.Get<Currency>(FieldNames.RegularSplitPrice);
            int regularSplitQuantity = inputData.GetValue<int>(FieldNames.RegularSplitQuantity);
            string regularDisplayPrice;
            decimal? regularCalculatorPrice;
            CalculatePrices(regularEachPrice, regularSplitPrice, regularSplitQuantity, out regularDisplayPrice, out regularCalculatorPrice);

            // Process the regular prices
            decimal saleEachPrice = inputData.GetValue<decimal>(FieldNames.SaleEachPrice);
            Currency saleSplitPrice = inputData.Get<Currency>(FieldNames.SaleSplitPrice);
            int saleSplitQuantity = inputData.GetValue<int>(FieldNames.SaleSplitQuantity);
            string saleDisplayPrice = null;
            decimal? saleCalculatorPrice = null;
            if (saleEachPrice != 0 || saleSplitPrice != 0)
            {
                CalculatePrices(saleEachPrice, saleSplitPrice, saleSplitQuantity, out saleDisplayPrice, out saleCalculatorPrice);
            }

            Flags flags = inputData.Get<Flags>(FieldNames.Flags);

            return new ProductRecord()
            {
                ProductID = inputData.GetValue<int>(FieldNames.ProductId),
                ProductDescription = inputData.GetValue<string>(FieldNames.ProductDescription),
                RegularDisplayPrice = regularDisplayPrice,
                RegularCalculatorPrice = (decimal)regularCalculatorPrice,
                SaleDisplayPrice = saleDisplayPrice,
                SaleCalculatorPrice = saleCalculatorPrice,
                UnitOfMeasure = flags[Flag.PerWeight] ? "Pound" : "Each",
                ProductSize = inputData.GetValue<string>(FieldNames.ProductSize),
                TaxRate = flags[Flag.Taxable] ? TaxRate : 0,
            };
        }

        private static void CalculatePrices(decimal eachPrice, Currency splitPrice, int splitQuantity, out string displayPrice, out decimal? calculatorPrice)
        {
            if (eachPrice != 0)
            {
                // Output the price as 2 decimal place currency
                // NB: That this is locale specific and will adjust appropriately for other locales the US
                displayPrice = string.Format("{0:C}", eachPrice);
                calculatorPrice = eachPrice;
            }
            else
            {
                // If the regular price is 0, then the item has a split price
                displayPrice = string.Format("{0} for {1:C}", splitQuantity, splitPrice.Value);
                calculatorPrice = splitPrice / splitQuantity;
            }
        }
    }
}
