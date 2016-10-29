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
    }
}
