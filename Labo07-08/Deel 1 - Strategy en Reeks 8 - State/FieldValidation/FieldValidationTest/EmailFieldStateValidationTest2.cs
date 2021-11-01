using System;
using FieldValidation.Pattern_reeks7;
using FieldValidation.Pattern_reeks8;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FieldValidationTest
{
    [TestClass]
    public class EmailFieldStateValidationTest2
    {
        private FieldEvaluator emailFE;

        public EmailFieldStateValidationTest2()
        {
            emailFE = new FieldEvaluator(new EmailFieldEvaluation2());
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
        public void TestEmail04()
        {
            Assert.IsTrue(emailFE.Evaluate("user@host.domain"));
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
