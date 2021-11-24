using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Buys
    {
        private string TableName = "TblBuy";
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public int IdProvider { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public int IdPaymentMethod { get; set; }

        public List<BuysDetail> Detail = new List<BuysDetail>();

        public Object Save(Buys Inst)
        {
            try
            {
                SqlADOConnection.InitConnection("sa", "1234");
                int IdBuy = Convert.ToInt32(SqlADOConnection.SQLM.InsertObject(TableName, Inst));
                foreach (BuysDetail row in Inst.Detail)
                {
                    //SalesDetail detail = new SalesDetail();
                    //NewID.IdSale = (JsonConvert.DeserializeObject<SalesDetail>(row.ToString())).IdSale;
                    row.IdBuy = IdBuy;
                    row.Save(row);
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Object Get(Buys Inst)
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
