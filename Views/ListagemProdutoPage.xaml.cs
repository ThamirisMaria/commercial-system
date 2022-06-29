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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SistemaVendas.Models;

namespace SistemaVendas.Views
{
    /// <summary>
    /// Interação lógica para ListagemProdutoPage.xam
    /// </summary>
    public partial class ListagemProdutoPage : Page
    {
        public ListagemProdutoPage()
        {
            InitializeComponent();
            Loaded += ListagemProdutoPage_Loaded;
        }

        private void ListagemProdutoPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            try
            {
                var dao = new ProdutoDAO();
                dataGrid.ItemsSource = dao.List();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            var produtoSelected = dataGrid.SelectedItem as Produto;

            var edicao = new EdicaoProdutoWindow(produtoSelected.Id);
            edicao.ShowDialog();
            LoadList();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            var produtoSelected = dataGrid.SelectedItem as Produto;

            var result = MessageBox.Show($"Realmente deseja excluir o produto {produtoSelected.Nome}?", "Confirmar exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if(result == MessageBoxResult.Yes)
                {
                    var dao = new ProdutoDAO();

                    dao.Delete(produtoSelected);
                    MessageBox.Show("Produto excluido com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    LoadList();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
