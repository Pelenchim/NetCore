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
    public class ReportsController : ControllerBase
    {
        [HttpPost]
        public object GenerateSalesReport(object ObjInst)
        {
            SalesReport Inst = JsonConvert.DeserializeObject<SalesReport>(ObjInst.ToString());
            return Inst.TakeReport(Inst);
        }
        [HttpPost]
        public object GenerateBuyssReport(object ObjInst)
        {
            BuysReport Inst = JsonConvert.DeserializeObject<BuysReport>(ObjInst.ToString());
            return Inst.TakeReport(Inst);
        }
    }
}
