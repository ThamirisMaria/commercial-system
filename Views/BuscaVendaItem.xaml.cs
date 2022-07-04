using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SistemaVendas.Models;

namespace SistemaVendas.Views
{
    /// <summary>
    /// Lógica interna para BuscaVendaItem.xaml
    /// </summary>
    public partial class BuscaVendaItem : Window
    {
        private List<Produto> _produtoList = new List<Produto>();

        public List<Produto> ItensSelecionados { get; private set; } = new List<Produto>();

        public BuscaVendaItem()
        {
            InitializeComponent();
            Loaded += BuscaVendaItem_Loaded;
        }

        private void BuscaVendaItem_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void bntBusca_Click(object sender, RoutedEventArgs e)
        {
            var text = txtBusca.Text;

            var filteredList = _produtoList.Where(i => i.Nome.ToLower().Contains(text.ToLower()));

            dataGrid.ItemsSource = filteredList;
        } 

        private void btnEscolher_Click(object sender, RoutedEventArgs e)
        {
            var itens = dataGrid.Items;
            ItensSelecionados.Clear();

            foreach(Produto produto in itens)
            {
                if (produto.IsSelected)
                    ItensSelecionados.Add(produto);
            }

            if (ItensSelecionados.Count == 0)
                MessageBox.Show("Nenhum produto foi selecionado", "Nenhum item selecionado!", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Produto(s) selcionado(s) com sucesso", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void LoadDataGrid()
        {
            try
            {
                _produtoList = new ProdutoDAO().List();
                dataGrid.ItemsSource = _produtoList;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
