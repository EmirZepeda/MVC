using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web.Mvc;
using productoMVC.Models;
using WebMVCEntraDatos.Models;
using static WebMVCEntraDatos.Models.CategoriaMaterial;

namespace WebMVCEntraDatos.Controllers
{
    public class CategoriaMaterialController : Controller
    {
        private ControlPagosEntities db = new ControlPagosEntities();

        // GET: CategoriaMaterial/Index
        public ActionResult Index()
        {
            string query = "SELECT * FROM CategoriaMaterial";
            DataTable dt = db.SelectQuery(query);

            List<CategoriaMaterial> categorias = new List<CategoriaMaterial>();
            foreach (DataRow row in dt.Rows)
            {
                CategoriaMaterial categoria = new CategoriaMaterial();
                categoria.Idcategoria = Convert.ToInt32(row["Idcategoria"]);
                categoria.NomCategoria = row["NomCategoria"].ToString();
                categoria.Extra = row["Extra"].ToString();
                categorias.Add(categoria);
            }

            return View(categorias);
        }

        // GET: CategoriaMaterial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriaMaterial/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaMaterial categoria)
        {
            if (ModelState.IsValid)
            {
                string query = $"INSERT INTO CategoriaMaterial (NomCategoria, Extra) VALUES ('{categoria.NomCategoria}', '{categoria.Extra}')";
                 db.ExecuteQuery(query);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: CategoriaMaterial/Edit/5
        public ActionResult Edit(int id)
        {
            string query = $"SELECT * FROM CategoriaMaterial WHERE Idcategoria = {id}";
                   DataTable dt = db.SelectQuery(query);

            if (dt.Rows.Count == 0)
            {
                return HttpNotFound();
            }

            DataRow row = dt.Rows[0];
            CategoriaMaterial categoria = new CategoriaMaterial();
                      categoria.Idcategoria = Convert.ToInt32(row["Idcategoria"]);
                   categoria.NomCategoria = row["NomCategoria"].ToString();
            categoria.Extra = row["Extra"].ToString();

            return View(categoria);
        }

        // POST: CategoriaMaterial/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaMaterial categoria)
        {
            if (ModelState.IsValid)
            {
                string query = $"UPDATE CategoriaMaterial SET NomCategoria = '{categoria.NomCategoria}', Extra = '{categoria.Extra}' WHERE Idcategoria = {categoria.Idcategoria}";
                db.ExecuteQuery(query);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: CategoriaMaterial/Delete/5
        public ActionResult Delete(int id)
        {
            string query = $"SELECT * FROM CategoriaMaterial WHERE Idcategoria = {id}";
            DataTable dt = db.SelectQuery(query);

            if (dt.Rows.Count == 0)
            {
                return HttpNotFound();
            }

            DataRow row = dt.Rows[0];
                                  CategoriaMaterial categoria = new CategoriaMaterial();
            categoria.Idcategoria = Convert.ToInt32(row["Idcategoria"]);
                       categoria.NomCategoria = row["NomCategoria"].ToString();
            categoria.Extra = row["Extra"].ToString();

            return View(categoria);
        }

        // POST: CategoriaMaterial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string query = $"DELETE FROM CategoriaMaterial WHERE Idcategoria = {id}";
            db.ExecuteQuery(query);
            return RedirectToAction("Index");
        }
    }
}
