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
        #region Category
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
        #endregion

        #region Client
        [HttpPost]
        public object SaveClient(object ObjIns)
        {
            CatClients Ins = JsonConvert.DeserializeObject<CatClients>(ObjIns.ToString());
            Ins.Save(Ins);
            return true;
        }
        [HttpGet]
        public object GetClients()
        {
            CatClients Ins = new CatClients();
            return Ins.Get(Ins);
        }

        #endregion

        #region Provider
        [HttpPost]
        public object SaveProvider(object ObjIns)
        {
            CatProviders Ins = JsonConvert.DeserializeObject<CatProviders>(ObjIns.ToString());
            Ins.Save(Ins);
            return true;
        }
        [HttpGet]
        public object GetProviders()
        {
            CatProviders Ins = new CatProviders();
            return Ins.Get(Ins);
        }

        #endregion

        #region Brand
        [HttpPost]
        public object SaveBrand(object ObjIns)
        {
            CatBrands Ins = JsonConvert.DeserializeObject<CatBrands>(ObjIns.ToString());
            Ins.Save(Ins);
            return true;
        }
        [HttpGet]
        public object GetBrands()
        {
            CatBrands Ins = new CatBrands();
            return Ins.Get(Ins);
        }

        #endregion

        #region Model
        [HttpPost]
        public object SaveModel(object ObjIns)
        {
            CatModels Ins = JsonConvert.DeserializeObject<CatModels>(ObjIns.ToString());
            Ins.Save(Ins);
            return true;
        }
        [HttpGet]
        public object GetModels()
        {
            CatModels Ins = new CatModels();
            return Ins.Get(Ins);
        }

        #endregion

        #region Range
        [HttpPost]
        public object SaveRange(object ObjIns)
        {
            CatRange Ins = JsonConvert.DeserializeObject<CatRange>(ObjIns.ToString());
            Ins.Save(Ins);
            return true;
        }
        [HttpGet]
        public object GetRanges()
        {
            CatRange Ins = new CatRange();
            return Ins.Get(Ins);
        }

        #endregion

        #region Sales
        [HttpGet]
        public object GetSales()
        {
            Sales Ins = new Sales();
            return Ins.Get(Ins);
        }

        #endregion

        #region Buys
        [HttpGet]
        public object GetBuys()
        {
            Buys Ins = new Buys();
            return Ins.Get(Ins);
        }
        #endregion
    }
}
