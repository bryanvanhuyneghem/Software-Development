using Microsoft.VisualStudio.TestTools.UnitTesting;
using FieldValidation.Pattern_reeks7;

namespace FieldValidationTest
{
    [TestClass]
    public class EmailFieldValidationTest
    {
        private FieldEvaluator emailFE;

        public EmailFieldValidationTest()
        {
            emailFE = new FieldEvaluator(new EmailFieldEvaluation());
        }

        [TestMethod]
        public void TestEmail01()
        {
            Assert.IsTrue(emailFE.Evaluate("user@host"));
        }

        [TestMethod]
        public void TestEmail02()
        {
            Assert.IsTrue(emailFE.Evaluate("first.last@host"));
        }

        [TestMethod]
        public void TestEmail03()
        {
            Assert.IsTrue(emailFE.Evaluate("first.last@host.domain"));
        }

        [TestMethod]
        public void TestNotEmail01()
        {
            Assert.IsFalse(emailFE.Evaluate("user"));
        }

        [TestMethod]
        public void TestNotEmail02()
        {
            Assert.IsFalse(emailFE.Evaluate(" "));
        }

        [TestMethod]
        public void TestNotEmail03()
        {
            Assert.IsFalse(emailFE.Evaluate("first.last"));
        }

        [TestMethod]
        public void TestNotEmail04()
        {
            Assert.IsFalse(emailFE.Evaluate("user."));
        }

        [TestMethod]
        public void TestNotEmail05()
        {
            Assert.IsFalse(emailFE.Evaluate("user@"));
        }

        [TestMethod]
        public void TestNotEmail06()
        {
            Assert.IsFalse(emailFE.Evaluate("user@."));
        }

        [TestMethod]
        public void TestNotEmail07()
        {
            Assert.IsFalse(emailFE.Evaluate("user.@"));
        }

        [TestMethod]
        public void TestNotEmail08()
        {
            Assert.IsFalse(emailFE.Evaluate("first.last@.domain"));
        }

    }
}
