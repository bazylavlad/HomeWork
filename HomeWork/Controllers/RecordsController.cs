using HomeWork.BusinessLogic;
using HomeWork.DataAccess.Models;
using HomeWork.DataAccess.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HomeWork.Controllers
{
    public class RecordsController : ApiController
    {
        HumanManager humanManager;

        public RecordsController()
        {
            humanManager = new HumanManager();
        }

        /// <summary>
        /// POST request based function that parses and then returns Human object in JSON format or an error.
        /// </summary>
        /// <param name="record">String that will be parsed into Human instance.</param>
        /// <returns>JSON that contains parsed Human instance or an error in case of Bad Request.</returns>
        [HttpPost]
        public object Index([FromBody] string record)
        {
            var human = HumanParser.Parse(record);
            if (human != null)
            {
                humanManager.AddHuman(human);
                return human;
            }
            else return BadRequest("Invalid request");
        }

        /// <summary>
        /// GET request based function that returns all known Humans sorted by Gender and then by Last Name parameter.
        /// </summary>
        /// <returns>JSON</returns>
        [HttpGet]
        public IEnumerable<Human> Gender()
        {
            return humanManager.GetHumans(SortType.ByGenderAndLastName);
        }

        /// <summary>
        /// GET request based function that returns all known Humans sorted by LastName parameter.
        /// </summary>
        /// <returns>JSON</returns>
        [HttpGet]
        public IEnumerable<Human> LastName()
        {
            return humanManager.GetHumans(SortType.ByLastName);
        }

        /// <summary>
        /// GET request based function that returns all known Humans sorted by Birth Date parameter.
        /// </summary>
        /// <returns>JSON</returns>
        [HttpGet]
        public IEnumerable<Human> BirthDate()
        {
            return humanManager.GetHumans(SortType.ByBirthDate);
        }
    }
}
