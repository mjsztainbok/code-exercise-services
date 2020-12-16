// <copyright file="Program.cs" company="Mark Sztainbok">
// Copyright (c) Mark Sztainbok. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace ProductInformationIngestionTest
{
    using System.Collections.Generic;

    using ProductIngestion;

    using Spectre.Console;

    /// <summary>The main program class.</summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                AnsiConsole.Render(new Markup("[bold red] Usage:[/] [bold]ProductInformationInjectionTest[/] [[/r]] <path to file>"));
                return;
            }

            bool recordView = false;
            string path;
            if (args.Length == 2)
            {
                if (args[0] == "/r")
                {
                    recordView = true;
                }

                path = args[1];
            }
            else
            {
                path = args[0];
            }

            var pdi = new ProductDataIngestor();
            List<ProductRecord> productRecords = pdi.IngestProductData(path);

            // Output the data
            if (!recordView)
            {
                OutputRecordsAsTable(productRecords);
            }
            else
            {
                OutputRecordsIndividually(productRecords);
            }
        }

        private static void OutputRecordsIndividually(List<ProductRecord> productRecords)
        {
            bool isFirst = true;
            foreach (var productRecord in productRecords)
            {
                if (!isFirst)
                {
                    AnsiConsole.Render(new Rule());
                }
                else
                {
                    isFirst = false;
                }

                var table = new Table()
                    .AddColumn(new TableColumn("Key").PadRight(5))
                    .AddColumn("Value")
                    .HideHeaders()
                    .NoBorder()
                    .AddRow("Product ID:", productRecord.ProductID.ToString())
                    .AddRow("Product Description:", productRecord.ProductDescription)
                    .AddRow("Regular Display Price:", productRecord.RegularDisplayPrice.ToString())
                    .AddRow("Regular Calculator Price:", productRecord.RegularCalculatorPrice.ToString())
                    .AddRow("Sale Display Price:", OutputNullableValue(productRecord.SaleDisplayPrice))
                    .AddRow("Sale Calculator Price:", OutputNullableValue(productRecord.SaleCalculatorPrice))
                    .AddRow("Unit Of Measure:", productRecord.UnitOfMeasure)
                    .AddRow("Product Size:", productRecord.ProductSize)
                    .AddRow("Tax Rate:", string.Format("{0}%", productRecord.TaxRate.ToString()));

                AnsiConsole.Render(table);
            }
        }

        private static void OutputRecordsAsTable(List<ProductRecord> productRecords)
        {
            var table = new Table();
            table.AddColumn(new TableColumn("Product ID").RightAligned());
            table.AddColumn("Product Description");
            table.AddColumn(new TableColumn("Regular Display Price").RightAligned());
            table.AddColumn(new TableColumn("Regular Calculator Price").RightAligned());
            table.AddColumn(new TableColumn("Sale Display Price").RightAligned());
            table.AddColumn(new TableColumn("Sale Calculator Price").RightAligned());
            table.AddColumn("Unit Of Measure");
            table.AddColumn("Product Size");
            table.AddColumn("Tax Rate");

            foreach (var productRecord in productRecords)
            {
                table.AddRow(
                    productRecord.ProductID.ToString(),
                    productRecord.ProductDescription,
                    productRecord.RegularDisplayPrice.ToString(),
                    productRecord.RegularCalculatorPrice.ToString(),
                    OutputNullableValue(productRecord.SaleDisplayPrice),
                    OutputNullableValue(productRecord.SaleCalculatorPrice),
                    productRecord.UnitOfMeasure,
                    productRecord.ProductSize,
                    string.Format("{0}%", productRecord.TaxRate.ToString()));
            }

            table.Collapse();

            AnsiConsole.Render(table);
        }

        private static string OutputNullableValue(object o) => (o != null) ? o.ToString() : string.Empty;
    }
}