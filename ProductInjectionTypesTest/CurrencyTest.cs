namespace ProductIngestion.Types.Test
{
    using NUnit.Framework;

    using ProductIngestion.Types;

    public class CurrencyTest
    {
        private static readonly object[] ConstructorTestCases =
        {
            new object[] { 0m, 0m },
            new object[] { 5m, 5m },
            new object[] { 1.234567m, 1.234567m },
            new object[] { 02.345m, 2.345m },
            new object[] { -2m, -2m },
            new object[] { -3.2456m, -3.2456m },
        };

        [Test]
        [TestCaseSource(nameof(ConstructorTestCases))]
        public void TestConstructor(decimal value, decimal expectedValue)
        {
            var sut = new Currency(value);
            Assert.That(sut.Value, Is.EqualTo(expectedValue));
        }

        [Test]
        public void TestConversionOperator()
        {
            var sut = new Currency(8752563.198342m);
            decimal decimalValue = sut;
            Assert.That(decimalValue, Is.EqualTo(sut.Value));
        }
    }
}
