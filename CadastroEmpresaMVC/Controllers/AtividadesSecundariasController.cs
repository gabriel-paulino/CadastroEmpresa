using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CadastroEmpresaMVC.DAL;
using CadastroEmpresaMVC.Models;

namespace CadastroEmpresaMVC.Controllers
{
    public class AtividadesSecundariasController : Controller
    {
        private Context db = new Context();

        // GET: AtividadesSecundarias
        public ActionResult Index()
        {
            var atividadesSecundarias = db.AtividadesSecundarias.Include(a => a.Empresa);
            return View(atividadesSecundarias.ToList());
        }

        // GET: AtividadesSecundarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtividadesSecundaria atividadesSecundaria = db.AtividadesSecundarias.Find(id);
            if (atividadesSecundaria == null)
            {
                return HttpNotFound();
            }
            return View(atividadesSecundaria);
        }

        // GET: AtividadesSecundarias/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaID = new SelectList(db.Empresas, "Id", "Nome");
            return View();
        }

        // POST: AtividadesSecundarias/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Code,EmpresaID")] AtividadesSecundaria atividadesSecundaria)
        {
            if (ModelState.IsValid)
            {
                if (atividadesSecundaria.EmpresaID == 0)
                {
                    ModelState.AddModelError("EmpresaID", "Selecione uma empresa, caso não exista favor cadastrar uma! ");
                }
                else
                {
                    db.AtividadesSecundarias.Add(atividadesSecundaria);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.EmpresaID = new SelectList(db.Empresas, "Id", "Nome", atividadesSecundaria.EmpresaID);
            return View(atividadesSecundaria);
        }

        // GET: AtividadesSecundarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtividadesSecundaria atividadesSecundaria = db.AtividadesSecundarias.Find(id);
            if (atividadesSecundaria == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaID = new SelectList(db.Empresas, "Id", "Nome", atividadesSecundaria.EmpresaID);
            return View(atividadesSecundaria);
        }

        // POST: AtividadesSecundarias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Code,EmpresaID")] AtividadesSecundaria atividadesSecundaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atividadesSecundaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaID = new SelectList(db.Empresas, "Id", "Nome", atividadesSecundaria.EmpresaID);
            return View(atividadesSecundaria);
        }

        // GET: AtividadesSecundarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtividadesSecundaria atividadesSecundaria = db.AtividadesSecundarias.Find(id);
            if (atividadesSecundaria == null)
            {
                return HttpNotFound();
            }
            return View(atividadesSecundaria);
        }

        // POST: AtividadesSecundarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AtividadesSecundaria atividadesSecundaria = db.AtividadesSecundarias.Find(id);
            db.AtividadesSecundarias.Remove(atividadesSecundaria);
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
