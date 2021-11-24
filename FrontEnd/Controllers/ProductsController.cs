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
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        public object SaveProduct(object ObjIns)
        {
            CatProducts Ins = JsonConvert.DeserializeObject<CatProducts>(ObjIns.ToString());
            Ins.Save(Ins);
            return true;
        }
        [HttpGet]
        public object GetProducts()
        {
            List<Object> Response = new List<object>();
            CatProducts CP = new CatProducts();
            Response.Add(CP.Get(CP));
            CatCategory CC = new CatCategory();
            Response.Add(CC.Get(CC));
            CatModels CM = new CatModels();
            Response.Add(CM.Get(CM));
            CatBrands CB = new CatBrands();
            Response.Add(CB.Get(CB));
            CatRange CR = new CatRange();
            Response.Add(CR.Get(CR));
            return Response;
        }
    }
}
