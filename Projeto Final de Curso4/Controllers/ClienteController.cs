using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projeto_Final_de_Curso4.Models;

namespace Projeto_Final_de_Curso4.Controllers
{
    public class ClienteController : Controller
    {
        private Model1 db = new Model1();

        // GET: Cliente
        public ActionResult Index()
        {
            var tb_cliente = db.tb_cliente.Include(t => t.tb_genero).Include(t => t.tb_municipio);
            return View(tb_cliente.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_cliente tb_cliente = db.tb_cliente.Find(id);
            if (tb_cliente == null)
            {
                return HttpNotFound();
            }
            return View(tb_cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.id_genero = new SelectList(db.tb_genero, "id_genero", "genero");
            ViewBag.id_municipio = new SelectList(db.tb_municipio, "id_municipio", "municipio");
            return View();
        }

        // POST: Cliente/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,id_genero,bairro,rua_casa,contacto,n_BI,id_municipio,ocupacao,data_de_nascimento")] tb_cliente tb_cliente)
        {
            if (ModelState.IsValid)
            {
                db.tb_cliente.Add(tb_cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_genero = new SelectList(db.tb_genero, "id_genero", "genero", tb_cliente.id_genero);
            ViewBag.id_municipio = new SelectList(db.tb_municipio, "id_municipio", "municipio", tb_cliente.id_municipio);
            return View(tb_cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_cliente tb_cliente = db.tb_cliente.Find(id);
            if (tb_cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_genero = new SelectList(db.tb_genero, "id_genero", "genero", tb_cliente.id_genero);
            ViewBag.id_municipio = new SelectList(db.tb_municipio, "id_municipio", "municipio", tb_cliente.id_municipio);
            return View(tb_cliente);
        }

        // POST: Cliente/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,id_genero,bairro,rua_casa,contacto,n_BI,id_municipio,ocupacao,data_de_nascimento")] tb_cliente tb_cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_genero = new SelectList(db.tb_genero, "id_genero", "genero", tb_cliente.id_genero);
            ViewBag.id_municipio = new SelectList(db.tb_municipio, "id_municipio", "municipio", tb_cliente.id_municipio);
            return View(tb_cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_cliente tb_cliente = db.tb_cliente.Find(id);
            if (tb_cliente == null)
            {
                return HttpNotFound();
            }
            return View(tb_cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tb_cliente tb_cliente = db.tb_cliente.Find(id);
            db.tb_cliente.Remove(tb_cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
