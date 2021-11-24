using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BuysController : ControllerBase
    {
        [HttpGet]
        public object GetCatalogs()
        {
            List<Object> Response = new List<object>();
            CatProducts CP = new CatProducts();
            Response.Add(CP.Get(CP));
            CatProviders CC = new CatProviders();
            Response.Add(CC.Get(CC));
            return Response;
        }
        [HttpPost]
        public object SaveBuy(object ObjIns)
        {
            Buys Ins = JsonConvert.DeserializeObject<Buys>(ObjIns.ToString());
            Ins.Save(Ins);
            return true;
        }
    }
}
