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
    public class AtividadePrincipalsController : Controller
    {
        private Context db = new Context();

        // GET: AtividadePrincipals
        public ActionResult Index()
        {
            var atividadePrincipals = db.AtividadePrincipals.Include(a => a.Empresa);
            return View(atividadePrincipals.ToList());
        }

        // GET: AtividadePrincipals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtividadePrincipal atividadePrincipal = db.AtividadePrincipals.Find(id);
            if (atividadePrincipal == null)
            {
                return HttpNotFound();
            }
            return View(atividadePrincipal);
        }

        // GET: AtividadePrincipals/Create
        public ActionResult Create()
        {
            ViewBag.Cnpj = new SelectList(db.Empresas, "Id", "Cnpj");
            return View();
        }

        // POST: AtividadePrincipals/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Text,Code,Cnpj")] AtividadePrincipal atividadePrincipal)
        {
            if (ModelState.IsValid)
            {
                db.AtividadePrincipals.Add(atividadePrincipal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cnpj = new SelectList(db.Empresas, "Id", "Cnpj", atividadePrincipal.Cnpj);
            return View(atividadePrincipal);
        }

        // GET: AtividadePrincipals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtividadePrincipal atividadePrincipal = db.AtividadePrincipals.Find(id);
            if (atividadePrincipal == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cnpj = new SelectList(db.Empresas, "Id", "Cnpj", atividadePrincipal.Cnpj);
            return View(atividadePrincipal);
        }

        // POST: AtividadePrincipals/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,Code,Cnpj")] AtividadePrincipal atividadePrincipal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atividadePrincipal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cnpj = new SelectList(db.Empresas, "Id", "Cnpj", atividadePrincipal.Cnpj);
            return View(atividadePrincipal);
        }

        // GET: AtividadePrincipals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtividadePrincipal atividadePrincipal = db.AtividadePrincipals.Find(id);
            if (atividadePrincipal == null)
            {
                return HttpNotFound();
            }
            return View(atividadePrincipal);
        }

        // POST: AtividadePrincipals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AtividadePrincipal atividadePrincipal = db.AtividadePrincipals.Find(id);
            db.AtividadePrincipals.Remove(atividadePrincipal);
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
