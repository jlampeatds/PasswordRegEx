using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordRegEx;

namespace PasswordRegExTest
{
    [TestClass]
    public class NumericTests : TestSettings
    {
        [TestMethod]
        public void NumericTestKeypadNumerics()
        {

            var ree = new RegExEval(RegExBuilder.RegExComponentKeypadNumerics);

            // Test short numerics
            Assert.IsTrue(ree.PasswordMatchesRegEx("147"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("741"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("369"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("963"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("025"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("520"));

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

        }

        [TestMethod]
        public void NumericTestConsecutiveSequences()
        {
            var ree = new RegExEval(RegExBuilder.RegExComponentConsecutiveNumerics);

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

            // Test a few non-matches
            Assert.IsFalse(ree.PasswordMatchesRegEx(""));
            Assert.IsFalse(ree.PasswordMatchesRegEx("12"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("12x3"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("x12x3x"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("x    088     x"));

        }
    }
}
