using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeWork.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.DataAccess.Models;
using HomeWork.DataAccess.Models.Enums;

namespace HomeWork.BusinessLogic.Tests
{
    [TestClass()]
    public class HumanManagerTests
    {
        [TestMethod()]
        public void AddHumanTest()
        {
            Human testHuman = new Human
            {
                FirstName = "John",
                LastName = "Doe",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1995, 8, 22),
                Gender = Genders.Male
            };

            HumanManager hm = new HumanManager();
            List<Human> correctList = new List<Human> { testHuman };
            hm.Clear();
            hm.AddHuman(testHuman);

            var result = hm.GetHumans();

            if (result.Count == 0)
            {
                Assert.Fail();
            }

            bool invalidResult = false;

            for (int i = 0; i < result.Count && i < correctList.Count; i++)
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
        public void GetHumansByGenderAndLastNameTest()
        {
            Human humanA = new Human
            {
                FirstName = "Anna",
                LastName = "Martin",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1995, 8, 22),
                Gender = Genders.Female
            };
            Human humanB = new Human
            {
                FirstName = "Caroline",
                LastName = "Smith",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1995, 8, 22),
                Gender = Genders.Female
            };
            Human humanC = new Human
            {
                FirstName = "John",
                LastName = "Doe",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1995, 8, 22),
                Gender = Genders.Male
            };
            Human humanD = new Human
            {
                FirstName = "Peter",
                LastName = "Griffin",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1995, 8, 22),
                Gender = Genders.Male
            };

            List<Human> correctList = new List<Human> { humanA, humanB, humanC, humanD };

            HumanManager hm = new HumanManager();
            hm.Clear();
            hm.AddHuman(humanD);
            hm.AddHuman(humanA);
            hm.AddHuman(humanC);
            hm.AddHuman(humanB);

            var result = hm.GetHumans(SortType.ByGenderAndLastName);

            bool invalidResult = false;

            for (int i = 0; i < result.Count && i < correctList.Count; i++)
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
        public void GetHumansByLastNameTest()
        {
            Human humanA = new Human
            {
                FirstName = "Anna",
                LastName = "Woulverine",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1995, 8, 22),
                Gender = Genders.Female
            };
            Human humanB = new Human
            {
                FirstName = "Caroline",
                LastName = "Flash",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1995, 8, 22),
                Gender = Genders.Female
            };
            Human humanC = new Human
            {
                FirstName = "John",
                LastName = "Batman",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1995, 8, 22),
                Gender = Genders.Male
            };
            Human humanD = new Human
            {
                FirstName = "Peter",
                LastName = "Arrow",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1995, 8, 22),
                Gender = Genders.Male
            };

            List<Human> correctList = new List<Human> { humanA, humanB, humanC, humanD };

            HumanManager hm = new HumanManager();
            hm.Clear();
            hm.AddHuman(humanD);
            hm.AddHuman(humanA);
            hm.AddHuman(humanC);
            hm.AddHuman(humanB);

            var result = hm.GetHumans(SortType.ByLastName);

            bool invalidResult = false;

            for (int i = 0; i < result.Count && i < correctList.Count; i++)
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
        public void GetHumansByBirthDayTest()
        {
            Human humanA = new Human
            {
                FirstName = "Anna",
                LastName = "Martin",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1995, 8, 22),
                Gender = Genders.Female
            };
            Human humanB = new Human
            {
                FirstName = "Caroline",
                LastName = "Smith",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1996, 8, 22),
                Gender = Genders.Female
            };
            Human humanC = new Human
            {
                FirstName = "John",
                LastName = "Doe",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1997, 8, 22),
                Gender = Genders.Male
            };
            Human humanD = new Human
            {
                FirstName = "Peter",
                LastName = "Griffin",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1998, 8, 22),
                Gender = Genders.Male
            };

            List<Human> correctList = new List<Human> { humanA, humanB, humanC, humanD };

            HumanManager hm = new HumanManager();
            hm.Clear();
            hm.AddHuman(humanD);
            hm.AddHuman(humanA);
            hm.AddHuman(humanC);
            hm.AddHuman(humanB);

            var result = hm.GetHumans(SortType.ByBirthDate);

            bool invalidResult = false;

            for (int i = 0; i < result.Count && i < correctList.Count; i++)
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
        public void GetHumansTest()
        {
            Human humanA = new Human
            {
                FirstName = "Anna",
                LastName = "Woulverine",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1995, 8, 22),
                Gender = Genders.Female
            };
            Human humanB = new Human
            {
                FirstName = "Caroline",
                LastName = "Flash",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1995, 8, 22),
                Gender = Genders.Female
            };
            Human humanC = new Human
            {
                FirstName = "John",
                LastName = "Batman",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1995, 8, 22),
                Gender = Genders.Male
            };
            Human humanD = new Human
            {
                FirstName = "Peter",
                LastName = "Arrow",
                FavoriteColor = Colors.Silver,
                DateOfBirth = new DateTime(1995, 8, 22),
                Gender = Genders.Male
            };

            List<Human> correctList = new List<Human> { humanA, humanB, humanC, humanD };

            HumanManager hm = new HumanManager();
            hm.Clear();
            hm.AddHuman(humanD);
            hm.AddHuman(humanA);
            hm.AddHuman(humanC);
            hm.AddHuman(humanB);

            var result = hm.GetHumans();

            bool invalidResult = false;

            for (int i = 0; i < result.Count && i < correctList.Count; i++)
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
    }
}