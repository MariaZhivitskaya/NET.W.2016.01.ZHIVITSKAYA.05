using System;
using NUnit.Framework;
using static Task1.GreatestCommonDivisor;

namespace Task1.Tests
{
    [TestFixture]
    public class GreatestCommonDivisotTests
    {
        [TestCase(78, 294, 570, 36, ExpectedResult = 6)]
        [TestCase(ExpectedException = typeof (ArgumentException))]
        [TestCase(72, 96, ExpectedResult = 24)]
        [TestCase(-585, 81, -189, ExpectedResult = 9)]

        public int EuclideanGCDTests(params int[] data)
        {
            var source = EuclideanGCD(data);
            Assert.Pass("Elapsed ms: " + ElapsedTime.TotalMilliseconds);
            return source;
        } 

        [TestCase(78, 294, 570, 36, ExpectedResult = 6)]
        [TestCase(ExpectedException = typeof (ArgumentException))]
        [TestCase(72, 96, ExpectedResult = 24)]
        [TestCase(-585, 81, -189, ExpectedResult = 9)]

        public int BinaryGCDTests(params int[] data)
        {
            var source = BinaryGCD(data);
            Assert.Pass("Elapsed ms: " + ElapsedTime.TotalMilliseconds);
            return source;
        } 
    }
}
