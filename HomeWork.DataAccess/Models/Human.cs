using HomeWork.DataAccess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.DataAccess.Models
{
    public class Human
    {
        public string LastName
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public Genders Gender
        {
            get;
            set;
        }
        public Colors FavoriteColor
        {
            get;
            set;
        }
        public DateTime DateOfBirth
        {
            get;
            set;
        }

        public bool IsEqual(Human anotherHuman)
        {
            if (this.FirstName.Equals(anotherHuman.FirstName) &&
                this.DateOfBirth.Equals(anotherHuman.DateOfBirth) &&
                this.LastName.Equals(anotherHuman.LastName) &&
                this.Gender.Equals(anotherHuman.Gender) &&
                this.FavoriteColor.Equals(anotherHuman.FavoriteColor))

            {
                return true;
            }
            return false;
        }
    }
}
