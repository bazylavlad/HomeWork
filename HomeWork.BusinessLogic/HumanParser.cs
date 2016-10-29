using HomeWork.DataAccess.Models;
using HomeWork.DataAccess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.BusinessLogic
{
    public static class HumanParser
    {
        /// <summary>
        /// This function parses string into instance of Human if sting contains correct data.
        /// </summary>
        /// <param name="record">Record that will be parsed.</param>
        /// <returns>Parsed instance of Human.</returns>
        public static Human Parse(string record)
        {
            if (record == null || record.Length < 21) /*I probably have to explain why 21 is minimal length
                                                        minimum Last Name length is 1
                                                        minimum First Name length is 1
                                                        minimum Genger length is 4 (Male)
                                                        minimum Favorite Color length is 3 (Red)
                                                        minimum Date of Birth length is 8 (M/d/YYYY)
                                                        minimum space for separators is 4 (plain whitespace)
                                                        So, 1 + 1 + 4 + 3 + 8 + 4 = 21*/
            {
                return null;
            }
            string[] attributes;

            if (record.Contains(" | "))  //Here we decide what ty of separator we have and then separating record using it
            {
                attributes = record.Split(new string[] { " | " }, StringSplitOptions.None);
            }
            else if (record.Contains(", "))
            {
                attributes = record.Split(new string[] { ", " }, StringSplitOptions.None);
            }
            else
            {
                attributes = record.Split(new char[] { ' ' }, StringSplitOptions.None);
            }

            if (attributes.Length == 1) //Here we handling case when we don't have any separators
            {
                return null;
            }

            Genders gender;
            if (!Enum.TryParse(attributes[2], out gender))
            {
                return null;
            }

            Colors color;
            if (!Enum.TryParse(attributes[3], out color))
            {
                return null;
            }

            DateTime dateOfBirth;
            if (!DateTime.TryParse(attributes[4], null, System.Globalization.DateTimeStyles.None, out dateOfBirth))
            {
                return null;
            }

            Human human = new Human //Filling-up instance with data
            {
                LastName = attributes[0],
                FirstName = attributes[1],
                Gender = gender,
                FavoriteColor = color,
                DateOfBirth = dateOfBirth
            };

            return human;
        }
    }
}
