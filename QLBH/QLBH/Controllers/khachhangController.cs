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
    public class khachhangController : Controller
    {
        QLBHDBContext db = new QLBHDBContext();

        public ActionResult IndexKH()
        {
            ViewBag.kh = db.khachhangs;
            return View();
        }

        [HttpGet]
        public ActionResult themKH()
        {
            return View();
        }

        [HttpPost]
        public ActionResult themKH(khachhang k)
        {
            db.khachhangs.Add(k);
            db.SaveChanges();
            return RedirectToAction("IndexKH");
        }

        [HttpGet]
        public ActionResult suaKH(string id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            khachhang kh = db.khachhangs.Find(id);
            if (kh == null)
                return HttpNotFound();
            ViewBag.kh = kh;
            return View(kh);
        }
        [HttpPost]
        public ActionResult suaKH()
        {
            string ma = Request["makh"].ToString();
            khachhang kh = db.khachhangs.Find(ma);
            if (kh == null)
                return HttpNotFound();
            kh.makh = ma;
            kh.tenkh = Request["tenkh"].ToString();
            kh.namsinh = System.Convert.ToInt32(Request["namsinh"].ToString());
            kh.phai = Convert.ToBoolean(Request["phai"]);
            kh.diachi = Request["diachi"].ToString();
            kh.password = Request["password"].ToString();
            db.Entry(kh).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("IndexKH");
        }

        public ActionResult xoaNSX(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nhasanxuat n = db.nhasanxuats.Find(id);
            if (n == null)
            {
                return HttpNotFound();
            }
            ViewBag.nsx = n;
            return View(n);
        }
        [HttpPost, ActionName("xoaNSX")]
        public ActionResult xoaNSX_Post(string id)
        {
            nhasanxuat n = db.nhasanxuats.Find(id);
            db.nhasanxuats.Remove(n);
            db.SaveChanges();
            return RedirectToAction("IndexNSX");
        }
    }
}