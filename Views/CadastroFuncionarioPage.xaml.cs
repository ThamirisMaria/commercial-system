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
    /// Interação lógica para CadastroFuncionarioPage.xam
    /// </summary>
    public partial class CadastroFuncionarioPage : Page
    {
        private Funcionario _funcionario;
        
        public CadastroFuncionarioPage()
        {
            InitializeComponent();
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

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            _funcionario = new Funcionario();
            try
            {
                _funcionario.Nome = txtNome.Text;
                _funcionario.CPF = txtCPF.Text;
                _funcionario.RG = txtRG.Text;
                _funcionario.Email = txtEmail.Text;
                _funcionario.Celular = txtCelular.Text;
                _funcionario.Funcao = txtFuncao.Text;

                if (dpDataNascimento.SelectedDate != null)
                    _funcionario.DataNascimento = (DateTime)dpDataNascimento.SelectedDate;

                if (double.TryParse(txtSalario.Text, out double salario))
                    _funcionario.Salario = salario;

                if (cbSexo.SelectedItem != null)
                    _funcionario.Sexo = cbSexo.SelectedItem as Sexo;

                _funcionario.Endereco = new Endereco();
                _funcionario.Endereco.Rua = txtRua.Text;
                _funcionario.Endereco.Bairro = txtBairro.Text;
                _funcionario.Endereco.Cidade = txtCidade.Text;
                _funcionario.Endereco.Estado = txtEstado.Text;

                if (int.TryParse(txtNumero.Text, out int numero))
                    _funcionario.Endereco.Numero = numero;

                FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
                funcionarioDAO.Insert(_funcionario);

                MessageBox.Show("Funcionáro(a) cadastrado com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um erro ao tentar inserir o funcionário. Não executado!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearForm()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtRG.Text = "";
            dpDataNascimento.SelectedDate = null;
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtFuncao.Text = "";
            txtSalario.Text = "";
        }
    }
}
