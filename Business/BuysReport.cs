using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Business
{
    public class BuysReport
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Comprador { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public string Proveedor { get; set; }

        public List<Object> Params { get; set; }
    
        public Object TakeReport(BuysReport Inst)
        {
            try
            {
                List<Object> SqlParams = new List<Object>();
                SqlParams.Add(Convert.ToDateTime(Params[0]));
                SqlParams.Add(Convert.ToDateTime(Params[1]));
                SqlADOConnection.InitConnection("sa", "1234");
                var Report = SqlADOConnection.SQLM.TakeListWithProcedure("spBuysReport", Inst, SqlParams);
                return Report;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
