using System;
using System.Collections.Generic;
using WcfService1;


namespace DataTransaction
{
    public class MyData
    {
        private exceltutorsEntities obj = new exceltutorsEntities();
        public List<Contents> myContent = new List<Contents>();

        public List<Contents> List()
        {
            obj.Contents
            return myContent;
        }
    }
}
