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
    class VendaDAO : IDAO<Venda>
    {
        private Conexao conexao;

        public VendaDAO()
        {
            conexao = new Conexao();
        }

        public void Delete(Venda t)
        {
            try
            {
                var query = conexao.Query();
                query.CommandText = "DELETE FROM venda WHERE cod_vend = @id";

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

        public Venda GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Venda t)
        {
            try
            {
                var query = conexao.Query();
                query.CommandText = "INSERT INTO venda (cod_func_fk, cod_cli_fk, data_vend, forma_pagamento_vend, valor_total_vend) " +
                    "VALUES (@funcionario, @cliente, @data, @forma_pagamento, @valor_total)";

                query.Parameters.AddWithValue("@funcionario", t.Funcionario.Id);
                query.Parameters.AddWithValue("@cliente", t.Cliente.Id);
                query.Parameters.AddWithValue("@data", t.Data.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@forma_pagamento", t.FormaPagamento);
                query.Parameters.AddWithValue("@valor_total", t.ValorTotal);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Venda não realizada. Verifique e tente novamente!");

                long vendaId = query.LastInsertedId;

                InsertItens(vendaId, t.Itens);
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

        private void InsertItens(long vendaId, List<VendaItem> itens)
        {

            foreach (VendaItem item in itens)
            {
                var query = conexao.Query();
                query.CommandText = "INSERT INTO venda_itens (quantidade_itenv, valor_itenv, valor_total_itenv, cod_vend_fk, cod_prod_fk) " +
                    "VALUES (@quantidade, @valor, @valor_total, @venda, @produto)";

                query.Parameters.AddWithValue("@venda", vendaId);
                query.Parameters.AddWithValue("@produto", item.Produto.Id);
                query.Parameters.AddWithValue("@quantidade", item.Quantidade);
                query.Parameters.AddWithValue("@valor", item.Valor);
                query.Parameters.AddWithValue("@valor_total", item.ValorTotal);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Os itens da compra não foi adicionada. Verifique e tente novamente.");
            }
        }

        public List<Venda> List()
        {
            try
            {
                List<Venda> list = new List<Venda>();

                var query = conexao.Query();
                query.CommandText = "SELECT * FROM venda LEFT JOIN funcionario ON cod_func = cod_func_fk LEFT JOIN cliente ON cod_cli = cod_cli_fk";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Venda()
                    {
                        Id = reader.GetInt32("cod_vend"),
                        Data = reader.GetDateTime("data_vend"),
                        FormaPagamento = reader.GetString("forma_pagamento_vend"),
                        ValorTotal = reader.GetDouble("valor_total_vend"),
                        Funcionario = new Funcionario() { Id = reader.GetInt32("cod_func"), Nome = reader.GetString("nome_func") },
                        Cliente = new Cliente() { Id = reader.GetInt32("cod_cli"), Nome = reader.GetString("nome_cli") }
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

        public void Update(Venda t)
        {
            throw new NotImplementedException();
        }
    }
}
