using CarteiraEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarteiraEF.Controllers
{
    public class PessoaController : Controller
    {
        PessoaContext objContext;
        public PessoaController()
        {
            objContext = new PessoaContext();
        }

        #region List and Details Pessoas   
        public ActionResult Index()
        {
            var p = objContext.Pessoas.ToList();
            return View(p);
        }
        public ViewResult Details(int id)
        {
            Pessoa p = objContext.Pessoas.Where(x => x.PessoaId == id).SingleOrDefault();
            return View(p);
        }
        #endregion

        #region Create Pessoa   
        public ActionResult Create()
        {
            return View(new Pessoa());
        }
        [HttpPost]
        public ActionResult Create(Pessoa p)
        {
            objContext.Pessoas.Add(p);
            objContext.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region Edit Pessoa
        public ActionResult Edit(int id)
        {
            Pessoa p = objContext.Pessoas.Where(x => x.PessoaId == id).SingleOrDefault();
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(Pessoa model)
        {
            Pessoa p = objContext.Pessoas.Where(x => x.PessoaId == model.PessoaId).SingleOrDefault();
            if (p != null)
            {
                objContext.Entry(p).CurrentValues.SetValues(model);
                objContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }
        #endregion

        #region Delete Pessoa   
        public ActionResult Delete(int id)
        {
            Pessoa p = objContext.Pessoas.Find(id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(int id, Pessoa model)
        {
            var p = objContext.Pessoas.Where(x => x.PessoaId == id).SingleOrDefault();
            if (p != null)
            {
                objContext.Pessoas.Remove(p);
                objContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}