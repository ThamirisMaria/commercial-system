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
            try
            {
                var query = conexao.Query();
                query.CommandText = "DELETE FROM produto WHERE cod_prod = @id";

                query.Parameters.AddWithValue("@id", t.Id);

                var linhasAfetadas = query.ExecuteNonQuery();

                if (linhasAfetadas == 0)
                    throw new Exception("Registro não excluido. Verifique e tente novamente.");
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexao.Close();
            }
        }

        public Produto GetById(int id)
        {
            try
            {
                var query = conexao.Query();
                query.CommandText = "SELECT * FROM produto WHERE cod_prod = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var produto = new Produto();

                while (reader.Read())
                {
                    produto.Id = reader.GetInt32("cod_prod");
                    produto.Nome = reader.GetString("nome_prod");
                    produto.Descricao = reader.GetString("descricao_prod");
                    produto.Marca = reader.GetString("marca_prod");
                    produto.ValorVenda = reader.GetDouble("valor_venda_prod");
                }

                return produto;
            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                conexao.Query();
            }
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
            try
            {
                List<Produto> list = new List<Produto>();

                var query = conexao.Query();
                query.CommandText = "SELECT * FROM produto";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Produto()
                    {
                        Id = reader.GetInt32("cod_prod"),
                        Nome = reader.GetString("nome_prod"),
                        Descricao = reader.GetString("descricao_prod"),
                        Marca = reader.GetString("marca_prod"),
                        ValorVenda = reader.GetDouble("valor_venda_prod")
                    });
                }

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexao.Close();
            }
        }

        public void Update(Produto t)
        {
            try
            {
                var query = conexao.Query();
                query.CommandText = "UPDATE produto SET nome_prod = @nome, descricao_prod = @descricao, marca_prod = @marca, valor_venda_prod = @valorVenda " +
                    "WHERE cod_prod = @id";

                query.Parameters.AddWithValue("@id", t.Id);

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@descricao", t.Descricao);
                query.Parameters.AddWithValue("@marca", t.Marca);
                query.Parameters.AddWithValue("@valorVenda", t.ValorVenda);

                var linhasAfetadas = query.ExecuteNonQuery();

                if (linhasAfetadas == 0)
                    throw new Exception("Atualização não efetuada. Verifique e tente novamente.");
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
