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
    /// Interação lógica para CadastroProdutoPage.xam
    /// </summary>
    public partial class CadastroProdutoPage : Page
    {
        public CadastroProdutoPage()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Produto produto = new Produto();
                produto.Nome = txtNome.Text;
                produto.Descricao = txtDescricao.Text;
                produto.Marca = txtMarca.Text;
                produto.ValorVenda = Convert.ToDouble(txtValor.Text);

                ProdutoDAO produtoDAO = new ProdutoDAO();
                produtoDAO.Insert(produto);

                MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um erro ao tentar inserir o produto. Não executado!", MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
        }

        private void ClearForm()
        {
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtMarca.Text = "";
            txtValor.Text = "";
        }
    }
}
