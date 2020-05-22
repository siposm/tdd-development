using console_tdd;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTesting
{
    [TestFixture]
    public class CalculatorTest
    {
        private Calculator calc;

        [SetUp]
        public void Init()
        {
            calc = new Calculator();
        }

        [TestCase(10, 20, 30)]
        [TestCase(9, 21, 30)]
        [TestCase(22, 8, 30)]
        public void TestAddition_SimpleParams(int a, int b, int result)
        {
            Assert.That(calc.Addition(a, b), Is.EqualTo(result));
        }

        [TestCase(30, -8, 22)]
        [TestCase(-8, 30, 22)]
        [TestCase(-20, -8, -28)]
        public void TestAddition_NegativeParams(int a, int b, int result)
        {
            Assert.That(calc.Addition(a, b), Is.EqualTo(result));
        }

        [Test]
        public void TestAddition_TooBigParams()
        {
            Assert.Throws<TooBigInputException>(() => calc.Addition(10, 1001));
            Assert.Throws<TooBigInputException>(() => calc.Addition(1001, 1001));
            Assert.Throws<TooBigInputException>(() => calc.Addition(1001, 10));
        }

        [Test]
        public void TestDivision_ThrowsException()
        {
            Assert.Throws<ZeroDivisionException>(() => calc.Division(10, 0));
            Assert.Throws<ZeroDivisionException>(() => calc.Division(100, 0));
            Assert.Throws<ZeroDivisionException>(() => calc.Division(-300, 0));
        }

        [TestCase(10, 5, 2)]
        [TestCase(10, 2, 5)]
        [TestCase(10, 4, 2.5)]
        public void TestDivision_CorrectReturnValue(int a, int b, double result)
        {
            Assert.That(calc.Division(a, b), Is.EqualTo(result));
        }

        [Test]
        public void TestHistory()
        {
            calc.Addition(100, 200);

            Assert.That(calc.History[calc.History.Count-1].Equals("addition (100,200)"));

            calc.Division(10, 5);

            Assert.That(calc.History[calc.History.Count-1].Equals("division (10,5)"));
        }

        [Test]
        public void TestClearMemory()
        {
            calc.Addition(99, 2);
            calc.Addition(-10, -30);

            calc.ClearMemory();

            calc.Addition(100, 200);
            calc.Addition(1, 3);
            calc.Division(10, 5);

            Assert.That(calc.History[0].Equals("addition (100,200)"));
            Assert.That(calc.History[1].Equals("addition (1,3)"));
            Assert.That(calc.History[2].Equals("division (10,5)"));
        }
    }
}
