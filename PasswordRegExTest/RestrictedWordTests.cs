using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordRegEx;

namespace PasswordRegExTest
{
    [TestClass]
    public class RestrictedWordTests
    {
        [TestMethod]
        public void RestrictedWordAllowed()
        {
            var ree = new RegExEval(RegExBuilder.RegExComponentRestrictedWords);

            Assert.IsFalse(ree.PasswordMatchesRegEx("henry"));
            Assert.IsFalse(ree.PasswordMatchesRegEx(""));
            Assert.IsFalse(ree.PasswordMatchesRegEx("pas4s"));
            //Assert.AreEqual("", RegExBuilder.RegExComponentRestrictedWords);

        }

        [TestMethod]
        public void RestrictedWordIllegal()
        {
            var ree = new RegExEval(RegExBuilder.RegExComponentRestrictedWords);
            //Assert.AreEqual("", RegExBuilder.RegExComponentRestrictedWords);

            // Test admin
            Assert.IsTrue(ree.PasswordMatchesRegEx("admin"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("aDmin"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("aDm1n"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("adM!n"));

            // Test nurse variations
            Assert.IsTrue(ree.PasswordMatchesRegEx("nuRs"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("nUr$"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("anuRsinG"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("tranUr$i"));
           
        }

        [TestMethod]
        public void RestrictedWordStripParentheses()
        {

            Assert.AreEqual("", RegExBuilder.StripParentheses(""));
            Assert.AreEqual("", RegExBuilder.StripParentheses("a"));
            Assert.AreEqual("", RegExBuilder.StripParentheses("hello(there)buy"));
            Assert.AreEqual("", RegExBuilder.StripParentheses("()"));
            Assert.AreEqual("b", RegExBuilder.StripParentheses("(b)"));
            Assert.AreEqual("boy", RegExBuilder.StripParentheses("(boy)"));
            Assert.AreEqual("b(o)y", RegExBuilder.StripParentheses("(b(o)y)"));

        }

        [TestMethod]
        public void RestrictedWordWordsAndNumerics()
        {

            var ree = new RegExEval(RegExBuilder.RegExRestrictedWordsAndNumerics);

            // Test nurse variations
            Assert.IsTrue(ree.PasswordMatchesRegEx("nuRs"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("nUr$"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("anuRsinG"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("tranUr$i"));

            // Test long numerics
            Assert.IsTrue(ree.PasswordMatchesRegEx("wer963"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("963wer"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("wwe741ere"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("werw741werwer"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("1344567414134"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("26575741467467"));
            Assert.IsTrue(ree.PasswordMatchesRegEx(" 741 "));
            Assert.IsTrue(ree.PasswordMatchesRegEx("    741    "));
            Assert.IsTrue(ree.PasswordMatchesRegEx("x 963 x"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("x    963     x"));


            // Test a few non-matches
            Assert.IsFalse(ree.PasswordMatchesRegEx(""));
            Assert.IsFalse(ree.PasswordMatchesRegEx("12"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("12x3"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("x12x3x"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("x    088     x"));

            // Test short numerics
            Assert.IsTrue(ree.PasswordMatchesRegEx("012"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("123"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("234"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("345"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("456"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("567"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("678"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("789"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("890"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("098"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("987"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("876"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("765"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("654"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("543"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("432"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("321"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("210"));

            // Test longer numerics
            Assert.IsTrue(ree.PasswordMatchesRegEx("wer012"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("123wer"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("wwe234ere"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("werw345werwer"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("134456134134"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("265756717467467"));
            Assert.IsTrue(ree.PasswordMatchesRegEx(" 678 "));
            Assert.IsTrue(ree.PasswordMatchesRegEx("    789    "));
            Assert.IsTrue(ree.PasswordMatchesRegEx("x 890 x"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("x    098     x"));

        }

    }
}
