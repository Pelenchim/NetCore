using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Kardex
    {
        private string TableName = "TblKardex";
        public int Id { get; set; }
        public string Type { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public int IdTransaction { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }

        public Object Save(Kardex Inst)
        {
            try
            {
                SqlADOConnection.InitConnection("sa", "1234");
                if (Inst.Id == 0)
                {
                    return SqlADOConnection.SQLM.InsertObject(TableName, Inst);
                }
                else
                {
                    return SqlADOConnection.SQLM.UpdateObject(TableName, Inst, "Id");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
