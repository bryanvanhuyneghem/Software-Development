using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiz;
using Quiz.Pattern;

namespace TestQuiz
{
    class TestQuizFactoryProviders
    {
        private QuizFactoryProvider provider;

        [TestMethod]
        public void TestCSVQuizFactoryProvider()
        {
            provider = new QuizFactoryProvider("csv");
            TestProvider(provider.Categories[0]);
            TestContent(provider.Categories[0], 3, 4);
            TestAnswer(provider.Categories[0], 0, "Quack");

            TestProvider(provider.Categories[1]);
            TestContent(provider.Categories[1], 4, 4);
            TestAnswer(provider.Categories[1], 1, "Boat");

            TestProvider(provider.Categories[3]);
            TestContent(provider.Categories[3], 5, 4);
            TestAnswer(provider.Categories[3], 4, "28");
        }

        [TestMethod]
        public void TestTXTQuizFactoryProvider()
        {
            provider = new QuizFactoryProvider("txt");
            TestProvider(provider.Categories[0]);
            TestContent(provider.Categories[0], 3, 4);
            TestAnswer(provider.Categories[0], 0, "Kwaak");

            TestProvider(provider.Categories[1]);
            TestContent(provider.Categories[1], 4, 4);
            TestAnswer(provider.Categories[1], 1, "Boot");

            TestProvider(provider.Categories[3]);
            TestContent(provider.Categories[3], 5, 4);
            TestAnswer(provider.Categories[3], 4, "28");
        }

        private void TestProvider(ICategory category)
        {
            Assert.IsNotNull(provider[category]);
            Assert.IsNotNull(provider[category].Levels);
            Assert.IsNotNull(provider[category].Vragen);
        }

        private void TestContent(ICategory category, int numQuestions, int numLevels)
        {
            Assert.AreEqual(numQuestions, provider[category].Vragen.Count);
            Assert.AreEqual(numLevels, provider[category].Levels.Count);
        }

        private void TestAnswer(ICategory category, int question, string answer)
        {
            Assert.IsTrue(provider[category].Vragen[question].IsCorrect(answer));
        }
    }
}
