
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web.Mvc;
using productoMVC.Models;
using WebMVCEntraDatos.Models; // 

namespace productoMVC.Controllers
{
    public class ContraReciboController : Controller
    {
        private ControlPagosEntities db = new ControlPagosEntities();

        
        public ActionResult Index()
        {
            string query = "SELECT * FROM ContraRecibo";
            DataTable dt = db.SelectQuery(query);

            List<ContraRecibo> contraRecibos = new List<ContraRecibo>();
            foreach (DataRow row in dt.Rows)
            {
                ContraRecibo contraRecibo = new ContraRecibo();
                contraRecibo.IdContrarecibo = Convert.ToInt32(row["IdContrarecibo"]);
                contraRecibo.Fecha = Convert.ToDateTime(row["Fecha"]);
                contraRecibo.Obra = row["Obra"].ToString();
                contraRecibo.Extra = row["Extra"].ToString();
                contraRecibos.Add(contraRecibo);
            }

            return View(contraRecibos);
        }

        // GET: ContraRecibo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContraRecibo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContraRecibo contraRecibo)
        {
            if (ModelState.IsValid)
            {
                string query = $"INSERT INTO ContraRecibo (Fecha, Obra, Extra) VALUES ('{contraRecibo.Fecha.ToString("yyyy-MM-dd HH:mm:ss")}', '{contraRecibo.Obra}', '{contraRecibo.Extra}')";
                db.ExecuteQuery(query);
                return RedirectToAction("Index");
            }
            return View(contraRecibo);
        }

        // GET: ContraRecibo/Edit/5
        public ActionResult Edit(int?id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            string query = $"SELECT * FROM ContraRecibo WHERE IdContrarecibo = {id}";
            DataTable dt = db.SelectQuery(query);

            if (dt.Rows.Count == 0)
            {
                return HttpNotFound();
            }

            DataRow row = dt.Rows[0];
            ContraRecibo contraRecibo = new ContraRecibo();
            contraRecibo.IdContrarecibo = Convert.ToInt32(row["IdContrarecibo"]);
            contraRecibo.Fecha = Convert.ToDateTime(row["Fecha"]);
            contraRecibo.Obra = row["Obra"].ToString();
            contraRecibo.Extra = row["Extra"].ToString();

            return View(contraRecibo);
        }

        // POST: ContraRecibo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContraRecibo contraRecibo)
        {
            if (ModelState.IsValid)
            {
                string query = $"UPDATE ContraRecibo SET Fecha = '{contraRecibo.Fecha.ToString("yyyy-MM-dd HH:mm:ss")}', Obra = '{contraRecibo.Obra}', Extra = '{contraRecibo.Extra}' WHERE IdContrarecibo = {contraRecibo.IdContrarecibo}";
                db.ExecuteQuery(query);
                return RedirectToAction("Index");
            }
            return View(contraRecibo);
        }

        // GET: ContraRecibo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            string query = $"SELECT * FROM ContraRecibo WHERE IdContrarecibo = {id}";
            DataTable dt = db.SelectQuery(query);

            if (dt.Rows.Count == 0)
            {
                return HttpNotFound();
            }

            DataRow row = dt.Rows[0];
            ContraRecibo contraRecibo = new ContraRecibo();
            contraRecibo.IdContrarecibo = Convert.ToInt32(row["IdContrarecibo"]);
            contraRecibo.Fecha = Convert.ToDateTime(row["Fecha"]);
            contraRecibo.Obra = row["Obra"].ToString();
            contraRecibo.Extra = row["Extra"].ToString();

            return View(contraRecibo);
        }

        // POST: ContraRecibo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string query = $"DELETE FROM ContraRecibo WHERE IdContrarecibo = {id}";
            db.ExecuteQuery(query);
            return RedirectToAction("Index");
        }
    }
}
