using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CatProviders
    {
        private string TableName = "TblProvider";
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ruc { get; set; }
        public string Phone { get; set; }
        public string Direction { get; set; }
        public int State { get; set; }

        public Object Save(CatProviders Inst)
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
        public Object Get(CatProviders Inst)
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
