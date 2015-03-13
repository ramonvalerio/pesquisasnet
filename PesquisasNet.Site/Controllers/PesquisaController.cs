using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using PesquisasNet.Domain.Interfaces.Services;

namespace PesquisasNet.Site.Controllers
{
    public class PesquisaController : Controller
    {
        private readonly IPesquisaService _pesquisaService;

        public PesquisaController(IPesquisaService pesquisaService)
        {
            _pesquisaService = pesquisaService;
        }

        public ActionResult Index(string status)
        {
            var pesquisas = _pesquisaService.GetAll().ToList();

            switch (status)
            {
                case "Disponivel":
                    pesquisas = pesquisas.Where(x => x.Status == "Disponivel").ToList();
                    break;

                case "Indisponivel":
                    pesquisas = pesquisas.Where(x => x.Status == "Indisponivel").ToList();
                    break;

                case "Participada":
                    pesquisas = pesquisas.Where(x => x.Status == "Participada").ToList();
                    break;

                case "Em andamento":
                    pesquisas = pesquisas.Where(x => x.Status == "Em andamento").ToList();
                    break;

                default:
                    pesquisas = pesquisas.Where(x => x.Status == "Disponivel").ToList();
                    break;

            }

            ViewBag.Pesquisas = pesquisas;

            return View();
        }

        [Route("Pesquisa/Detalhe/{codigo}")]
        public ActionResult Detalhe(string codigo)
        {
            var pesquisa = _pesquisaService.GetByHashKeyAndRangeKey(codigo, "PesquisasNet");
            ViewBag.Pesquisa = pesquisa;

            return View();
        }

        public ActionResult Disponiveis()
        {
            return RedirectToAction("Index", new { status = "Disponivel" });
        }

        public ActionResult Indisponiveis()
        {
            return RedirectToAction("Index", new { status = "Indisponivel" });
        }

        public ActionResult Participadas()
        {
            return RedirectToAction("Index", new { status = "Participada" });
        }

        public ActionResult EmAndamento()
        {
            return RedirectToAction("Index", new { status = "Em andamento" });
        }

        public ActionResult Sair()
        {
            Session["Usuario"] = null;

            return RedirectToAction("Index", "Login");
        }
    }
}
