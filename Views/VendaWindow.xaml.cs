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
    /// Lógica interna para VendaWindow.xaml
    /// </summary>
    public partial class VendaWindow : Window
    {
        public VendaWindow()
        {
            InitializeComponent();
            Loaded += VendaWindow_Loaded;
        }

        private void VendaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.fr_venda.NavigationService.Navigate(new ListagemVendaPage());
        }

        private void listagem_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            this.fr_venda.NavigationService.Navigate(new ListagemVendaPage());
        }

        private void cadastro_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            CadastroVendaWindow cadastroVendaWindow = new CadastroVendaWindow();
            cadastroVendaWindow.ShowDialog();
        }

        private void voltar_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
