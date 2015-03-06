using PesquisasNet.Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PesquisasNet.Infra.DataModelConfig
{
    public class DataModelConfig : DDBContext
    {
        public bool UpdateDataModel()
        {
            return false;
        }

        public void CreateDataModel()
        {
            base.CreateTable("Usuario", "Email", "Senha", 1, 1);
            base.CreateTable("Empresa", "NomeCategoria", 1, 1);
            base.CreateTable("Pesquisa", "NomeCategoria", 1, 1);
        }
    }
}
