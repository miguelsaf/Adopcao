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
    public class AdopcaoController : Controller
    {
        private Model1 db = new Model1();

        // GET: Adopcao
        public ActionResult Index()
        {
            var tb_adopcao = db.tb_adopcao.Include(t => t.tb_estado_da_adopcao);
            return View(tb_adopcao.ToList());
        }

        // GET: Adopcao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_adopcao tb_adopcao = db.tb_adopcao.Find(id);
            if (tb_adopcao == null)
            {
                return HttpNotFound();
            }
            return View(tb_adopcao);
        }

        // GET: Adopcao/Create
        public ActionResult Create()
        {
            ViewBag.id_estado_da_adopcao = new SelectList(db.tb_estado_da_adopcao, "id_estado_da_adopcao", "estado_da_adopcao");
            return View();
        }

        // POST: Adopcao/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_adopcao,id_cliente,id_funcionario,id_estado_da_adopcao,data_de_entrega,data_de_solicitacao_do_animal")] tb_adopcao tb_adopcao)
        {
            if (ModelState.IsValid)
            {
                db.tb_adopcao.Add(tb_adopcao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_estado_da_adopcao = new SelectList(db.tb_estado_da_adopcao, "id_estado_da_adopcao", "estado_da_adopcao", tb_adopcao.id_estado_da_adopcao);
            return View(tb_adopcao);
        }

        // GET: Adopcao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_adopcao tb_adopcao = db.tb_adopcao.Find(id);
            if (tb_adopcao == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_estado_da_adopcao = new SelectList(db.tb_estado_da_adopcao, "id_estado_da_adopcao", "estado_da_adopcao", tb_adopcao.id_estado_da_adopcao);
            return View(tb_adopcao);
        }

        // POST: Adopcao/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_adopcao,id_cliente,id_funcionario,id_estado_da_adopcao,data_de_entrega,data_de_solicitacao_do_animal")] tb_adopcao tb_adopcao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_adopcao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_estado_da_adopcao = new SelectList(db.tb_estado_da_adopcao, "id_estado_da_adopcao", "estado_da_adopcao", tb_adopcao.id_estado_da_adopcao);
            return View(tb_adopcao);
        }

        // GET: Adopcao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_adopcao tb_adopcao = db.tb_adopcao.Find(id);
            if (tb_adopcao == null)
            {
                return HttpNotFound();
            }
            return View(tb_adopcao);
        }

        // POST: Adopcao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_adopcao tb_adopcao = db.tb_adopcao.Find(id);
            db.tb_adopcao.Remove(tb_adopcao);
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
