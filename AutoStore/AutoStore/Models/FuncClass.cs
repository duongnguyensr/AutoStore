using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoStore.Models
{
    public class FuncClass
    {
        public static string genNextCode()
        {
            //Phải viết lại theo mô hình nào đó
            Random rnd = new Random();
            int i = rnd.Next(int.MaxValue);
            return (i % 10000000000).ToString();
        }
    }
}