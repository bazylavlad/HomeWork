using HomeWork.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.DataAccess.Repositories
{
    public class MemoryRepository: IRepository
    {
        static object _lock = new object();

        List<Human> humans;

        MemoryRepository()
        {
            humans = new List<Human>();
        }

        static MemoryRepository instance;
        public static MemoryRepository Instance
        {
            get
            {
                if(instance == null)
                {
                    lock(_lock)
                    {
                        if(instance == null)
                        {
                            instance = new MemoryRepository();
                        }
                    }
                }
                return instance;
            }
        }

        public void Add()
        {
            throw new NotImplementedException();
        }
    }
}
