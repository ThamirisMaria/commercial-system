using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using SistemaVendas.Database;
using SistemaVendas.Interfaces;

namespace SistemaVendas.Models
{
    class SexoDAO : IDAO<Sexo>
    {
        private static Conexao conexao;

        public SexoDAO()
        {
            conexao = new Conexao();
        }

        public void Delete(Sexo t)
        {
            throw new NotImplementedException();
        }

        public Sexo GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Sexo t)
        {
            throw new NotImplementedException();
        }

        public List<Sexo> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Sexo t)
        {
            throw new NotImplementedException();
        }
    }
}
