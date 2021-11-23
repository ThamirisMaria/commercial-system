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
            try
            {
                var query = conexao.Query();
                query.CommandText = "INSERT INTO produto (nome_prod, descricao_prod, marca_prod, valor_venda_prod) " +
                    "VALUES (@nome, @descricao, @marca, @valorVenda)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@descricao", t.Descricao);
                query.Parameters.AddWithValue("@marca", t.Marca);
                query.Parameters.AddWithValue("@valorVenda", t.ValorVenda);

                var linhasAfetadas = query.ExecuteNonQuery();

                if (linhasAfetadas == 0)
                    throw new Exception("Registro não efetuado. Verifique e tente novamente.");
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                conexao.Close();
            }
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
