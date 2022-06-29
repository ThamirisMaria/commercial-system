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
    /// Interação lógica para CadastroClientePage.xam
    /// </summary>
    public partial class CadastroClientePage : Page
    {
        private Cliente _cliente;
        public CadastroClientePage()
        {
            InitializeComponent();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            try
            {
                cbSexo.ItemsSource = new SexoDAO().List();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um erro ao tentar carregar os itens da combobox.", MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            _cliente = new Cliente();
            try
            {
                _cliente.Nome = txtNome.Text;
                _cliente.CPF = txtCPF.Text;
                _cliente.RG = txtRG.Text;
                _cliente.Email = txtEmail.Text;
                _cliente.Telefone = txtTelefone.Text;
                _cliente.Celular = txtCelular.Text;

                if (dpDataNascimento.SelectedDate != null)
                    _cliente.DataNascimento = (DateTime)dpDataNascimento.SelectedDate;

                if (cbSexo.SelectedItem != null)
                    _cliente.Sexo = cbSexo.SelectedItem as Sexo;

                _cliente.Endereco = new Endereco();
                _cliente.Endereco.Rua = txtRua.Text;
                _cliente.Endereco.Bairro = txtBairro.Text;
                _cliente.Endereco.Cidade = txtCidade.Text;
                _cliente.Endereco.Estado = txtEstado.Text;

                if (int.TryParse(txtNumero.Text, out int numero))
                    _cliente.Endereco.Numero = numero;

                ClienteDAO clienteDAO = new ClienteDAO();
                clienteDAO.Insert(_cliente);

                MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um erro ao tentar inserir o cliente. Não executado!", MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
        }
        
        private void ClearForm()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtRG.Text = "";
            dpDataNascimento.SelectedDate = null;
            txtEmail.Text = "";
            txtTelefone.Text = "";
            txtCelular.Text = "";
            txtRua.Text = "";
            txtNumero.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
        }
    }
}
