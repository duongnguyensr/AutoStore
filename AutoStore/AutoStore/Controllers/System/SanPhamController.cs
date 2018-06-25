using AutoStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoStore.Controllers.System
{
    [SessionTimeout]
    public class SanPhamController : Controller
    {
        private DBConnection db = new DBConnection();
        private static string query = null;
        private static int checksearch = 0;
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (checksearch==0)
                return View(db.SANPHAMs.ToList().OrderBy(a => a.TENSP));
            else
                return View(db.SANPHAMs.SqlQuery(query).ToList().OrderBy(a => a.TENSP));
        }

        public ActionResult getDataLOAISANPHAM()
        {
            var maL = db.LOAISANPHAMs.ToList().OrderBy(a => a.TENLOAI);
            return View(maL);
        }

        public ActionResult getDataNHASANXUAT()
        {
            var maNCC = db.NHASANXUATs.ToList().OrderBy(a => a.TENNSX);
            return View(maNCC);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="anh"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Insert(HttpPostedFileBase anh)
        {
            string objtensp = Request.Form["tensp"];
            var check = db.SANPHAMs.SingleOrDefault(a => a.TENSP == objtensp);
            if (check == null)
            {
                string objmansx = Request.Form["mansx"];
                string objmausac = Request.Form["mausac"];
                string objmaloai = Request.Form["maloai"];
                string objmota = Request.Form["mota"];
                double objdongia = double.Parse(Request.Form["dongia"]);
                int objsoluong = Int32.Parse(Request.Form["soluong"]);
                int objnam = Int32.Parse(Request.Form["nam"]);
                int objkm = Int32.Parse(Request.Form["km"]);
                string objanh = "";
                if (anh != null)
                {
                    string pic = Path.GetFileName(anh.FileName);
                    objanh = "/Content/ClientVender/media/186x113/" + pic;
                    string path = Path.Combine(
                                           Server.MapPath("~/Content/ClientVender/media/186x113"), pic);
                    // file is uploaded
                    anh.SaveAs(path);
                }
                SANPHAM temp = new SANPHAM { MASP = FuncClass.genNextCode(), TENSP = objtensp, MANSX = objmansx, MAUSAC = objmausac, MALOAI = objmaloai, MOTA = objmota, DONGIA = objdongia, SOLUONG = objsoluong, YEAR = objnam, KM = objkm, HINHANH = objanh };
                db.SANPHAMs.Add(temp);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string ID)
        {
            var temp = new SANPHAM { MASP = ID };
            db.SANPHAMs.Attach(temp);
            db.SANPHAMs.Remove(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult update(string id, HttpPostedFileBase anh)
        {
            var result = db.SANPHAMs.SingleOrDefault(a => a.MASP == id);
            if (result != null)
            {
                result.TENSP = Request.Form["tensp"];
                result.MANSX = Request.Form["mansx"];
                result.MAUSAC = Request.Form["mausac"];
                result.MALOAI = Request.Form["maloai"];
                result.MOTA = Request.Form["mota"];
                result.DONGIA = double.Parse(Request.Form["dongia"]);
                result.SOLUONG = Int32.Parse(Request.Form["soluong"]);
                result.YEAR = Int32.Parse(Request.Form["nam"]);
                if (anh != null)
                {
                    string pic = Path.GetFileName(anh.FileName);
                    result.HINHANH = "/Content/ClientVender/media/186x113/" + pic;
                    string path = Path.Combine(Server.MapPath("~/Content/ClientVender/media/186x113"), pic);
                    // file is uploaded
                    anh.SaveAs(path);
                }

                result.KM = Int32.Parse(Request.Form["km"]);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Search()
        {
            string objmansx = Request.Form["mansx"];
            string objtensp = Request.Form["tensp"];
            string objmausac = Request.Form["mausac"];
            string objmaloai = Request.Form["maloai"];
            string objmota = Request.Form["mota"];
            double objdongia=0;
            if (Request.Form["dongia"] != "")
            {
                 objdongia = double.Parse(Request.Form["dongia"]);
            }

            int objsoluong = 0;
            if (Request.Form["soluong"] != "")
            {
                objsoluong = Int32.Parse(Request.Form["soluong"]);
            }

            int objnam = 0;
            if (Request.Form["nam"] != "")
            {
                objnam= Int32.Parse(Request.Form["nam"]);
            }

            int objkm = 0;
            if (Request.Form["km"] != "")
            {
                objkm= Int32.Parse(Request.Form["km"]);
            }
            List<Parameter> lipa = new List<Parameter>();
            if (objtensp != "" && objtensp != null)
            {
                lipa.Add(new Parameter("TENSP", SqlDbType.VarChar, objtensp, 1));
            }
            if (objmansx != "" && objmansx!=null)
            {
                lipa.Add(new Parameter("MANSX", SqlDbType.VarChar,objmansx, 1));
            }
            if (objmausac != "" && objmausac!=null)
            {
                lipa.Add(new Parameter("MAUSAC", SqlDbType.VarChar,objmausac, 1));
            }
            if (objmaloai != "" && objmaloai != null)
            {
                lipa.Add(new Parameter("MALOAI", SqlDbType.VarChar, objmaloai, 1));
            }
            if (objmota != "" && objmota != null)
            {
                lipa.Add(new Parameter("MOTA", SqlDbType.VarChar, objmota, 1));
            }
            if (objdongia != 0)
            {
                lipa.Add(new Parameter("DONGIA", SqlDbType.Float, objdongia, 1));
            }
            if (objsoluong != 0)
            {
                lipa.Add(new Parameter("SOLUONG", SqlDbType.Int, objsoluong, 1));
            }
            if (objnam != 0)
            {
                lipa.Add(new Parameter("YEAR", SqlDbType.Int, objnam, 1));
            }
            if (objkm != 0)
            {
                lipa.Add(new Parameter("KM", SqlDbType.Int, objkm, 1));
            }
            //List<SANPHAM> li = null;
            //li = getAll(lipa.ToArray());
            //query = "select * from sanpham where MASP='101011'";
            query = getAll(lipa.ToArray());
            checksearch = 1;
            return RedirectToAction("Index");
        }


        public string getAll(params Parameter[] listFilter)
        {
            List<SANPHAM> lidata = new List<SANPHAM>();
            string sql = "SELECT * FROM sanpham";
            string swhere = "";
            SqlCommand cm = new SqlCommand();
            foreach (var item in listFilter)
            {
                if (swhere != "")
                {
                    swhere += " AND ";
                }
                if (item.data == null)
                {
                    //cm.Parameters.Add("@" + f.Name, st);
                    //cm.Parameters["@" + f.Name].Value = DBNull.Value;
                    swhere += "[" + item.name + "]" + " is null";
                }
                else
                {
                    if (item.searchtype == 0)
                    {
                        swhere += "[" + item.name + "]= @" + item.name;
                        cm.Parameters.Add(new SqlParameter("@" + item.name, item.data));
                    }
                    else
                    {
                        swhere += "[" + item.name + "] LIKE N'%" + item.data+"%'";
                        //cm.Parameters.Add(new SqlParameter("@" + item.name, "%" + item.data + "%"));
                    }
                }
            }
            if (swhere != "")
            {
                sql += " WHERE " + swhere;
            }
            return sql;
            //cm.CommandText = sql;
            //cm.CommandType = CommandType.Text;
           // DataSet ds = new DataSet();
            //int ret = db.getCommand(ref ds, "Tmp", cm);
            //if (ret < 0)
            //{
            //    return null;
            //}
            //else
            //{
            //    foreach (DataRow dr in ds.Tables["Tmp"].Rows)
            //    {
            //        SANPHAM obj = new SANPHAM();

            //        Type myTableObject = typeof(SANPHAM);
            //        System.Reflection.PropertyInfo[] selectFieldInfo = myTableObject.GetProperties();

            //        Type myObjectType = typeof(SANPHAM.BusinessObjectID);
            //        System.Reflection.PropertyInfo[] fieldInfo = myObjectType.GetProperties();

            //        //set object value
            //        foreach (System.Reflection.PropertyInfo info in selectFieldInfo)
            //        {
            //            if (info.Name != "_ID")
            //            {
            //                if (dr.Table.Columns.Contains(info.Name))
            //                {
            //                    if (!dr.IsNull(info.Name))
            //                    {
            //                        info.SetValue(obj, dr[info.Name], null);
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                //set id value
            //                SANPHAM.BusinessObjectID objid;
            //                objid = (SANPHAM.BusinessObjectID)info.GetValue(obj, null);
            //                foreach (System.Reflection.PropertyInfo info1 in fieldInfo)
            //                {
            //                    if (dr.Table.Columns.Contains(info1.Name))
            //                    {
            //                        info1.SetValue(objid, dr[info1.Name], null);
            //                    }
            //                }
            //                info.SetValue(obj, objid, null);
            //            }
            //        }
            //        lidata.Add(obj);
            //    }
            //}
           // return lidata;
        }
    }
}