using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeWork.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.DataAccess.Models;

namespace HomeWork.BusinessLogic.Tests
{
    [TestClass()]
    public class HumanParserTests
    {
        [TestMethod()]
        public void ParseWithCommaTest()
        {
            string testString = "Vladyslav, Bazyliak, Male, White, 8/22/1995";
            Human human = HumanParser.Parse(testString);
            if (human == null)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ParseWithSpaceTest()
        {
            string testString = "Vladyslav Bazyliak Male White 8/22/1995";
            Human human = HumanParser.Parse(testString);
            if (human == null)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ParseWithBarTest()
        {
            string testString = "Vladyslav | Bazyliak | Male | White | 8/22/1995";
            Human human = HumanParser.Parse(testString);
            if (human == null)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void ParseWithEmptyStringTest()
        {
            string testString = "";
            Human human = HumanParser.Parse(testString);
            if (human != null)
            {
                Assert.Fail();
            }
        }
    }
}