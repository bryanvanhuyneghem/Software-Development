using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileSystem.Model;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateFile()
        {
            Folder testFolder = new Folder("");
            TextFile testFile = testFolder.CreateTextFile("test");
            testFile.Content = "line1";

            // test
            TextFile temp = (TextFile) testFolder.GetFile("test");
            Assert.AreEqual(temp.Content, "line1");
        }

        [TestMethod]
        [ExpectedException(typeof(FileSystemException))]
        public void TestException()
        {
            Folder testFolder = new Folder("");
            testFolder.CreateTextFile("test");
            testFolder.CreateTextFile("test"); // Should throw exception

        }

        [TestMethod]
        public void TestIndexer()
        {
            Folder testFolder = new Folder("");
            testFolder.CreateTextFile("test");
            testFolder.CreateTextFile("test2");
            Assert.AreEqual(testFolder.GetFile("test"), testFolder["test"]);
        }
    }
}

