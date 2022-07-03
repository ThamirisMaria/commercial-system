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
    /// Lógica interna para CadastroGeralWindow.xaml
    /// </summary>
    public partial class CadastroGeralWindow : Window
    {
        public CadastroGeralWindow()
        {
            InitializeComponent();
        }

        private void clientes_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            this.fr_cadastros.NavigationService.Navigate(new CadastroClientePage());
        }

        private void funcionarios_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            this.fr_cadastros.NavigationService.Navigate(new CadastroFuncionarioPage());
        }

        private void produtos_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            this.fr_cadastros.NavigationService.Navigate(new CadastroProdutoPage());
        }

        private void voltar_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
