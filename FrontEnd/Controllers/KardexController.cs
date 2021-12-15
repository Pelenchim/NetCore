using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;

namespace FrontEnd.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KardexController : ControllerBase
    {
        [HttpGet]
        public object GetKardex()
        {
            KardexView Ins = new KardexView();
            return Ins.Get(Ins);
        }
    }
}
