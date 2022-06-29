using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVendas.Interfaces;
using SistemaVendas.Database;

namespace SistemaVendas.Models
{
    class FuncionarioDAO : IDAO<Funcionario>
    {
        private static Conexao conexao;

        public FuncionarioDAO()
        {
            conexao = new Conexao();
        }
        public void Delete(Funcionario t)
        {
            throw new NotImplementedException();
        }

        public Funcionario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Funcionario t)
        {
            try
            {
                var query = conexao.Query();
                query.CommandText = "INSERT INTO funcionario (nome_func, cpf_func, rg_func, datanasc_func, telefone_func, email_func, celular_func, funcao_func, salario_func, cod_sex_fk, cod_end_fk) " +
                    "VALUES (@nome, @cpf, @rg, @datanasc, @telefone, @email, @celular, @funcao, @salario, @sexoId, @enderecoId)";
                
                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@datanasc", t.DataNascimento.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@celular", t.Celular);
                query.Parameters.AddWithValue("@funcao", t.Funcao);
                query.Parameters.AddWithValue("@salario", t.Salario);
                query.Parameters.AddWithValue("@sexoId", t.Sexo.Id);
                query.Parameters.AddWithValue("@enderecoId", t.Endereco.Id);

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

        public List<Funcionario> List()
        {
            try
            {
                List<Funcionario> list = new List<Funcionario>();

                var query = conexao.Query();
                query.CommandText = "SELECT * FROM funcionario LEFT JOIN sexo ON cod_sex = cod_sex_fk";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Funcionario()
                    {
                        Id = reader.GetInt32("cod_func"),
                        Nome = reader.GetString("nome_func"),
                        CPF = reader.GetString("cpf_func"),
                        RG = reader.GetString("rg_func"),
                        DataNascimento = reader.GetDateTime("datanasc_func"),
                        Email = reader.GetString("email_func"),
                        Celular = reader.GetString("celular_func"),
                        Funcao = reader.GetString("funcao_func"),
                        Salario = reader.GetDouble("salario_func"),
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

        public void Update(Funcionario t)
        {
            throw new NotImplementedException();
        }
    }
}
