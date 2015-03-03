using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordRegEx;

namespace PasswordRegExTest
{
    [TestClass]
    public class RepeatCharTests : TestSettings
    {
        [TestMethod]
        public void RepeatedCharacters()
        {
            var ree = new RegExEval(RegExBuilder.RexExComponentMaximumCharacterRepeat(2));
            //Assert.AreEqual("", ree.RegExToTest);

            Assert.IsTrue(ree.PasswordMatchesRegEx(""));
            Assert.IsTrue(ree.PasswordMatchesRegEx("a"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("aa"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("aaa"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("aaaa"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("cbacbcbcb"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("cbaacbcbcb"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("cbaaacbcbcb"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("cbaaaacbcbcb"));

        }
    }
}
