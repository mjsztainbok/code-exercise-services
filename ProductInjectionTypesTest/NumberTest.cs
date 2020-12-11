namespace ProductIngestion.Types.Test
{
    using NUnit.Framework;

    using ProductIngestion.Types;

    public class NumberTest
    {
        [Test]
        [TestCase(0)]
        [TestCase(13419475)]
        [TestCase(-98753625)]
        public void TestConstructor(int value)
        {
            var sut = new Number(value);
            Assert.That(sut, Has.Property("Value").EqualTo(value));
        }

        [Test]
        public void TestConversionOperator()
        {
            var sut = new Number(345123789);
            int? intValue = sut;
            Assert.That(intValue, Is.EqualTo(sut.Value));
        }
    }
}
