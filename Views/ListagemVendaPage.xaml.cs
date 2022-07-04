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
    /// Interação lógica para ListagemVendaPage.xam
    /// </summary>
    public partial class ListagemVendaPage : Page
    {
        public ListagemVendaPage()
        {
            InitializeComponent();
            Loaded += ListagemVendaPage_Loaded;
        }

        private void ListagemVendaPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            try
            {
                var dao = new VendaDAO();
                dataGrid.ItemsSource = dao.List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Update_Click(object sender, RoutedEventArgs e)
        {
            //var vendaSelected = dataGrid.SelectedItem as Venda;

            //var edicao = new EdicaoVendaWindow(vendaSelected.Id);
            //edicao.ShowDialog();
            LoadList();
        }

        private void Button_Delete_Click(object sender, RoutedEventArgs e)
        {
            var vendaSelected = dataGrid.SelectedItem as Venda;

            var result = MessageBox.Show("Realmente deseja excluir esta venda?", "Confirmar exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    var dao = new VendaDAO();

                    dao.Delete(vendaSelected);
                    MessageBox.Show("Venda excluido com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);

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
