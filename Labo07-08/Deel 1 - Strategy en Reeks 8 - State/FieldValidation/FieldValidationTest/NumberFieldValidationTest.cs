using Microsoft.VisualStudio.TestTools.UnitTesting;
using FieldValidation.Pattern_reeks7;

namespace FieldValidationTest
{
    [TestClass]
    public class NumberFieldValidationTest
    {
        private FieldEvaluator numberFE;

        public NumberFieldValidationTest()
        {
            numberFE = new FieldEvaluator(new NumberFieldEvaluation());
        }

        [TestMethod]
        public void TestNumber01()
        {
            Assert.IsTrue(numberFE.Evaluate("123"));
        }

        [TestMethod]
        public void TestNumber02()
        {
            Assert.IsTrue(numberFE.Evaluate("0.123"));
        }

        public void TestNumber03()
        {
            Assert.IsTrue(numberFE.Evaluate("0,123"));
        }

        [TestMethod]
        public void TestNumber04()
        {
            Assert.IsTrue(numberFE.Evaluate("1.123E33"));
        }

        [TestMethod]
        public void TestNumber05()
        {
            Assert.IsTrue(numberFE.Evaluate("0"));
        }

        [TestMethod]
        public void TestNumber06()
        {
            Assert.IsTrue(numberFE.Evaluate("-0.0"));
        }


        [TestMethod]
        public void TestNotNumber01()
        {
            Assert.IsFalse(numberFE.Evaluate(""));
        }

        [TestMethod]
        public void TestNotNumber02()
        {
            Assert.IsFalse(numberFE.Evaluate("-"));
        }

        [TestMethod]
        public void TestNotNumber03()
        {
            Assert.IsFalse(numberFE.Evaluate("0.123a"));
        }
    }
}
