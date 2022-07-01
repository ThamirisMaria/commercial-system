using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVendas.Interfaces;
using SistemaVendas.Database;

namespace SistemaVendas.Models
{
    class ClienteDAO : IDAO<Cliente>
    {
        private static Conexao conexao;
        
        public ClienteDAO()
        {
            conexao = new Conexao();
        }

        public void Delete(Cliente t)
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Cliente t)
        {
            try
            {
                var query = conexao.Query();
                query.CommandText = "INSERT INTO cliente (nome_cli, cpf_cli, rg_cli, datanasc_cli, telefone_fixo_cli, telefone_celular_cli, email_cli, cod_sex_fk, cod_end_fk) " +
                    "VALUES (@nome, @cpf, @rg, @datanasc, @telefone, @celular, @email, @sexoId, @enderecoId)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@datanasc", t.DataNascimento.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@celular", t.Celular);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@sexoId", t.Sexo.Id);
                query.Parameters.AddWithValue("@enderecoId", t.Endereco.Id);

                var linhasAfetadas = query.ExecuteNonQuery();

                if (linhasAfetadas == 0)
                    throw new Exception("Registro não efetuado. Verifique e tente novamente.");
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

        public List<Cliente> List()
        {
            try
            {
                List<Cliente> list = new List<Cliente>();

                var query = conexao.Query();
                query.CommandText = "SELECT * FROM cliente LEFT JOIN sexo ON cod_sex = cod_sex_fk";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Cliente()
                    {
                        Id = reader.GetInt32("cod_cli"),
                        Nome = reader.GetString("nome_cli"),
                        CPF = reader.GetString("cpf_cli"),
                        RG = reader.GetString("rg_cli"),
                        DataNascimento = reader.GetDateTime("datanasc_cli"),
                        Celular = reader.GetString("telefone_celular_cli"),
                        Email = reader.GetString("email_cli"),
                        Sexo = new Sexo() { Id = reader.GetInt32("cod_sex"), Nome = reader.GetString("nome_sex") }
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

        public void Update(Cliente t)
        {
            try
            {
                long enderecoId = t.Endereco.Id;
                var endDAO = new EnderecoDAO();

                if (enderecoId > 0)
                    endDAO.Update(t.Endereco);
                else
                    enderecoId = endDAO.Insert(t.Endereco);

                var query = conexao.Query();
                query.CommandText = "UPDATE cliente SET nome_cli = @nome, cpf_cli = @cpf, rg_cli = @rg, datanasc_cli = @datanasc, telefone_fixo_cli = @telefone, telefone_celular_cli = @celular, email_cli = @email, cod_sex_fk = @sexoId, cod_end_fk = @enderecoId " +
                    "WHERE cod_cli = @id";

                query.Parameters.AddWithValue("@id", t.Id);

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@datanasc", t.DataNascimento.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@celular", t.Celular);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@sexoId", t.Sexo.Id);
                query.Parameters.AddWithValue("@enderecoId", enderecoId);

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
