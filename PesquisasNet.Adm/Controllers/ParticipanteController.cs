using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PesquisasNet.Adm.Controllers
{
    public class ParticipanteController : Controller
    {
        [Route("Participante/Index/{tipoExibicao}")]
        public ActionResult Index(int? tipoExibicao = 1)
        {
            ViewBag.TipoExibicao = tipoExibicao;

            return View();
        }

        public ActionResult Detalhe()
        {
            return View();
        }
    }
}