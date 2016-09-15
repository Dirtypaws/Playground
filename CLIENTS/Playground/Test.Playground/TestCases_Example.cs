using System;
using System.Linq;
using NUnit.Framework;

namespace Test.Playground
{
    [TestFixture]
    public class TestCases_Example
    {
        [TestCase(null, 0)]
        [TestCase("123", 123)]
        [TestCase("xyzabv", 0)]
        public void ParseInt_Test(string input, int expected)
        {
            var result = input.ToParseInt();
            Assert.AreEqual(expected, result);

        }

        [TestCase(null, 0)]
        [TestCase(".99", 18)]
        [TestCase("123", 6)]
        [TestCase("x45yabc_", 9)]
        [TestCase("", 0)]
        [TestCase("_67yd.8", 21)]
        public void SumInt_Test(string input, int expected)
        {
            var test = new TestMethods();
            Assert.AreEqual(expected, test.SumString(input));
        }
    }

    public static class ExtMethods
    {
        public static int ToParseInt(this string str)
        {
            int result;
            return int.TryParse(str, out result) ? result : 0;
        }
    }

    public class TestMethods
    {
        public int SumString(string str)
        {
            //return str?.ToCharArray().Where(char.IsNumber).Sum(x => int.Parse(x.ToString())) ?? 0;

            return str?.Sum(x => x.ToString().ToParseInt()) ?? 0;
        }
    }
}