using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CatClients
    {
        private string TableName = "TblClient";
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int State { get; set; }

        public Object Save(CatClients Inst)
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
        public Object Get(CatClients Inst)
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
