namespace ProductIngestion.Types.Test
{
    using NUnit.Framework;

    using String = ProductIngestion.Types.String;

    public class StringTest
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("A test string")]
        [TestCase(" \t\r\n")]
        [TestCase("  String with spaces at the start")]
        [TestCase("String with spaces at the end  ")]
        [TestCase("  String with spaces at the start and end  ")]
        public void TestConstructor(string value)
        {
            var sut = new String(value);
            Assert.That(sut, value != null ? Has.Property("Value").EqualTo(value.Trim()) : Has.Property("Value").Null);
        }

        [Test]
        public void TestConversionOperator()
        {
            var sut = new String("Test string");
            string convertedStr = sut;
            Assert.That(convertedStr, Is.EqualTo(sut.Value));
        }
    }
}
