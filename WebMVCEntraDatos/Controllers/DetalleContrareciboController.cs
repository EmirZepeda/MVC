using productoMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCEntraDatos.Models;

namespace WebMVCEntraDatos.Controllers
{
    public class DetalleContrareciboController : Controller
    {
        private ControlPagosEntities db = new ControlPagosEntities();

        // GET: DetalleContrarecibo
        public ActionResult Index()
        {
            string query = "SELECT * FROM DetalleContrarecibo";
            DataTable dt = db.SelectQuery(query);

            List<DetalleContrarecibo> detalles = new List<DetalleContrarecibo>();
            foreach (DataRow row in dt.Rows)
            {
                DetalleContrarecibo detalle = new DetalleContrarecibo();
                detalle.IdDetalleContrar = Convert.ToInt32(row["iddetallecontrar"]);
                detalle.ContraReciboId = Convert.ToInt32(row["contrarecibo"]);
                detalle.NotaCompraId = Convert.ToInt32(row["nota"]);
                detalle.Total = Convert.ToSingle(row["total"]);
                detalle.Pagada = Convert.ToBoolean(row["pagada"]);
                detalle.Extra = row["Extra"].ToString();
                detalles.Add(detalle);
            }

            return View(detalles);
        }

        // GET: DetalleContrarecibo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalleContrarecibo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DetalleContrarecibo detalle)
        {
            if (ModelState.IsValid)
            {
                string query = $"INSERT INTO DetalleContrarecibo (contrarecibo, nota, total, pagada, Extra) VALUES ({detalle.ContraReciboId}, {detalle.NotaCompraId}, {detalle.Total}, {detalle.Pagada}, '{detalle.Extra}')";
                db.ExecuteQuery(query);
                return RedirectToAction("Index");
            }
            return View(detalle);
        }

        // GET: DetalleContrarecibo/Edit/5
        public ActionResult Edit(int id)
        {
            string query = $"SELECT * FROM DetalleContrarecibo WHERE iddetallecontrar = {id}";
            DataTable dt = db.SelectQuery(query);

            if (dt.Rows.Count == 0)
            {
                return HttpNotFound();
            }

            DataRow row = dt.Rows[0];
            DetalleContrarecibo detalle = new DetalleContrarecibo();
            detalle.IdDetalleContrar = Convert.ToInt32(row["iddetallecontrar"]);
            detalle.ContraReciboId = Convert.ToInt32(row["contrarecibo"]);
            detalle.NotaCompraId = Convert.ToInt32(row["nota"]);
            detalle.Total = Convert.ToSingle(row["total"]);
            detalle.Pagada = Convert.ToBoolean(row["pagada"]);
            detalle.Extra = row["Extra"].ToString();

            return View(detalle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DetalleContrarecibo detalle)
        {
            if (ModelState.IsValid)
            {
                string query = $"UPDATE DetalleContrarecibo SET total = {detalle.Total}, pagada = {detalle.Pagada}, Extra = '{detalle.Extra}' WHERE iddetallecontrar = {detalle.IdDetalleContrar}";
                db.ExecuteQuery(query);
                return RedirectToAction("Index");
            }
            return View(detalle);
        }


        // GET: DetalleContrarecibo/Delete/5
        public ActionResult Delete(int id)
        {
            string query = $"SELECT * FROM DetalleContrarecibo WHERE iddetallecontrar = {id}";
            DataTable dt = db.SelectQuery(query);

            if (dt.Rows.Count == 0)
            {
                return HttpNotFound();
            }

            DataRow row = dt.Rows[0];
            DetalleContrarecibo detalle = new DetalleContrarecibo();
            detalle.IdDetalleContrar = Convert.ToInt32(row["iddetallecontrar"]);
            detalle.ContraReciboId = Convert.ToInt32(row["contrarecibo"]);
            detalle.NotaCompraId = Convert.ToInt32(row["nota"]);
            detalle.Total = Convert.ToSingle(row["total"]);
            detalle.Pagada = Convert.ToBoolean(row["pagada"]);
            detalle.Extra = row["Extra"].ToString();

            return View(detalle);
        }

        // POST: DetalleContrarecibo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string query = $"DELETE FROM DetalleContrarecibo WHERE iddetallecontrar = {id}";
            db.ExecuteQuery(query);
            return RedirectToAction("Index");
        }
    }
}
