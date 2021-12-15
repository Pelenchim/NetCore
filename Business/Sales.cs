using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        public List<SalesDetail> Detail = new List<SalesDetail>();

        public Object Save(Sales Inst)
        {
            try
            {
                SqlADOConnection.InitConnection("sa", "1234");
                int IdSale = Convert.ToInt32(SqlADOConnection.SQLM.InsertObject(TableName, Inst));
                foreach (SalesDetail row in Inst.Detail)
                {
                    //SalesDetail detail = new SalesDetail();
                    //NewID.IdSale = (JsonConvert.DeserializeObject<SalesDetail>(row.ToString())).IdSale;
                    row.IdSale = IdSale;
                    row.Save(row);

                    Kardex Kardex = new Kardex();
                    Kardex.Type = "Salida";
                    Kardex.IdProduct = row.IdProduct;
                    Kardex.Quantity = 1;
                    Kardex.IdTransaction = IdSale;
                    Kardex.Date = DateTime.Now;
                    Kardex.Price = row.Price;
                    Kardex.Save(Kardex);
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
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
