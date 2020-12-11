namespace ProductIngestion.Types.Test
{
    using System;
    using System.Collections.Immutable;

    using NUnit.Framework;

    using ProductIngestion.Types;

    public class FlagsTest
    {
        private static readonly bool[] TestData = { false, true, false, true, false, false, true, true, false };

        [Test]
        public void TestConstructor()
        {
            bool[] array = { true, false, true, false, false };
            var sut = new Flags(array.ToImmutableArray());
            Assert.That(sut.Value, Has.Length.EqualTo(array.Length)
                .And.Not.SameAs(array)
                .And.EqualTo(array));
        }

        [Test]
        public void TestIntIndexer()
        {
            var sut = new Flags(TestData.ToImmutableArray());
            for (int i = 1; i <= TestData.Length; i++)
            {
                Assert.That(sut[i], Is.EqualTo(TestData[i - 1]), () => $"Index {i}");
            }
        }

        [Test]
        public void TestFlagIndexer()
        {
            var sut = new Flags(TestData.ToImmutableArray());
            Flag[] values = (Flag[])Enum.GetValues(typeof(Flag));
            foreach (Flag value in values)
            {
                Assert.That(sut[value], Is.EqualTo(TestData[(int)value - 1]), () => $"Flag {value}");
            }
        }
    }
}