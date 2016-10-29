using HomeWork.DataAccess.Models;
using HomeWork.DataAccess.Models.Enums;
using HomeWork.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.BusinessLogic
{
    public class HumanManager
    {
        IRepository repository;

        public HumanManager()
        {
            repository = MemoryRepository.Instance;
        }
        /// <summary>
        /// This function adds Human instance to the collection of all known Humans.
        /// </summary>
        /// <param name="human">Human that will be added.</param>
        public void AddHuman(Human human)
        {
            if (human != null)
            {
                repository.Add(human);
            }
        }
        /// <summary>
        /// This function returns list of all known humans, sorted in choosen order.
        /// </summary>
        /// <param name="sortType">Sort type.</param>
        /// <returns>Sorted list of Humans.</returns>
        public List<Human> GetHumans(SortType sortType)
        {
            switch (sortType)
            {
                case SortType.ByGenderAndLastName:
                    return repository.GetList()
                                               .OrderBy(x => x.Gender)
                                               .ThenBy(x => x.LastName)
                                               .ToList();
                case SortType.ByLastName:
                    return repository.GetList()
                                              .OrderByDescending(a => a.LastName)
                                              .ToList();
                case SortType.ByBirthDate:
                    return repository.GetList()
                                             .OrderBy(a => a.DateOfBirth)
                                             .ToList();
            }
            return null;
        }
    }
}
