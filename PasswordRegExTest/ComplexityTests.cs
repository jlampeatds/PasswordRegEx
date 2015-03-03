using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordRegEx;

namespace PasswordRegExTest
{
    [TestClass]
    public class ComplexityTests : TestSettings
    {

        [TestMethod]
        public void ComplexityTestElements()
        {
            var ree = new RegExEval();

            // RegExComponentThreeLowerUpperNumeric
            ree.RegExToTest = RegExBuilder.RegExComponentThreeLowerUpperNumeric;
            Assert.IsTrue(ree.PasswordMatchesRegEx("aA1"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("a1!"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("A1!"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("aA!"));            

            // RegExComponentThreeLowerNumericSpecial
            ree.RegExToTest = RegExBuilder.RegExComponentThreeLowerNumericSpecial;
            Assert.IsFalse(ree.PasswordMatchesRegEx("aA1"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("a1!"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("A1!"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("aA!"));            

            // RegExComponentThreeUpperNumericSpecial
            ree.RegExToTest = RegExBuilder.RegExComponentThreeUpperNumericSpecial;
            Assert.IsFalse(ree.PasswordMatchesRegEx("aA1"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("a1!"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("A1!"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("aA!"));            

            // RegExComponentThreeLowerUpperSpecial
            ree.RegExToTest = RegExBuilder.RegExComponentThreeLowerUpperSpecial;
            Assert.IsFalse(ree.PasswordMatchesRegEx("aA1"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("a1!"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("A1!"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("aA!"));


            // RegExComponentThreeLowerUpperNumeric
            ree.RegExToTest = RegExBuilder.RegExComponentThreeLowerUpperNumeric;
            Assert.IsTrue(ree.PasswordMatchesRegEx("aA1aA1aA1"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("a1!a1!a1!"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("A1!A1!A1!"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("aA!aA!aA!"));

            // RegExComponentThreeLowerNumericSpecial
            ree.RegExToTest = RegExBuilder.RegExComponentThreeLowerNumericSpecial;
            Assert.IsFalse(ree.PasswordMatchesRegEx("aA1aA1aA1"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("a1!a1!a1!"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("A1!A1!A1!"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("aA!aA!aA!"));

            // RegExComponentThreeUpperNumericSpecial
            ree.RegExToTest = RegExBuilder.RegExComponentThreeUpperNumericSpecial;
            Assert.IsFalse(ree.PasswordMatchesRegEx("aA1aA1aA1"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("a1!a1!a1!"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("A1!A1!A1!"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("aA!aA!aA!"));

            // RegExComponentThreeLowerUpperSpecial
            ree.RegExToTest = RegExBuilder.RegExComponentThreeLowerUpperSpecial;
            Assert.IsFalse(ree.PasswordMatchesRegEx("aA1aA1aA1"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("a1!a1!a1!"));
            Assert.IsFalse(ree.PasswordMatchesRegEx("A1!A1!A1!"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("aA!aA!aA!"));            

        }

        [TestMethod]
        public void ComplexityTestNotComplexEnough()
        {
            var ree = new RegExEval(RegExBuilder.RegExComponentAnyThreeOfFourComplexity);

            // Test all same character cases
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("aaaaaa"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("AAAAAA"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("!!!!!!"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("111111"));
            // Test all same type of character cases
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("lrjens"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("AMUWHJ"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("!>&#$;"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("148923"));
            // Test two of three rule cases
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("lrjWHJ"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("lrj#$;"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("lrj923"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("AMUens"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("AMU#$;"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("AMU923"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("!>&ens"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("!>&WHJ"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("!>&923"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("148ens"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("148WHJ"));
            Assert.IsTrue(ree.PasswordFailsAgainstRegEx("148#$;"));
        }

        [TestMethod]
        public void ComplexityTestComplexEnough()
        {
            var ree = new RegExEval(RegExBuilder.RegExComponentAnyThreeOfFourComplexity);

            // Test short cases
            Assert.IsTrue(ree.PasswordMatchesRegEx("aA1"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("a1!"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("A1!"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("aA!"));            

            // Test two of three rule cases
            Assert.IsTrue(ree.PasswordMatchesRegEx("lrjWHJ1"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("lrjWHJ!"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("lrj#$;A"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("lrj#$;1"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("lrj923A"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("lrj923!"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("AMUens1"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("AMUens!"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("AMU#$;a"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("AMU#$;1"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("AMU923a"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("AMU923!"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("!>&ensA"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("!>&ens1"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("!>&WHJa"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("!>&WHJ1"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("!>&923a"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("!>&923A"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("148ensA"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("148ens!"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("148WHJa"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("148WHJ!"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("148#$;a"));
            Assert.IsTrue(ree.PasswordMatchesRegEx("148#$;A"));

        }

    }
}
