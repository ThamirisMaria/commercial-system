using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    class VendaItem
    {
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public double Valor { get; set; }

        public double ValorTotal { get; set; }

        public Produto Produto { get; set; }
    }
}
