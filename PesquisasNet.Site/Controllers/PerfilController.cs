using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PesquisasNet.Domain.Interfaces.Services;
using PesquisasNet.Infra.Interfaces.AWS;
using PesquisasNet.Domain.Modelo;

namespace PesquisasNet.Site.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IS3Service _s3Service;

        public List<Disponibilidade> Disponibilidades { get; set; }
        public List<Categoria> Categorias { get; set; }

        public PerfilController(IUsuarioService usuarioService, IS3Service s3Service)
        {
            this._usuarioService = usuarioService;
            this._s3Service = s3Service;

            this.Disponibilidades = new List<Disponibilidade>();

            this.Categorias = new List<Categoria>();
            this.Categorias.Add(new Categoria { Nome = "Esporte" });
            this.Categorias.Add(new Categoria { Nome = "Lazer" });
            this.Categorias.Add(new Categoria { Nome = "Futebol" });
            this.Categorias.Add(new Categoria { Nome = "Alimentação" });
            this.Categorias.Add(new Categoria { Nome = "Beleza" });
            this.Categorias.Add(new Categoria { Nome = "Automóvel" });
        }

        public ActionResult Index()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            var usuario = JsonConvert.DeserializeObject<Usuario>(Session["Usuario"].ToString());

            usuario.AreasInteresse = new List<Categoria>();

            ViewBag.Usuario = usuario;
            ViewBag.Categorias = Categorias;

            return View();
        }

        public ActionResult Edit()
        {
            if (Session["Usuario"] == null)
                return RedirectToAction("Index", "Login");

            var usuario = JsonConvert.DeserializeObject<Usuario>(Session["Usuario"].ToString());

            usuario.AreasInteresse = new List<Categoria>();

            ViewBag.Usuario = usuario;
            ViewBag.Categorias = Categorias;

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Usuario modelo, string AreasInteresse)
        {
            var usuario = JsonConvert.DeserializeObject<Usuario>(Session["Usuario"].ToString());
            usuario.Telefone = modelo.Telefone;
            usuario.Celular = modelo.Celular;
            usuario.Cpf = modelo.Cpf;
            usuario.Rg = modelo.Rg;
            usuario.Escolaridade = modelo.Escolaridade;
            usuario.Cidade = modelo.Cidade;
            usuario.Regiao = modelo.Regiao;
            usuario.Profissao = modelo.Profissao;
            usuario.Sexo = modelo.Sexo;
            usuario.AreasInteresse = modelo.AreasInteresse;
            usuario.Disponibilidades = modelo.Disponibilidades;
            usuario.DataNascimento = modelo.DataNascimento;
            usuario.DataAlteracao = DateTime.Now;
            usuario.Ativo = modelo.Ativo;

            //usuario.AreasInteresse = new List<Categoria>();

            //foreach (var item in AreasInteresse.Split(','))
            //{
            //    usuario.AreasInteresse.Add(new Categoria { Nome = item.ToString() });
            //}

            _usuarioService.Save(usuario);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SaveUploadedFile()
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    _s3Service.UploadFile(file.InputStream, "perfil");
                }

                return Json(new { Message = "upload com sucesso." });
            }
            catch
            {
                
                return Json(new { Message = "Error in saving file" });
            }
        }
    }
}
