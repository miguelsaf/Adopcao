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
    public class FuncionarioController : Controller
    {
        private Model1 db = new Model1();

        // GET: Funcionario
        public ActionResult Index()
        {
            var tb_funcionario = db.tb_funcionario.Include(t => t.tb_genero).Include(t => t.tb_municipio);
            return View(tb_funcionario.ToList());
        }

        // GET: Funcionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_funcionario tb_funcionario = db.tb_funcionario.Find(id);
            if (tb_funcionario == null)
            {
                return HttpNotFound();
            }
            return View(tb_funcionario);
        }

        // GET: Funcionario/Create
        public ActionResult Create()
        {
            ViewBag.id_genero = new SelectList(db.tb_genero, "id_genero", "genero");
            ViewBag.id_municipio = new SelectList(db.tb_municipio, "id_municipio", "municipio");
            return View();
        }

        // POST: Funcionario/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_funcionario,Nome,id_genero,bairro,rua_casa,contacto,n_BI,id_municipio,id_usuario")] tb_funcionario tb_funcionario)
        {
            if (ModelState.IsValid)
            {
                db.tb_funcionario.Add(tb_funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_genero = new SelectList(db.tb_genero, "id_genero", "genero", tb_funcionario.id_genero);
            ViewBag.id_municipio = new SelectList(db.tb_municipio, "id_municipio", "municipio", tb_funcionario.id_municipio);
            return View(tb_funcionario);
        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_funcionario tb_funcionario = db.tb_funcionario.Find(id);
            if (tb_funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_genero = new SelectList(db.tb_genero, "id_genero", "genero", tb_funcionario.id_genero);
            ViewBag.id_municipio = new SelectList(db.tb_municipio, "id_municipio", "municipio", tb_funcionario.id_municipio);
            return View(tb_funcionario);
        }

        // POST: Funcionario/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_funcionario,Nome,id_genero,bairro,rua_casa,contacto,n_BI,id_municipio,id_usuario")] tb_funcionario tb_funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_genero = new SelectList(db.tb_genero, "id_genero", "genero", tb_funcionario.id_genero);
            ViewBag.id_municipio = new SelectList(db.tb_municipio, "id_municipio", "municipio", tb_funcionario.id_municipio);
            return View(tb_funcionario);
        }

        // GET: Funcionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_funcionario tb_funcionario = db.tb_funcionario.Find(id);
            if (tb_funcionario == null)
            {
                return HttpNotFound();
            }
            return View(tb_funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_funcionario tb_funcionario = db.tb_funcionario.Find(id);
            db.tb_funcionario.Remove(tb_funcionario);
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
