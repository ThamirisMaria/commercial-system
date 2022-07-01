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
    /// Lógica interna para EdicaoClienteWindow.xaml
    /// </summary>
    public partial class EdicaoClienteWindow : Window
    {
        private int _id;
        private Cliente _cliente;
        public EdicaoClienteWindow(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += EdicaoClienteWindow_Loaded;
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            try
            {
                cbSexo.ItemsSource = new SexoDAO().List();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um erro ao tentar carregar os itens da combobox.", MessageBoxButton.OK, MessageBoxImage.Error); ;
            }
        }

        private void EdicaoClienteWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _cliente = new Cliente();
            try
            {
                var dao = new ClienteDAO();
                _cliente = dao.GetById(_id);

                txtId.Text = _cliente.Id.ToString();
                txtNome.Text = _cliente.Nome;
                txtCPF.Text = _cliente.CPF;
                txtRG.Text = _cliente.RG;
                dpDataNascimento.SelectedDate = _cliente.DataNascimento;
                txtEmail.Text = _cliente.Email;
                txtTelefone.Text = _cliente.Telefone;
                txtCelular.Text = _cliente.Celular;
                cbSexo.SelectedValue = _cliente.Sexo.Id;
                txtEstado.Text = _cliente.Endereco.Estado;
                txtCidade.Text = _cliente.Endereco.Cidade;
                txtRua.Text = _cliente.Endereco.Rua;
                txtBairro.Text = _cliente.Endereco.Bairro;
                txtNumero.Text = _cliente.Endereco.Numero.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
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

            _cliente.Endereco = new Endereco(); ;
            _cliente.Endereco.Rua = txtRua.Text;
            _cliente.Endereco.Bairro = txtBairro.Text;
            _cliente.Endereco.Cidade = txtCidade.Text;
            _cliente.Endereco.Estado = txtEstado.Text;

            if (int.TryParse(txtNumero.Text, out int numero))
                _cliente.Endereco.Numero = numero;

            Salvar();
        }

        private void Salvar()
        {
            try
            {
                var dao = new ClienteDAO();

                dao.Update(_cliente);

                MessageBox.Show("Cliente atualizado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
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
