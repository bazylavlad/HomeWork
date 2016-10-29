using HomeWork.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HomeWork.Controllers
{
    public class RecordsController : ApiController
    {
        List<Human> listHumans;
        HumanManager humanManager;

        public RecordsController()
        {
            humanManager = new HumanManager();
            listHumans = new List<Human>();
            listHumans.Add(new Human() { year = 13, name = "Alina", gender = false });
            listHumans.Add(new Human() { year = 13, name = "Alina", gender = false });
            listHumans.Add(new Human() { year = 11, name = "Vova", gender = true });

        }

        public class Human
        {
            public int year;
            public string name;
            public bool gender;
        }
        
        [HttpPost]
        public object Index([FromBody]string record)
        {
            var human = new Human(); //HumanParser.Parse(record);
            human.name = "asdasd";
            //humanManager.AddHuman(human);
            return human;
            return BadRequest("Invalid request");
        }
        
        [HttpGet]
        public IEnumerable<Human> Gender()
        {
            return listHumans.OrderBy(h => h.gender);
        }

        [HttpGet]
        public IEnumerable<Human> Name()
        {
            return listHumans.OrderBy(h => h.name).Reverse();
        }
    }
}
