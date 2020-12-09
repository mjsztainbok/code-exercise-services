using NUnit.Framework;

using ProductIngestion.Types;

using System.Collections.Immutable;
using System.Linq;

namespace ProductIngestion.Processors.Test
{
    public class FlagProcessorTest
    {
        [Test]
        [TestCaseSource(nameof(ProcessStringCases))]
        public void TestProcessString(string testString, bool throwsException)
        {
            var sut = new FlagsProcessor();
            if (throwsException)
            {
                Assert.Throws<InvalidDataException>(() => sut.ProcessString(testString));
            }
            else
            {
                Flags result = sut.ProcessString(testString);
                var expectedResult = testString.Select(c => c == 'Y').ToArray().ToImmutableArray();
                Assert.That(result, Has.Property("Value").EquivalentTo(expectedResult));

            }
        }

        private static readonly object[] ProcessStringCases = new object[]
        {
            new object[] {null, true },
            new object[] {"", true},
            new object[] {"A", true},
            new object[] {"1", true},
            new object[] {" ", true},
            new object[] {"y", true},
            new object[] {"n", true},
            new object[] {"Y", false},
            new object[] {"N", false},
        };
    }
}