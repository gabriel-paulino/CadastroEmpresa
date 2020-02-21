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
    public class QsasController : Controller
    {
        private Context db = new Context();

        // GET: Qsas
        public ActionResult Index()
        {
            var qsas = db.Qsas.Include(q => q.Empresa);
            return View(qsas.ToList());
        }

        // GET: Qsas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qsa qsa = db.Qsas.Find(id);
            if (qsa == null)
            {
                return HttpNotFound();
            }
            return View(qsa);
        }

        // GET: Qsas/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaID = new SelectList(db.Empresas, "Id", "Nome");
            return View();
        }

        // POST: Qsas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Qual,Nome,EmpresaID")] Qsa qsa)
        {
            if (ModelState.IsValid)
            {
                if (qsa.EmpresaID == 0)
                {
                    ModelState.AddModelError("EmpresaID", "Selecione uma empresa, caso não exista favor cadastrar uma! ");
                }
                else
                {
                    db.Qsas.Add(qsa);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.EmpresaID = new SelectList(db.Empresas, "Id", "Nome", qsa.EmpresaID);
            return View(qsa);
        }

        // GET: Qsas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qsa qsa = db.Qsas.Find(id);
            if (qsa == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaID = new SelectList(db.Empresas, "Id", "Nome", qsa.EmpresaID);
            return View(qsa);
        }

        // POST: Qsas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Qual,Nome,EmpresaID")] Qsa qsa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qsa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaID = new SelectList(db.Empresas, "Id", "Nome", qsa.EmpresaID);
            return View(qsa);
        }

        // GET: Qsas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qsa qsa = db.Qsas.Find(id);
            if (qsa == null)
            {
                return HttpNotFound();
            }
            return View(qsa);
        }

        // POST: Qsas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Qsa qsa = db.Qsas.Find(id);
            db.Qsas.Remove(qsa);
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
