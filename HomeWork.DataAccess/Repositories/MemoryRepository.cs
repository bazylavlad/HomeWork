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
       
        /// <summary>
        /// Basic implementation of synch Singleton.
        /// </summary>
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
        /// <summary>
        /// This function adds new instance of Human to the list of all known Humans.
        /// </summary>
        /// <param name="human">Human that is going to be added.</param>
        public void Add(Human human)
        {
            humans.Add(human);
        }
        /// <summary>
        /// This function returns list of known Humans.
        /// </summary>
        /// <returns>List of all known Humans.</returns>
        public List<Human> GetList()
        {
            return humans;
        }
    }
}
