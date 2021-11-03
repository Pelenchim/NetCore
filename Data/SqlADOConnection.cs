using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SqlADOConnection
    {
        static string UserSQLConnection = "";
        public static SqlServerGDatos SQLM;

        static public bool InitConnection(string user, string password)
        {
            try
            {
                UserSQLConnection = "Data Source=PELENCHIM\\PELENCHIM; Initial Catalog=DBCelulares;Integrated Security=True;";
                SQLM = new SqlServerGDatos(UserSQLConnection);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
