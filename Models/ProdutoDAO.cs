using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVendas.Interfaces;
using SistemaVendas.Database;
using MySql.Data.MySqlClient;

namespace SistemaVendas.Models
{
    class ProdutoDAO : IDAO<Produto>
    {
        private static Conexao conexao;

        public ProdutoDAO()
        {
            conexao = new Conexao();
        }

        public void Delete(Produto t)
        {
            throw new NotImplementedException();
        }

        public Produto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Produto t)
        {
            throw new NotImplementedException();
        }

        public List<Produto> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Produto t)
        {
            throw new NotImplementedException();
        }
    }
}
