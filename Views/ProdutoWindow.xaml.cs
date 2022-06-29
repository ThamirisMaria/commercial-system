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

namespace SistemaVendas.Views
{
    /// <summary>
    /// Lógica interna para ProdutoWindow.xaml
    /// </summary>
    public partial class ProdutoWindow : Window
    {
        public ProdutoWindow()
        {
            InitializeComponent();
            Loaded += ProdutoWindow_Loaded;
        }

        private void ProdutoWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.fr_produto.NavigationService.Navigate(new ListagemProdutoPage());
        }

        private void voltar_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cadastro_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            this.fr_produto.NavigationService.Navigate(new CadastroProdutoPage());
        }

        private void listagem_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            this.fr_produto.NavigationService.Navigate(new ListagemProdutoPage());
        }
    }
}
