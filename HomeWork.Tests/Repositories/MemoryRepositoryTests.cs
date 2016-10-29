using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeWork.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.DataAccess.Models;
using HomeWork.DataAccess.Models.Enums;

namespace HomeWork.DataAccess.Repositories.Tests
{
    [TestClass()]
    public class MemoryRepositoryTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var mr = MemoryRepository.Instance;

            Human testHuman = new Human
            {
                FirstName = "John",
                LastName = "Doe",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1995, 8, 22),
                Gender = Genders.Male
            };

            List<Human> correctList = new List<Human> { testHuman };

            mr.Add(testHuman);

            var result = mr.GetList();

            bool invalidResult = false;

            for (int i = 0; i < result.Count; i++)
            {
                if (!result[i].IsEqual(correctList[i]))
                {
                    invalidResult = true;
                    break;
                }
            }

            if (invalidResult)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GetInstanceTest()
        {
            MemoryRepository rep;
            if ((rep = MemoryRepository.Instance) == null)
            {
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void GetListTest()
        {
            MemoryRepository mr = MemoryRepository.Instance;
            List<Human> humanList;
            if ((humanList = mr.GetList()) == null)
            {
                Assert.Fail();
            }
        }
    }
}