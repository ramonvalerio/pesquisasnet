using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PesquisasNet.Domain.Modelo;

namespace PesquisasNet.Adm.Controllers
{
    public class PesquisaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detalhe()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Pesquisa modelo)
        {
            return RedirectToAction("Index");
        }
    }
}