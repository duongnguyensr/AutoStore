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

        public static string ConvertDateTime(string d)
        {
            //string[] parts = d.Split('/');
            //string dt = String.Format("{0}/{1}/{2}", parts[1], parts[0], parts[2]);
            //return dt;

            string[] parts = d.Split(' ');
            string[] parts1 = parts[0].Split('/');
            string dt = String.Format("{0}/{1}/{2}", parts1[1], parts1[0], parts1[2]);
            return dt;
        }
    }
}