using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using QLBH.Models;
using System.Data;
using System.Data.Entity;

namespace QLBH.Controllers
{
    public class nhanvienController : Controller
    {
        QLBHDBContext db = new QLBHDBContext();
        // GET: nhanvien
        public ActionResult IndexNV()
        {
            ViewBag.nv = db.nhanviens;
            return View();
        }

        [HttpGet]
        public ActionResult themNV()
        {
            return View();
        }

        [HttpPost]
        public ActionResult themNV(nhanvien nv)
        {
            db.nhanviens.Add(nv);
            db.SaveChanges();
            return RedirectToAction("IndexNV");
        }

        [HttpGet]
        public ActionResult suaNV(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            nhanvien nv = db.nhanviens.Find(id);
            if (nv == null)
                return HttpNotFound();
            ViewBag.nv = nv;
            return View(nv);
        }
        [HttpPost]
        public ActionResult suaNV()
        {
            string ma = Request["manv"].ToString();
            nhanvien nv = db.nhanviens.Find(ma);
            if (nv == null)
                return HttpNotFound();
            nv.manv = ma;
            nv.tennv = Request["tennv"].ToString();
            nv.ngaysinh = Convert.ToDateTime(Request["ngaysinh"]);
            nv.phai = Convert.ToBoolean(Request["phai"]);
            nv.diachi = Request["diachi"].ToString();
            nv.password = Request["password"].ToString();
            db.Entry(nv).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("IndexNV");
        }

        public ActionResult xoaNV(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nhanvien n = db.nhanviens.Find(id);
            if (n == null)
            {
                return HttpNotFound();
            }
            ViewBag.nv = n;
            return View(n);
        }
        [HttpPost, ActionName("xoaNV")]
        public ActionResult xoaNV_Post(string id)
        {
            nhanvien n = db.nhanviens.Find(id);
            db.nhanviens.Remove(n);
            db.SaveChanges();
            return RedirectToAction("IndexNV");
        }
    }
}