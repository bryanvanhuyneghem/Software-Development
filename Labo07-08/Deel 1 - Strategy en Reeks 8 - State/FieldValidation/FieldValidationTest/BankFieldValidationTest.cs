using Microsoft.VisualStudio.TestTools.UnitTesting;
using FieldValidation.Pattern_reeks7;

namespace FieldValidationTest
{
    [TestClass]
    public class BankFieldValidationTest
    {
        private FieldEvaluator bankFE;

        public BankFieldValidationTest()
        {
            bankFE = new FieldEvaluator(new BankFieldEvaluation());
        }

        [TestMethod]
        public void TestBank01()
        {
            Assert.IsTrue(bankFE.Evaluate("123-4567890-02"));
        }

        [TestMethod]
        public void TestNotBank01()
        {
            Assert.IsFalse(bankFE.Evaluate("abc-defghij-kl"));
        }

        [TestMethod]
        public void TestNotBank02()
        {
            Assert.IsFalse(bankFE.Evaluate("12-34-70"));
        }

        [TestMethod]
        public void TestNotBank03()
        {
            Assert.IsFalse(bankFE.Evaluate("1234-567890-02"));
        }

        [TestMethod]
        public void TestNotBank04()
        {
            Assert.IsFalse(bankFE.Evaluate("123-4567890-12"));
        }

    }
}
