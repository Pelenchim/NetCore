using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Sales
    {

        private string TableName = "TblSale";
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public int IdClient { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalDiscount { get; set; }
        public int IdPaymentMethod { get; set; }

        public Object Get(Sales Inst)
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
