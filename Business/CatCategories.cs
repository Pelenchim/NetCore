using System;
using Data;

namespace Business
{
    public class CatCategory
    {
        private string TableName = "TblCategory";
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int State { get; set; }

        public Object Save(CatCategory Inst)
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
    }    
}
