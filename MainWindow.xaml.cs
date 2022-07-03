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
using MySql.Data.MySqlClient;
using SistemaVendas.Models;
using SistemaVendas.Views;

namespace SistemaVendas
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void clientes_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            ClienteWindow clienteWindow = new ClienteWindow();
            clienteWindow.ShowDialog();
        }

        private void funcionarios_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            FuncionarioWindow funcionarioWindow = new FuncionarioWindow();
            funcionarioWindow.ShowDialog();
        }

        private void produtos_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            ProdutoWindow produtoWindow = new ProdutoWindow();
            produtoWindow.ShowDialog();
        }

        private void vendas_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            VendaWindow vendaWindow = new VendaWindow();
            vendaWindow.ShowDialog();
        }

        private void vender_btn_Click(object sender, RoutedEventArgs e)
        {
            CadastroVendaWindow cadastroVendaWindow = new CadastroVendaWindow();
            cadastroVendaWindow.ShowDialog();
        }

        private void cadastrar_btn_Click(object sender, RoutedEventArgs e)
        {
            CadastroGeralWindow cadastroGeralWindow = new CadastroGeralWindow();
            cadastroGeralWindow.ShowDialog();
        }

        private void dashboard_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            DashboardWindow dashboardWindow = new DashboardWindow();
            dashboardWindow.ShowDialog();
        }
    }
}
