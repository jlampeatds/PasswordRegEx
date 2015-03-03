using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordRegEx;

namespace PasswordRegExTest
{
    [TestClass]
    public class LengthTests
    {
        [TestMethod]
        public void LengthTest()
        {
            var ree = new RegExEval(RegExBuilder.RegExComponentMinimumLength(6));

            Assert.IsFalse(ree.PasswordMatchesRegEx(""));
            Assert.IsFalse(ree.PasswordMatchesRegEx("1"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("12345"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("123456"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("123456789"));
             
        }
    }
}
