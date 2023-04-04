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
    public partial class FormListar : Form
    {
        private List<FormListar> pessoas = new List<FormListar>();
        private MySqlConnection conexao;
        private MySqlCommand comando;
        public FormListar()
        {
            InitializeComponent();
            Conexao();
            CarregarLista();
        }
                 
        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }
        private void CarregarLista()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Contato", conexao);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            dtTabela.DataSource = dt;
        }
    }
}
