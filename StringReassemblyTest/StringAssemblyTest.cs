using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringReassemblyByJK;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

//Test class for testing StringReassembly class methods

namespace StringReassemblyTest
{
    [TestClass]
    public class StringReassemblyUnitTest
    {
        //Initialise Test Variables and required parameters
        StringReassembly strAssembly = new StringReassembly();

        [TestMethod]
        public void TestAssemblyEmptySet()
        {
            List<string> stringSet = new List<string>();
            string result = strAssembly.AssembleStrings(stringSet);
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void TestAssemblyEmptyStrings()
        {            
            string result = strAssembly.AssembleStrings(new List<string> { "", "" });
            Assert.IsTrue(result == "");
        }

        [TestMethod]
        public void TestAssemblyFirstEmpty()
        {
            string result = strAssembly.AssembleStrings(new List<string> { "", "second" });
            Assert.IsTrue(result.Equals("second"));
        }

        [TestMethod]
        public void TestAssemblySecondEmpty()
        {           
            string result = strAssembly.AssembleStrings(new List<string> { "first",""});            
            Assert.IsTrue(result.Equals("first"));            
        }        

        [TestMethod]
        public void TestAssemblyNoOverlap()
        {           
            string result = strAssembly.AssembleStrings(new List<string> { "first","second"} );            
            Assert.IsTrue((result == "firstsecond") || (result == "secondfirst"));
        }

        [TestMethod]
        public void TestAssemblyNoOverlap2()
        {
            List<string> arr = new List<string> { "Test", "For", "Aderant" };
            string result = strAssembly.AssembleStrings(arr);
            Assert.IsTrue(("TestForAderant" == result) || ("TestAderantFor" == result));
        }

        [TestMethod]
        public void TestAssemblyNoOverlapSubString1()
        {
            List<string> stringSet = new List<string>
                {"My Name","is","Jaishree","Kulkarni" };
            string result = strAssembly.AssembleStrings(stringSet);
            Assert.IsTrue(("My NameJaishreeKulkarni" == result) || ("My NameKulkarniJaishree" == result));
        }

        [TestMethod]
        public void TestAssemblyOverlapEx1()
        {           
            List<string> stringSet = new List<string>
            {
                "all is well",
                "ell that en",
                "hat end",
                "t ends well"
            };
            string result = strAssembly.AssembleStrings(stringSet);
            Assert.AreEqual("all is well that ends well", result);
        }

        [TestMethod]
        public void TestAssemblyOverlapEx2()
        {
            List<string> stringSet = new List<string>
            { "a quick brown fox","k brown fox jumps","x jumps over","over the", "over the lazy dog"};
            strAssembly.AssembleStrings(stringSet);
            Debug.Print(stringSet[0]);
            Assert.AreEqual("a quick brown fox jumps over the lazy dog", stringSet[0]);
        }

       
        [TestMethod]
        public void TestAssemblyOverlapEx3()
        {
            List<string> arr = new List<string> { "catg", "ctaagt", "gcta", "ttca", "atgcatc" };
            string result = strAssembly.AssembleStrings(arr);
            Assert.AreEqual("gctaagttcatgcatc", result);
        }

        [TestMethod]
        public void TestAssemblyOverlapEx4()
        {

            List<string> stringSet = new List<string>
            { "a quick brown fox.","k brown fox. jumps","x. jumps over,","over, the", "over, the lazy dog."};
            strAssembly.AssembleStrings(stringSet);
            Assert.AreEqual("a quick brown fox. jumps over, the lazy dog.", stringSet[0]);
        }
    }
}
