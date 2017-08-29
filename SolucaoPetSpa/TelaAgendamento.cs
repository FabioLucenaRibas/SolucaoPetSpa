using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca.ClassesBasicas;
using SolucaoPetSpa.ServiceReference1;
using System.IO;


namespace SolucaoPetSpa
{
    public partial class TelaAgendamento : Form
    {
        public TelaAgendamento()
        {
            InitializeComponent();

            ListarComboBoxS();
            ListarComboBoxC();
        }
        private void ListarComboBox(Cliente A)
        {

            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            try
            {
                List<Animal> ListaComboBox = new Service1Client().SelecionaComboBoxAnimal(A).ToList();
                comboSource.Add(0, "- Escolha -");
                foreach (Animal An in ListaComboBox)
                {
                    comboSource.Add(An.CodigoAnimal, An.Nome);
                }
                comboBoxAnimal.DataSource = new BindingSource(comboSource, null);
                comboBoxAnimal.DisplayMember = "Value";
                comboBoxAnimal.ValueMember = "Key";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListarComboBoxS()
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            try
            {
                List<Servico> ListaComboBox = new Service1Client().SelecionaComboBoxServico().ToList();
                comboSource.Add(0, "- Escolha -");
                foreach (Servico S in ListaComboBox)
                {
                    comboSource.Add(S.CodigoServico, S.NomeServico);
                }
                comboBoxServico.DataSource = new BindingSource(comboSource, null);
                comboBoxServico.DisplayMember = "Value";
                comboBoxServico.ValueMember = "Key";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ListarComboBoxC()
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            try
            {
                List<Cliente> ListaComboBox = new Service1Client().SelecionaComboBoxCliente().ToList();
                comboSource.Add("0", "- Escolha -");
                foreach (Cliente C in ListaComboBox)
                {
                    comboSource.Add(C.Cpf, C.Nome);
                }
                CPF.DataSource = new BindingSource(comboSource, null);
                CPF.DisplayMember = "Value";
                CPF.ValueMember = "Key";

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void CPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }


       


        private void OkCPF_Click_1(object sender, EventArgs e)
        {
            Cliente A = new Cliente();
            A.Cpf = ((KeyValuePair<string, string>)CPF.SelectedItem).Key;
            ListarComboBox(A);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Agenda A = new Agenda();
                A.Cliente.Cpf = ((KeyValuePair<string, string>)CPF.SelectedItem).Key;
                A.Animal.CodigoAnimal = ((KeyValuePair<int, string>)comboBoxAnimal.SelectedItem).Key;
                A.Servico.CodigoServico = ((KeyValuePair<int, string>)comboBoxServico.SelectedItem).Key;
                A.Data = maskedTextBox1.Text;
                A.Hora = maskedTextBox2.Text;
                if ((A.Animal.CodigoAnimal) == 0)
                {
                    MessageBox.Show("Escolha um Animal");
                }
                else
                {
                    new Service1Client().InserirAgenda(A);
                    maskedTextBox1.Clear();
                    maskedTextBox2.Clear();
                    MessageBox.Show("Agenda Cadastrada com sucesso");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
