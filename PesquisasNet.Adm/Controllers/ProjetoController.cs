using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PesquisasNet.Domain.Modelo;

namespace PesquisasNet.Adm.Controllers
{
    public class ProjetoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Projeto modelo)
        {
            return RedirectToAction("Index");
        }
    }
}