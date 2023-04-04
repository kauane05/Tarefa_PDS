using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppContatoForm
{
    public partial class ContatoForm : Form
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;

        public ContatoForm()
        {
            InitializeComponent();

            Conexao();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand(); //conexão com o Banco de Dados

            conexao.Open();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(dateDataNascimento.Value.ToString());

                if ( ! rdSexo1.Checked && ! rdSexo2.Checked)
                {
                    MessageBox.Show("Marque uma opção");
                }
                else
                {
                    var nome = txtNome.Text;
                    var email = txtEmail.Text;
                    var data_nasc = dateDataNascimento.Value;
                    var telefone = txtTelefone.Text;

                    var sexo = "Feminino";

                    if (rdSexo1.Checked)
                    {
                        sexo = "Masculino";
                    }

                    string query = "INSERT INTO Contato(nome_con, email_con, data_nasc_con, sexo_con, telefone_con) VALUES (@_nome, @_email, @_dataNascimento, @_sexo, @_telefone )";
                    var comando = new MySqlCommand(query, conexao);

                    comando.Parameters.AddWithValue("@_nome", nome);
                    comando.Parameters.AddWithValue("@_email", email);
                    comando.Parameters.AddWithValue("@_sexo", sexo);
                    comando.Parameters.AddWithValue("@_dataNascimento", data_nasc);
                    comando.Parameters.AddWithValue("@_telefone", telefone);
                    
                    
                    comando.ExecuteNonQuery();

                  var opcao =  MessageBox.Show("As informações foram salvas com sucesso!\n" + "Deseja realizar um novo cadastro?","Informação",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                    if (opcao == DialogResult.Yes)
                    {
                        LimparInputs();
                        
                    }
                    else
                    {
                        this.Close();
                    }

                   
                }
                
              
            }
            catch(Exception ex) 
            {
                //MessageBox.Show("Ocorreram erros ao tentar salvar os dados!" +
                //    $"Contate o suporte do sistema (CAD 25)");

                MessageBox.Show(ex.Message);
            }
            
        }

        private void LimparInputs()
        {
          txtEmail.Clear();
          txtTelefone.Clear();
          txtNome.Clear();
          dateDataNascimento.Clear();
          rdSexoGroup.Clear();
                    
        }
    }
}
