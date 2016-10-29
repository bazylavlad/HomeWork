using HomeWork.BusinessLogic;
using HomeWork.DataAccess.Models;
using HomeWork.DataAccess.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            if (args.Length != 1 || new string[] { "?", "help", "/help", "help?", "?help" }.Contains(args[0])) // new string[] { "?", "help", "/help", "help?", "?help" } is an array that contains all calls of "Help"
            {
                Console.WriteLine("This program requries only one argument - File Path.\nOutput is the set of records sorted in one of three ways.");
            }
            else
            {
                HumanManager humanManager = new HumanManager();
                try
                {
                    using (StreamReader sr = new StreamReader(args[0]))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var human = HumanParser.Parse(line);

                            if (human != null)
                            {
                                humanManager.AddHuman(human);
                            }
                            else
                            {
                                Console.WriteLine("Bad data.");
                                break;
                            }
                        }
                    }
                    int option = 0;
                    int[] acceptableChoices = new int[] { 1, 2, 3 };

                    while (!acceptableChoices.Contains(option))
                    {
                        Console.WriteLine("Please choose how you'd like to print result.\n1) Sorted by gender (females before males) then by last name ascending.\n2) Sorted by birth date, ascending.\n3) Sorted by last name, descending.");
                        Int32.TryParse(Console.ReadLine(), out option);
                    }
                    List<Human> resultList = humanManager.GetHumans((SortType)option);
                    foreach (var item in resultList)
                    {
                        Console.WriteLine($"{item.LastName} {item.FirstName} {item.Gender} {item.FavoriteColor} {String.Format("{0:d}", item.DateOfBirth)}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to open this file. Please, check the File Path.");
                }
            }
            Console.WriteLine("Please, press \"Enter\" key to exit ...");
            Console.ReadLine();
            return;
        }
    }
}
