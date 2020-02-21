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
    public class EmpresasController : Controller
    {
        private Context db = new Context();

        // GET: Empresas
        public ActionResult Index()
        {
            return View(db.Empresas.ToList());
        }

        // GET: Empresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cnpj,DataSituacao,Efr,Uf,Telefone,Email,Situacao,Bairro,Logradouro,Numero,Cep,Municipio,Porte,Abertura,NaturezaJuridica,Fantasia,UltimaAtualizacao,Status,Tipo,Complemento,MotivoSituacao,SituacaoEspecial,DataSituacaoEspecial,CapitalSocial")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                if (empresa.Nome == "" && empresa.Cnpj != "")
                {
                    ModelState.AddModelError("Nome", "O Nome é um campo obrigatório! Favor inserir um Nome");

                }
                else if (empresa.Nome != "" && empresa.Cnpj == "")
                {
                    ModelState.AddModelError("Cnpj", "O Cnpj é um campo obrigatório! Favor inserir um Cnpj");
                }
                else if (empresa.Nome == "" && empresa.Cnpj == "")
                {
                    ModelState.AddModelError("Nome", "O Nome é um campo obrigatório! Favor inserir um Nome");
                    ModelState.AddModelError("Cnpj", "O Cnpj é um campo obrigatório! Favor inserir um Cnpj");
                }
                else
                {
                    db.Empresas.Add(empresa);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Cnpj,DataSituacao,Efr,Uf,Telefone,Email,Situacao,Bairro,Logradouro,Numero,Cep,Municipio,Porte,Abertura,NaturezaJuridica,Fantasia,UltimaAtualizacao,Status,Tipo,Complemento,MotivoSituacao,SituacaoEspecial,DataSituacaoEspecial,CapitalSocial")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresas.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empresa empresa = db.Empresas.Find(id);
            db.Empresas.Remove(empresa);
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
