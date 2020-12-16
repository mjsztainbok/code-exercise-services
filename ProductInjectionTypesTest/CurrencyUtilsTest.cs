namespace ProductIngestion.Types.Test
{
    using NUnit.Framework;

    public class CurrencyUtilsTest
    {
        private static readonly object[] RoundingTestCases =
       {
            new object[] { 0.1m, 0.1m },
            new object[] { 0.12m, 0.12m },
            new object[] { 0.123m, 0.123m },
            new object[] { 0.1234m, 0.1234m },
            new object[] { 0.12341m, 0.1234m },
            new object[] { 0.123449999999m, 0.1234m },
            new object[] { 0.12345m, 0.1234m },
            new object[] { 0.123451m, 0.1235m },
            new object[] { 0.123478m, 0.1235m },
            new object[] { -0.1m, -0.1m },
            new object[] { -0.12m, -0.12m },
            new object[] { -0.123m, -0.123m },
            new object[] { -0.1234m, -0.1234m },
            new object[] { -0.12341m, -0.1234m },
            new object[] { -0.123449999999m, -0.1234m },
            new object[] { -0.12345m, -0.1235m },
            new object[] { -0.123451m, -0.1235m },
            new object[] { -0.123478m, -0.1235m },
       };

        [Test]
        [TestCaseSource(nameof(RoundingTestCases))]
        public void TestRoundHalfDownTo4Places(decimal value, decimal expectedValue)
        {
            decimal roundedValue = CurrencyUtils.RoundHalfDownTo4Places(value);
            Assert.That(roundedValue, Is.EqualTo(expectedValue));
        }
    }
}
