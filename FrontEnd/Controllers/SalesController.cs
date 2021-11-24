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
    public class SalesController : ControllerBase
    {
        [HttpGet]
        public object GetCatalogs()
        {
            List<Object> Response = new List<object>();
            CatProducts CP = new CatProducts();
            Response.Add(CP.Get(CP));
            CatClients CC = new CatClients();
            Response.Add(CC.Get(CC));
            return Response;
        }
        [HttpPost]
        public object SaveSale(object ObjIns)
        {
            Sales Ins = JsonConvert.DeserializeObject<Sales>(ObjIns.ToString());
            Ins.Save(Ins);
            return true;
        }
    }
}
