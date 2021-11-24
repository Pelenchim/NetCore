using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CatProducts
    {
        private string TableName = "TblProduct";
        public int Id { get; set; }
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }        
        public int IdModel { get; set; }
        public int IdBrand { get; set; }
        public int IdRange { get; set; }
        public decimal Price { get; set; }

        public Object Save(CatProducts Inst)
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
        public Object Get(CatProducts Inst)
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
