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
    /// Lógica interna para EdicaoProdutoWindow.xaml
    /// </summary>
    public partial class EdicaoProdutoWindow : Window
    {
        private int _id;
        private Produto _produto;

        public EdicaoProdutoWindow()
        {
            InitializeComponent();
            Loaded += EdicaoProdutoWindow_Loaded;
        }

        public EdicaoProdutoWindow(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += EdicaoProdutoWindow_Loaded;
        }

        private void EdicaoProdutoWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _produto = new Produto();
            try
            {
                var dao = new ProdutoDAO();
                _produto = dao.GetById(_id);

                txtId.Text = _produto.Id.ToString();
                txtNome.Text = _produto.Nome;
                txtDescricao.Text = _produto.Descricao;
                txtMarca.Text = _produto.Marca;
                txtValor.Text = _produto.ValorVenda.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            _produto.Nome = txtNome.Text;
            _produto.Descricao = txtDescricao.Text;
            _produto.Marca = txtMarca.Text;
            _produto.ValorVenda = Convert.ToDouble(txtValor.Text);

            Salvar();
        }

        private void Salvar()
        {
            try
            {
                var dao = new ProdutoDAO();

                dao.Update(_produto);

                MessageBox.Show("Produto atualizado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um erro. Não executado!", MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja cancelar?", "Cancelar?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
                this.Close();
        }
    }
}
