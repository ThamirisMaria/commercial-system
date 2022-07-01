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
    /// Lógica interna para EdicaoFuncionarioWindow.xaml
    /// </summary>
    public partial class EdicaoFuncionarioWindow : Window
    {
        private int _id;
        private Funcionario _funcionario;

        public EdicaoFuncionarioWindow(int id)
        {
            _id = id;
            InitializeComponent();
            Loaded += EdicaoFuncionarioWindow_Loaded;
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

        private void EdicaoFuncionarioWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _funcionario = new Funcionario();
            try
            {
                var dao = new FuncionarioDAO();
                _funcionario = dao.GetById(_id);

                txtId.Text = _funcionario.Id.ToString();
                txtNome.Text = _funcionario.Nome;
                txtCPF.Text = _funcionario.CPF;
                txtRG.Text = _funcionario.RG;
                dpDataNascimento.SelectedDate = _funcionario.DataNascimento;
                txtEmail.Text = _funcionario.Email;
                txtCelular.Text = _funcionario.Celular;
                txtFuncao.Text = _funcionario.Funcao;
                txtSalario.Text = _funcionario.Salario.ToString();
                if(_funcionario.Sexo != null)
                {
                    cbSexo.SelectedValue = _funcionario.Sexo.Id;
                }
                txtEstado.Text = _funcionario.Endereco.Estado;
                txtCidade.Text = _funcionario.Endereco.Cidade;
                txtRua.Text = _funcionario.Endereco.Rua;
                txtBairro.Text = _funcionario.Endereco.Bairro;
                txtNumero.Text = _funcionario.Endereco.Numero.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exceção", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
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

            Salvar();
        }

        private void Salvar()
        {
            try
            {
                var dao = new FuncionarioDAO();

                dao.Update(_funcionario);

                MessageBox.Show("Funcionário atualizado com sucesso!", "Sucesso!", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ocorreu um erro. Não executado!", MessageBoxButton.OK, MessageBoxImage.Error);
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
