using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class KardexView
    {
        private string TableName = "ViewKardex";
        public int Id { get; set; }
        public string Tipo { get; set; }
        public int Transaccion { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }

        public Object Get(KardexView Inst)
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
