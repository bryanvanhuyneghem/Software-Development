using System;
using Bestandsbeheer;
using Bestandsbeheer.Pattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAccess
{
    [TestClass]
    public class UnitTest1
    {
        // Read file twice (with different user), expect same contents.
        [TestMethod]
        public void TestReadFile()
        {
            User testuser = new User("test", false);
            IFile file1 = new AccessProxy(testuser, "file1.txt");
            User testadmin = new User("admin", true);
            IFile file2 = new AccessProxy(testadmin, "file1.txt");
            Equals(file1.Content, file2.Content);
        }

        // Open a hidden file as an admin; should work fine
        [TestMethod]
        public void TestAdminAcess()
        {
            User testadmin = new User("admin", true);
            AccessProxy file1 = new AccessProxy(testadmin, ".secretfile.txt");
            string content = file1.Content;
        }

        // Open a hidden file as a user; expect an Exception!
        [TestMethod]
        [ExpectedException(typeof(FieldAccessException))]
        public void TestAdminAcessException()
        {
            User testuser = new User("test", false);
            IFile file1 = new AccessProxy(testuser, ".secretfile.txt");
            string content = file1.Content;
        }

    }
}
