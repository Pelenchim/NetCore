using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Data
{
    public abstract class GDataAbstrac
    {
        protected IDbConnection SQLMCon;
        protected abstract IDbConnection CreateConection(string stringCon);
        protected abstract IDbCommand CommandSQL(string commandSql, IDbConnection connection);
        protected abstract IDbDataAdapter CreateDataAdapterSQL(string commandSql, IDbConnection connection);
        public bool ExecuteSqlQuery(string strQuery)
        {
            try
            {                
                SQLMCon.Open();
                var cmd = CommandSQL(strQuery, SQLMCon);
                cmd.ExecuteNonQuery();
                SQLMCon.Close();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable GetDataSQL(string queryString)
        {
            DataSet ObjDS = new DataSet();
            CreateDataAdapterSQL(queryString, SQLMCon).Fill(ObjDS);
            return ObjDS.Tables[0].Copy();
        }
        public Object InsertObject(string TableName, object Inst)
        {
            try
            {
                string Values = "";
                Type _type = Inst.GetType();
                PropertyInfo[] lst = _type.GetProperties();
                foreach (PropertyInfo oProperty in lst)
                {
                    string AttributeName = oProperty.Name;
                    var AttributeValue = oProperty.GetValue(Inst);

                    if (AttributeName != "Id")
                    {
                        if (AttributeValue.GetType() == typeof(string) || AttributeValue.GetType() == typeof(DateTime))
                        {
                            Values = Values + "'" + AttributeValue.ToString() + "',";
                        }
                        else
                        {
                            if ((Int32)AttributeValue != -1)
                            {
                                Values = Values + AttributeValue.ToString() + ',';
                            }
                        }
                    }
                }
                Values = Values.TrimEnd(',');
                string strQuery = "INSERT INTO " + TableName + " VALUES(" + Values + ")";
                return ExecuteSqlQuery(strQuery);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Object TakeList(string TableName, Object Inst, string Condition)
        {
            try
            {
                string ConditionString = "";
                if (Condition != null)
                {
                    ConditionString = " WHERE " + Condition;
                }
                string queryString = "SELECT * FROM " + TableName + ConditionString;
                DataTable Table = GetDataSQL(queryString);
                List<Object> ListD = ConvertDataTable(Table, Inst);
                return ListD;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private static List<Object> ConvertDataTable(DataTable dt, Object Inst)
        {
            List<Object> data = new List<object>();
            foreach (DataRow row in dt.Rows)
            {
                var item = GetItem(row, Inst);
                data.Add(item);
            }
            return data;
        }
        private static Object GetItem(DataRow dr, Object Inst)
        {
            Type temp = Inst.GetType();
            var obj = Activator.CreateInstance(Inst.GetType());
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return obj;
        }

    }
}
