using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Projeto_Final_de_Curso4.Models;

namespace Projeto_Final_de_Curso4.Controllers
{
    public class AdopcaoController : Controller
    {
        private Model1 db = new Model1();

       
        // GET: Adopcao
        public ActionResult IndexCliente(int? id)
        {
            if (id != null)
            {
                tb_adopcao tb_adopcaoRemove = db.tb_adopcao.Find(id);
                tb_adopcaoRemove.tb_animal.id_disponibilidade_do_animal = 2;
                db.tb_animal.Add(tb_adopcaoRemove.tb_animal);
                db.tb_adopcao.Remove(tb_adopcaoRemove);
                db.SaveChanges();  
            }
            string id_cliente = User.Identity.GetUserId();
            var tb_adopcao = db.tb_adopcao.Include(t => t.tb_animal).Include(t => t.tb_estado_da_adopcao)
                .Where(t => t.id_cliente.Equals(id_cliente));
            return View(tb_adopcao.ToList());

        }

        // GET: Adopcao
        public ActionResult Index()
        {
            var tb_adopcao = db.tb_adopcao.Include(t => t.tb_animal).Include(t => t.tb_estado_da_adopcao);
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
            ViewBag.id_animal = new SelectList(db.tb_animal, "id_animal", "id_animal");
            ViewBag.id_estado_da_adopcao = new SelectList(db.tb_estado_da_adopcao, "id_estado_da_adopcao", "estado_da_adopcao");
            return View();
        }

        // GET: Adopcao/CreateCliente

        public ActionResult CreateCliente(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_animal tb_animal = db.tb_animal.Find(id);
            if (tb_animal == null)
            {
                return HttpNotFound();
            }
            tb_adopcao tb_adopcao = new tb_adopcao();
            if (tb_adopcao == null)
            {
                return HttpNotFound();
            }

            tb_adopcao.tb_animal = tb_animal;
            tb_adopcao.id_animal = tb_animal.id_animal;
            tb_adopcao.data_de_solicitacao_do_animal = DateTime.Now.ToString();
            tb_adopcao.id_cliente = User.Identity.GetUserId();
            tb_adopcao.id_estado_da_adopcao = 3;


            return View(tb_adopcao);
        }


        // POST: Adopcao/CreateCliente
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCliente([Bind(Include = "id_adopcao,id_cliente,id_funcionario,id_animal,id_estado_da_adopcao,data_de_entrega,data_de_solicitacao_do_animal,motivo_da_adopcao")] tb_adopcao tb_adopcao)
        {
            if (ModelState.IsValid)
            {
                tb_animal tb_animal = db.tb_animal.Find(tb_adopcao.id_animal);
                tb_animal.id_disponibilidade_do_animal = 1;//Adotado
                db.tb_animal.Add(tb_animal);
                db.tb_adopcao.Add(tb_adopcao);
                db.SaveChanges();
                return RedirectToAction("IndexCliente");
            }

            ViewBag.id_animal = new SelectList(db.tb_animal, "id_animal", "idade", tb_adopcao.id_animal);
            ViewBag.id_estado_da_adopcao = new SelectList(db.tb_estado_da_adopcao, "id_estado_da_adopcao", "estado_da_adopcao", tb_adopcao.id_estado_da_adopcao);
            return View(tb_adopcao);
        }

        // POST: Adopcao/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_adopcao,id_cliente,id_funcionario,id_animal,id_estado_da_adopcao,data_de_entrega,data_de_solicitacao_do_animal,motivo_da_adopcao")] tb_adopcao tb_adopcao)
        {
            if (ModelState.IsValid)
            {
                db.tb_adopcao.Add(tb_adopcao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_animal = new SelectList(db.tb_animal, "id_animal", "idade", tb_adopcao.id_animal);
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
            ViewBag.id_animal = new SelectList(db.tb_animal, "id_animal", "idade", tb_adopcao.id_animal);
            ViewBag.id_estado_da_adopcao = new SelectList(db.tb_estado_da_adopcao, "id_estado_da_adopcao", "estado_da_adopcao", tb_adopcao.id_estado_da_adopcao);
            return View(tb_adopcao);
        }

        // POST: Adopcao/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_adopcao,id_cliente,id_funcionario,id_animal,id_estado_da_adopcao,data_de_entrega,data_de_solicitacao_do_animal")] tb_adopcao tb_adopcao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_adopcao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_animal = new SelectList(db.tb_animal, "id_animal", "idade", tb_adopcao.id_animal);
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
