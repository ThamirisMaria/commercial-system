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
    /// Lógica interna para CadastroVendaWindow.xaml
    /// </summary>
    public partial class CadastroVendaWindow : Window
    {
        private Venda _venda = new Venda();

        private List<VendaItem> _vendaItensList = new List<VendaItem>();

        public CadastroVendaWindow()
        {
            InitializeComponent();
            Loaded += CadastroVendaWindow_Loaded;
        }

        private void CadastroVendaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDatePicker();
            LoadComboBoxes();
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            if (dpData.SelectedDate != null)
                _venda.Data = (DateTime)dpData.SelectedDate;

            if (cbFuncionario.SelectedItem != null)
                _venda.Funcionario = cbFuncionario.SelectedItem as Funcionario;

            if (cbCliente.SelectedItem != null)
                _venda.Cliente = cbCliente.SelectedItem as Cliente;

            _venda.FormaPagamento = txtFormaPagamento.Text;
            _venda.ValorTotal = UpdateValorTotal();
            _venda.Itens = _vendaItensList;

            SalvarVenda();
        }

        private void SalvarVenda()
        {
            try
            {
                var dao = new VendaDAO();
                dao.Insert(_venda);

                MessageBox.Show("Venda realizada com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEscolherItens_Click(object sender, RoutedEventArgs e)
        {
            BuscaVendaItem buscaVendaItem = new BuscaVendaItem();
            buscaVendaItem.ShowDialog();

            var itensSelecionadosList = buscaVendaItem.ItensSelecionados;
            var count = 1;

            foreach(Produto produto in itensSelecionadosList)
            {
                if(!_vendaItensList.Exists(item => item.Produto.Id == produto.Id))
                {
                    _vendaItensList.Add(new VendaItem()
                    {
                        Id = count,
                        Quantidade = 1,
                        Valor = produto.ValorVenda,
                        ValorTotal = produto.ValorVenda,
                        Produto = produto
                    });
                }
                count++;

                LoadDataGrid();
            }
        }

        private void LoadDataGrid()
        {
            _ = UpdateValorTotal();
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = _vendaItensList;
        }

        private double UpdateValorTotal()
        {
            double valor = 0.0;

            _vendaItensList.ForEach(item => valor += item.ValorTotal);

            txtValorTotal.Text = valor.ToString("C");

            return valor;
        }

        private void btnRemoverProduto_Click(object sender, RoutedEventArgs e)
        {
            var itemSelected = dataGrid.SelectedItem as VendaItem;

            _vendaItensList.Remove(itemSelected);

            LoadDataGrid();
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var item = e.Row.Item as VendaItem;

            var valor = (e.EditingElement as TextBox).Text;

            _ = int.TryParse(valor, out int quantidade);

            if (quantidade > 1)
            {
                item.Quantidade = quantidade;
                item.ValorTotal = quantidade * item.Valor;

                LoadDataGrid();
            }
        }

        private void LoadDatePicker()
        {
            dpData.SelectedDate = DateTime.Now;
        }

        private void LoadComboBoxes()
        {
            try
            {
                cbFuncionario.ItemsSource = new FuncionarioDAO().List();
                cbCliente.ItemsSource = new ClienteDAO().List();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
