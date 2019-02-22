using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace KaliteGiris.Web.Controllers
{
    public class IndexController : Controller
    {
        
        public class Person
        {
            public int ID;
            public string Name;
            public string LastName;
            public DateTime Birthday;
            public float Weight;
        }
        // GET: Index
        public ActionResult Index()
        {
            string dir = System.IO.Path.GetDirectoryName(HttpRuntime.AppDomainAppPath);
            StreamReader _StreamReader = new StreamReader(dir + @"/JsonVeri/veri.json");
            
            string jsonData = _StreamReader.ReadToEnd();
            List<Person> listPerson = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(jsonData);

            ViewBag.veri = listPerson;
            return View();
        }
    }
}