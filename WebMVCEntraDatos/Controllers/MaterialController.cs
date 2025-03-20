using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web;
using System.Web.Mvc;
using productoMVC.Models;
using WebMVCEntraDatos.Models;

namespace productoMVC.Controllers
{
    public class MaterialController : Controller
    {
        // Instancia de la clase ControlPagosEntities para interactuar con la base de datos
        private ControlPagosEntities db = new ControlPagosEntities();

        // GET: Material/Index
        public ActionResult Index()
        {
            string query = "SELECT * FROM Material";
            DataTable dt = db.SelectQuery(query);

            List<Material> materiales = new List<Material>();
            foreach (DataRow row in dt.Rows)
            {
                Material material = new Material();
                   material.Idmaterial = Convert.ToInt32(row["Idmaterial"]);
                material.NombreMat = row["NombreMat"].ToString();
                   material.Marca = row["Marca"].ToString();
                     material.Categoria = Convert.ToInt32(row["Categoria"]);
                material.UnidadMedida = row["UnidadMedida"].ToString();
                   materiales.Add(material);
            }

                return View(materiales);
        }

        // GET: Material/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Material/Create
        [HttpPost]
              [ValidateAntiForgeryToken]
        public ActionResult Create(Material material)
        {
            if (ModelState.IsValid)
            {
                     string query = $"INSERT INTO Material (NombreMat, Marca, Categoria, UnidadMedida) VALUES ('{material.NombreMat}', '{material.Marca}', {material.Categoria}, '{material.UnidadMedida}')";
                db.ExecuteQuery(query);
                        return RedirectToAction("Index");
            }
            return View(material);
        }

        // GET: Material/Edit/5
        public ActionResult Edit(int? id)
        {
               if (id == null)
               {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

                string query = $"SELECT * FROM Material WHERE Idmaterial = {id}";
              DataTable dt = db.SelectQuery(query);

            if (dt.Rows.Count == 0)
            {
                return HttpNotFound();
            }

            DataRow row = dt.Rows[0];
            Material material = new Material();
            material.Idmaterial = Convert.ToInt32(row["Idmaterial"]);
            material.NombreMat = row["NombreMat"].ToString();
            material.Marca = row["Marca"].ToString();
            material.Categoria = Convert.ToInt32(row["Categoria"]);
            material.UnidadMedida = row["UnidadMedida"].ToString();

            return View(material);
        }

        // POST: Material/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Material material)
        {
            if (ModelState.IsValid)
            {
                string query = $"UPDATE Material SET NombreMat = '{material.NombreMat}', Marca = '{material.Marca}', Categoria = {material.Categoria}, UnidadMedida = '{material.UnidadMedida}' WHERE Idmaterial = {material.Idmaterial}";
                db.ExecuteQuery(query);
                return RedirectToAction("Index");
            }
            return View(material);
        }

        // GET: Material/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            string query = $"SELECT * FROM Material WHERE Idmaterial = {id}";
            DataTable dt = db.SelectQuery(query);

            if (dt.Rows.Count == 0)
            {
                return HttpNotFound();
            }

            DataRow row = dt.Rows[0];
            Material material = new Material();
            material.Idmaterial = Convert.ToInt32(row["Idmaterial"]);
            material.NombreMat = row["NombreMat"].ToString();
            material.Marca = row["Marca"].ToString();
            material.Categoria = Convert.ToInt32(row["Categoria"]);
            material.UnidadMedida = row["UnidadMedida"].ToString();

            return View(material);
        }

        // POST: Material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            string query = $"DELETE FROM Material WHERE Idmaterial = {id}";
            db.ExecuteQuery(query);
            return RedirectToAction("Index");
        }
    }
}
