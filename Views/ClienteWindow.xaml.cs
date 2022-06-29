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
    /// Lógica interna para ClienteWindow.xaml
    /// </summary>
    public partial class ClienteWindow : Window
    {
        public ClienteWindow()
        {
            InitializeComponent();
            Loaded += ClienteWindow_Loaded;
        }

        private void ClienteWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.fr_cliente.NavigationService.Navigate(new ListagemClientePage());
        }

        private void voltar_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cadastro_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            this.fr_cliente.NavigationService.Navigate(new CadastroClientePage());
        }

        private void listagem_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            this.fr_cliente.NavigationService.Navigate(new ListagemClientePage());
        }
    }
}
