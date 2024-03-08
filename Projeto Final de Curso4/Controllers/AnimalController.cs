using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Projeto_Final_de_Curso4.Models;

namespace Projeto_Final_de_Curso4.Controllers
{
    public class AnimalController : Controller
    {
        private Model1 db = new Model1();

        // GET: Animal
        public ActionResult Index()
        {
            var tb_animal = db.tb_animal.Include(t => t.tb_cor).Include(t => t.tb_disponibilidade_do_animal).Include(t => t.tb_genero).Include(t => t.tb_tipo_de_animal);
            return View(tb_animal.ToList());
        }

        // GET: Animal Cliente
        public ActionResult IndexCliente()
        {

            var tb_animal = db.tb_animal.Include(t => t.tb_cor).Include(t => t.tb_disponibilidade_do_animal).Include(t => t.tb_genero).Include(t => t.tb_tipo_de_animal)
                .Where(t => t.id_disponibilidade_do_animal == 2 );
            return View(tb_animal.ToList());
        }

        // GET: Animal/Details/5
        public ActionResult Details(int? id)
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
            return View(tb_animal);
        }

        // GET: Animal/Create
        public ActionResult Create()
        {
            ViewBag.id_cor = new SelectList(db.tb_cor, "id_cor", "cor");
            ViewBag.id_disponibilidade_do_animal = new SelectList(db.tb_disponibilidade_do_animal, "id_disponibilidade_do_animal", "disponibilidade_do_animal");
            ViewBag.id_genero = new SelectList(db.tb_genero, "id_genero", "genero");
            ViewBag.id_tipo_de_animal = new SelectList(db.tb_tipo_de_animal, "id_tipo_de_animal", "tipo_de_animal");
            return View();
        }

        // POST: Animal/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_animal,nome,id_cor,id_genero,id_tipo_de_animal,id_disponibilidade_do_animal,idade,raca,peso,foto")] tb_animal tb_animal, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    tb_animal.foto = ImageFile.FileName;
                    String path = Server.MapPath("~/Foto/" + ImageFile.FileName);
                    ImageFile.SaveAs(path);
                }
                tb_animal.id_disponibilidade_do_animal = 2; //Nao adoptado
                db.tb_animal.Add(tb_animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cor = new SelectList(db.tb_cor, "id_cor", "cor", tb_animal.id_cor);
            ViewBag.id_disponibilidade_do_animal = new SelectList(db.tb_disponibilidade_do_animal, "id_disponibilidade_do_animal", "disponibilidade_do_animal", tb_animal.id_disponibilidade_do_animal);
            ViewBag.id_genero = new SelectList(db.tb_genero, "id_genero", "genero", tb_animal.id_genero);
            ViewBag.id_tipo_de_animal = new SelectList(db.tb_tipo_de_animal, "id_tipo_de_animal", "tipo_de_animal", tb_animal.id_tipo_de_animal);
            return View(tb_animal);
        }

        // GET: Animal/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.id_cor = new SelectList(db.tb_cor, "id_cor", "cor", tb_animal.id_cor);
            ViewBag.id_disponibilidade_do_animal = new SelectList(db.tb_disponibilidade_do_animal, "id_disponibilidade_do_animal", "disponibilidade_do_animal", tb_animal.id_disponibilidade_do_animal);
            ViewBag.id_genero = new SelectList(db.tb_genero, "id_genero", "genero", tb_animal.id_genero);
            ViewBag.id_tipo_de_animal = new SelectList(db.tb_tipo_de_animal, "id_tipo_de_animal", "tipo_de_animal", tb_animal.id_tipo_de_animal);
            return View(tb_animal);
        }

        // POST: Animal/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_animal,nome,id_cor,id_genero,id_tipo_de_animal,id_disponibilidade_do_animal,idade,raca,peso,foto")] tb_animal tb_animal, HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null)
                {
                    tb_animal.foto = ImageFile.FileName;
                    String path = Server.MapPath("~/Foto/" + ImageFile.FileName);
                    ImageFile.SaveAs(path);
                }
                db.Entry(tb_animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cor = new SelectList(db.tb_cor, "id_cor", "cor", tb_animal.id_cor);
            ViewBag.id_disponibilidade_do_animal = new SelectList(db.tb_disponibilidade_do_animal, "id_disponibilidade_do_animal", "disponibilidade_do_animal", tb_animal.id_disponibilidade_do_animal);
            ViewBag.id_genero = new SelectList(db.tb_genero, "id_genero", "genero", tb_animal.id_genero);
            ViewBag.id_tipo_de_animal = new SelectList(db.tb_tipo_de_animal, "id_tipo_de_animal", "tipo_de_animal", tb_animal.id_tipo_de_animal);
            return View(tb_animal);
        }

        // GET: Animal/Delete/5
        public ActionResult Delete(int? id)
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
            return View(tb_animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_animal tb_animal = db.tb_animal.Find(id);
            db.tb_animal.Remove(tb_animal);
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
