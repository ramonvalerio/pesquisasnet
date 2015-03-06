using System;
using System.Text;
using System.Web.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;
using PesquisasNet.Domain.Modelo;
using PesquisasNet.Infra.Interfaces.AWS;
using PesquisasNet.Infra.Services.AWS;
using PesquisasNet.Domain.Interfaces.Services;

namespace PesquisasNet.Site.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ISESService _sesService;

        public LoginController(IUsuarioService usuarioService, ISESService sesService)
        {
            _usuarioService = usuarioService;
            _sesService = sesService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EsqueciMinhaSenha()
        {
            //var whatsapp = new WhatsApp();
            //var code = whatsapp.RequestCode("21976416188");

            return View();
        }

        [HttpPost]
        public ActionResult VerifiqueSeuEmail(string email)
        {
            try
            {
                var usuario = _usuarioService.GetByHashKey(email);

                if (usuario != null)
                {
                    var mensagem = new StringBuilder();
                    mensagem.AppendLine(string.Format("Olá {0} {1}, clique no link abaixo para cadastrar uma nova senha.", usuario.Nome, usuario.SobreNome));
                    mensagem.AppendLine(string.Format("http://www.pesquisasnet.com/email={0}&token={1}", usuario.Email, usuario.Token));

                    _sesService.EnviarEmail(new List<string>() { email }, "PesquisasNet - Esqueci minha senha", mensagem.ToString());
                }
                else
                {
                    throw new Exception("Este email não existe no sistema.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Logar(string Email, string Senha)
        {
            var senhaCriptografada = Util.Seguranca.GerarPBKDF2(Senha);

            var usuario = _usuarioService.GetByHashKey(Email);

            if (usuario != null && usuario.Senha == senhaCriptografada)
            {
                Session["Usuario"] = JsonConvert.SerializeObject(usuario);

                return RedirectToAction("Index", "Pesquisa");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Cadastrar(string Nome, string SobreNome, string Email, string Senha, string ConfirmarSenha)
        {
            if (string.IsNullOrWhiteSpace(Nome))
                return RedirectToAction("Index");

            if (string.IsNullOrWhiteSpace(SobreNome))
                return RedirectToAction("Index");

            if (string.IsNullOrWhiteSpace(Email))
                return RedirectToAction("Index");

            if (string.IsNullOrWhiteSpace(Senha))
                return RedirectToAction("Index");

            if (string.IsNullOrWhiteSpace(ConfirmarSenha))
                return RedirectToAction("Index");

            if (Senha != ConfirmarSenha)
                return RedirectToAction("Index");

            var usuario = _usuarioService.GetByHashKey(Email);

            if (usuario != null)
                return RedirectToAction("Index");

            usuario = new Usuario();
            usuario.Nome = Nome;
            usuario.SobreNome = SobreNome;
            usuario.Email = Email;
            usuario.Senha = Util.Seguranca.GerarPBKDF2(Senha);
            usuario.Token = Guid.NewGuid().ToString().Substring(0, 9);
            usuario.DataInclusao = DateTime.Now;
            usuario.Ativo = true;

            this._usuarioService.Save(usuario);

            try
            {
                var mensagem = string.Format("Olá {0}, seja bem-vindo ao PesquisasNet.com e ganhe dinheiro com pesquisas remuneradas!!", usuario.Nome);

                var email = new List<string>();
                email.Add(usuario.Email);

                _sesService.EnviarEmail(email, "PesquisasNet - Bem-vindo ao PesquisasNet.com !!", mensagem);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Session["Usuario"] = JsonConvert.SerializeObject(usuario);

            return RedirectToAction("Index", "Pesquisa");
        }
    }
}