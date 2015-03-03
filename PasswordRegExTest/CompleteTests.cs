using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordRegEx;

namespace PasswordRegExTest
{
    [TestClass]
    public class CompleteTests : TestSettings
    {
        [TestMethod]
        public void TestCombinedRules()
        {
            var ree = new RegExEval(RegExBuilder.RegExCombined(RegExBuilder.RegExComponentMinimumLength(6), RegExBuilder.RegExComponentAnyThreeOfFourComplexity, RegExBuilder.RegExRestrictedWordsAndNumerics, RegExBuilder.RexExComponentMaximumCharacterRepeat(2)));
            //Assert.AreEqual("", ree.RegExToTest);

            Assert.IsTrue(ree.PasswordMatchesRegEx("aA1bcd"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("aA!bcd"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("A1!BCD"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("a1!bcd"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("aa1!aa"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("aAaaaa"));  // Not complex enough
            Assert.IsFalse(ree.PasswordMatchesRegEx("aAaaaa"));  // Not complex enough
            Assert.IsFalse(ree.PasswordMatchesRegEx("A1AAAA"));  // Not complex enough
            Assert.IsFalse(ree.PasswordMatchesRegEx("a1aaaa"));  // Not complex enough
            Assert.IsFalse(ree.PasswordMatchesRegEx("adm!n8"));  // Admin imbedded in there
            Assert.IsFalse(ree.PasswordMatchesRegEx("#adMin"));  // Admin imbedded in there
            Assert.IsFalse(ree.PasswordMatchesRegEx("a1!aa"));   // Not long enough
            Assert.IsFalse(ree.PasswordMatchesRegEx("A1!aaa"));   // Too many repeated characters
            Assert.IsFalse(ree.PasswordMatchesRegEx("aaaA1!"));   // Too many repeated characters

            // Various FAIL cases
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx(""));   // No password
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("a"));   // Too short and not complex enough
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("a!A1"));   // Too short
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("aaa!!!AAA111"));   // Too many repeated characters
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("aa!!567AA"));   // Consecutive umeric sequence
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("aa!!369AA"));   // Keypad numeric sequence
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("aa!!NursingRocksAA11"));   // Restricted word
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("aa!!nur$ingRocksAA11"));   // Restricted word

            // Various PASS cases
            Assert.IsFalse(ree.PasswordFailsAgainstRegEx("Jackson45!"));
            Assert.IsFalse(ree.PasswordFailsAgainstRegEx("horse#67blue"));
            Assert.IsFalse(ree.PasswordFailsAgainstRegEx("hi$3jo"));

        }
    }
}
