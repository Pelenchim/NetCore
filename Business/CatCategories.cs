﻿using System;
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
        public Object Get(CatCategory Inst)
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
