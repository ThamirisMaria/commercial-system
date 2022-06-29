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
    /// Lógica interna para FuncionarioWindow.xaml
    /// </summary>
    public partial class FuncionarioWindow : Window
    {
        public FuncionarioWindow()
        {
            InitializeComponent();
            Loaded += FuncionarioWindow_Loaded;
        }

        private void FuncionarioWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.fr_funcionario.NavigationService.Navigate(new ListagemFuncionarioPage());
        }

        private void voltar_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cadastro_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            this.fr_funcionario.NavigationService.Navigate(new CadastroFuncionarioPage());
        }

        private void listagem_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            this.fr_funcionario.NavigationService.Navigate(new ListagemFuncionarioPage());
        }
    }
}
