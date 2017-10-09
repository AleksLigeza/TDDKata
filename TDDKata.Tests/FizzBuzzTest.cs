using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;


[TestFixture]
class FizzBuzzTest {

    #region PrivateFields
    private FizzBuzz _fizzBuzz;
    #endregion

    #region Congig
    [OneTimeSetUp]
    public void StartUp() {
        _fizzBuzz = new FizzBuzz();
    }

    [OneTimeTearDown]
    public void TearDown() {
        _fizzBuzz = null;
    }
    #endregion

    #region TestMethods
    [TestCase(3)]
    [TestCase(-9)]
    [TestCase(0)]
    [Test]
    public void CanReturnFizzIfNumberIsMultipleByThree(int number) {
        Assert.True(_fizzBuzz.PrintNumber(number).Contains("Fizz"));
    }

    [TestCase(5)]
    [TestCase(-10)]
    [TestCase(0)]
    [Test]
    public void CanReturnBuzzIfNumberIsMultipleByFive(int number) {
        Assert.True(_fizzBuzz.PrintNumber(number).Contains("Buzz"));
    }

    [TestCase(5)]
    [TestCase(-10)]
    [TestCase(13)]
    [Test]
    public void DontReturnFizzIfNumberIsNotMultipleByThree(int number) {
        Assert.False(_fizzBuzz.PrintNumber(number).Contains("Fizz"));
    }

    [TestCase(3)]
    [TestCase(-12)]
    [TestCase(13)]
    [Test]
    public void DontRetunrBuzzIfNumberIsNotMultipleByFive(int number) {
        Assert.False(_fizzBuzz.PrintNumber(number).Contains("Buzz"));
    }

    [Test]
    public void CanReturnNumbersUsingLinq() {
        Assert.AreEqual(_fizzBuzz.PrintNumbers(), _fizzBuzz.PrintNumbersUsingLinq());
    }
#endregion
}

