using NUnit.Framework;

using ProductIngestion.Types;

namespace ProductIngestion.Types.Test
{
    public class CurrencyTest
    {
        [Test]
        [TestCaseSource(nameof(ConstructorTestCases))]
        public void TestConstructor(decimal value, decimal expectedValue)
        {
            var sut = new Currency(value);
            Assert.That(sut.Value, Is.EqualTo(expectedValue));
        }

        private static readonly object[] ConstructorTestCases =
        {
            new object[] {0m, 0m},
            new object[] {5m, 5m},
            new object[] {1.234567m, 1.234567m},
            new object[] {02.345m, 2.345m},
            new object[] {-2m, -2m},
            new object[] {-3.2456m, -3.2456m},
        };

        [Test]
        public void TestConversionOperator()
        {
            var sut = new Currency(8752563.198342m);
            decimal decimalValue = sut;
            Assert.That(decimalValue, Is.EqualTo(sut.Value));
        }

        [Test]
        [TestCaseSource(nameof(RoundingTestCases))]
        public void TestRoundHalfDownTo4Places(decimal value, decimal expectedValue)
        {
            decimal roundedValue = CurrencyUtils.RoundHalfDownTo4Places(value);
            Assert.That(roundedValue, Is.EqualTo(expectedValue));
        }

        private static readonly object[] RoundingTestCases =
        {
            new object[] {0.1m, 0.1m},
            new object[] {0.12m, 0.12m},
            new object[] {0.123m, 0.123m},
            new object[] {0.1234m, 0.1234m},
            new object[] {0.12341m, 0.1234m},
            new object[] {0.123449999999m, 0.1234m},
            new object[] {0.12345m, 0.1234m},
            new object[] {0.123451m, 0.1235m},
            new object[] {0.123478m, 0.1235m},
            new object[] {-0.1m, -0.1m},
            new object[] {-0.12m, -0.12m},
            new object[] {-0.123m, -0.123m},
            new object[] {-0.1234m, -0.1234m},
            new object[] {-0.12341m, -0.1234m},
            new object[] {-0.123449999999m, -0.1234m},
            new object[] {-0.12345m, -0.1235m},
            new object[] {-0.123451m, -0.1235m},
            new object[] {-0.123478m, -0.1235m},
        };
    }
}
