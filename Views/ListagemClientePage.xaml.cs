using SistemaVendas.Models;
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

namespace SistemaVendas.Views
{
    /// <summary>
    /// Interação lógica para ListagemClientePage.xam
    /// </summary>
    public partial class ListagemClientePage : Page
    {
        public ListagemClientePage()
        {
            InitializeComponent();
            Loaded += ListagemClientePage_Loaded;
        }

        private void ListagemClientePage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            try
            {
                var dao = new ClienteDAO();
                dataGrid.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            var clienteSelected = dataGrid.SelectedItem as Cliente;

            var edicao = new EdicaoClienteWindow(clienteSelected.Id);
            edicao.ShowDialog();
            LoadList();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            var clienteSelected = dataGrid.SelectedItem as Cliente;

            var result = MessageBox.Show($"Realmente deseja excluir o cliente {clienteSelected.Nome}?", "Confirmar exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new ClienteDAO();

                    dao.Delete(clienteSelected);
                    MessageBox.Show("Cliente excluido com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);

                    LoadList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
