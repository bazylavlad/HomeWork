﻿using HomeWork.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.DataAccess.Repositories
{
    public interface IRepository
    {
        void Add(Human human);
        List<Human> GetList();
        void Clear();
    }
}
