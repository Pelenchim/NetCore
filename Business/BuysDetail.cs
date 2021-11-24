using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BuysDetail
    {
        private string TableName = "TblBuyDetail";
        public int Id { get; set; }
        public int IdBuy { get; set; }
        public int IdProduct { get; set; }
        public decimal Price { get; set; }
        public decimal WarrantyDays { get; set; }

        public Object Save(BuysDetail Inst)
        {
            try
            {
                SqlADOConnection.InitConnection("sa", "1234");
                return SqlADOConnection.SQLM.InsertObject(TableName, Inst);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Object Get(BuysDetail Inst)
        {
            try
            {
                SqlADOConnection.InitConnection("sa", "1234");
                return SqlADOConnection.SQLM.TakeList(TableName, Inst, null);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
