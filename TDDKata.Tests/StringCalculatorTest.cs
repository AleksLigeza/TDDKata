using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using CodeKata;

namespace CodeKata.Test
{
    [TestFixture]
    public class StringCalculatorTest {

        [TestCase(1)]
        [TestCase(0)]
        [Test]
        public void CanConvertNumericCharToInt32(int number) {
            int value = StringCalculator.ConvertCharToInt(number.ToString()[0]);
            Assert.True(value == number);
        }

        [TestCase('-')]
        [TestCase('a')]
        [Test]
        public void DoesntConvertNonNumericCharsToInt32(char c) {
            Assert.Throws<ArgumentOutOfRangeException>(() => StringCalculator.ConvertCharToInt(c));
        }

        [TestCase("", 0)]
        [TestCase("1,2,3", 6)]
        [TestCase("111,11a1,11a1", 333)]
        [TestCase("111,\n,11a1,1\n1a1,\n", 333)]
        [TestCase("\\;111;111;111", 333)]
        [TestCase("\\111,111,111", 333)]
        [TestCase("111,10002, 10003", 111)]
        [TestCase("\\[***]1***1***1", 3)]
        [TestCase("\\[***][++]1***1++0+++1", 3)]
        [TestCase("\\[*][%]\n1*2%3", 6)]
        [Test]
        public void CanAddNumbersInString(string numbers, int expectedResult) {
            int result = new StringCalculator().Add(numbers);
            Assert.True(expectedResult == result);
        }

        [TestCase("-10")]
        [Test]
        public void ThrowsExceptionWhenNegativeNumber(string numbers) {
            Assert.Throws<ArgumentOutOfRangeException>(() => new StringCalculator().Add(numbers), "Negatives not allowed");
        }
    }
}
