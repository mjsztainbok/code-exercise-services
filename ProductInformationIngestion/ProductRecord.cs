namespace ProductIngestion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductRecord
    {
        public int ProductID { init; get; }

        public string ProductDescription { init; get; }

        public string RegularDisplayPrice { init; get; }

        public decimal RegularCalculatorPrice { init; get; }

        public string SaleDisplayPrice { init; get; }

        public decimal? SaleCalculatorPrice { init; get; }

        public string UnitOfMeasure { init; get; }

        public string ProductSize { init; get; }

        public decimal TaxRate { init; get; }
    }
}
