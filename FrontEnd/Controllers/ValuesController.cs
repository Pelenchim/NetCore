using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public object SaveCategory(object ObjIns)
        {
            CatCategory Ins = JsonConvert.DeserializeObject<CatCategory>(ObjIns.ToString());
            Ins.Save(Ins);
            return true;
        }
        [HttpGet]
        public object GetCategories()
        {
            CatCategory Ins = new CatCategory();            
            return Ins.Get(Ins);
        }
    }
}
