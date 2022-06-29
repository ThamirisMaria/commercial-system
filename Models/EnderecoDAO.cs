using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVendas.Database;
using SistemaVendas.Interfaces;

namespace SistemaVendas.Models
{
    class EnderecoDAO
    {
        private static Conexao conexao = new Conexao();
        public long Insert(Endereco t)
        {
            try
            {
                var query = conexao.Query();
                query.CommandText = "INSERT INTO endereco (rua_end, numero_end, bairro_end, cidade_end, estado_end) " +
                    "VALUES (@rua, @numero, @bairro, @cidade, @estado)";

                query.Parameters.AddWithValue("@rua", t.Rua);
                query.Parameters.AddWithValue("@numero", t.Numero);
                query.Parameters.AddWithValue("@bairro", t.Bairro);
                query.Parameters.AddWithValue("@cidade", t.Cidade);
                query.Parameters.AddWithValue("@estado", t.Estado);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Erro ao salvar o endereço. Verifique e tente novamente.");

                return query.LastInsertedId;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Insert(Endereco t)
        {
            throw new NotImplementedException();
        }

        public List<Endereco> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Endereco t)
        {
            throw new NotImplementedException();
        }
    }
}
