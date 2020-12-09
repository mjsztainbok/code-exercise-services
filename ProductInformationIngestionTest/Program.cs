using ProductIngestion;
using ProductIngestion.Processors;

using System;

namespace ProductInformationIngestionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var pdi = new ProductDataIngestor();
            pdi.IngestProductData(@"C:\Users\mjszt\source\repos\mjsztainbok\code-exercise-services\input-sample.txt");
        }
    }
}
 