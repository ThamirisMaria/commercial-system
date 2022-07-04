using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    class Venda
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string FormaPagamento { get; set; }

        public double ValorTotal { get; set; }

        public Funcionario Funcionario { get; set; }

        public Cliente Cliente { get; set; }

        public List<VendaItem> Itens { get; set; } = new List<VendaItem>();
    }
}
