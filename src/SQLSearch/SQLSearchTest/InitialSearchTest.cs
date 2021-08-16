using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System.Collections.Generic;
using System.IO;

namespace SQLSearchTest
{
    [TestClass]
    public class InitialSearchTest
    {
        SearchInitial search;
        string repoLocation;
        [TestInitialize]
        public void TestInitialize()
        {
            repoLocation = @"C:\Users\Nehemiah\Documents\coding stuff\SQLSearch\SQLSearch\src\SQLSearch\SQLSearchTest\TestSQLScripts";
        }


        [TestMethod]
        public void TestInvalidAuthor()
        {
            search = new SearchInitial("", "Invalidauthor", repoLocation);
            var output = search.run();
            Assert.AreEqual(0, output.Count);
        }
        [TestMethod]
        public void TestValidAuthor()
        {
            search = new SearchInitial("", "ndeason", repoLocation);
            var output = search.run();
            Assert.AreEqual(2, output.Count);
        }
        [TestMethod]
        public void testInvalidSearch()
        {
            {
                search = new SearchInitial("Nonsenseical", "", repoLocation);
                var output = search.run();
                Assert.AreEqual(0, output.Count);
            }
        }
    }
}
