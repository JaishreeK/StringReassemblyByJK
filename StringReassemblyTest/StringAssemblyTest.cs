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

        [TestMethod]
        public void TestAssemblyOverlapEx5()
        {
            var fragments = "m quaerat voluptatem.;pora incidunt ut labore et d;, consectetur, adipisci velit;olore magnam aliqua;idunt ut labore et dolore magn;uptatem.;i dolorem ipsum qu;iquam quaerat vol;psum quia dolor sit amet, consectetur, a;ia dolor sit amet, conse;squam est, qui do;Neque porro quisquam est, qu;aerat voluptatem.;m eius modi tem;Neque porro qui;, sed quia non numquam ei;lorem ipsum quia dolor sit amet;ctetur, adipisci velit, sed quia non numq;unt ut labore et dolore magnam aliquam qu;dipisci velit, sed quia non numqua;us modi tempora incid;Neque porro quisquam est, qui dolorem i;uam eius modi tem;pora inc;am al"
                                .Split(';').Select(s => s.TrimStart()).ToList();
            string result = strAssembly.AssembleStrings(fragments);
            Debug.Print(result);
            Assert.IsTrue(result == "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.");

        }
    }
}
