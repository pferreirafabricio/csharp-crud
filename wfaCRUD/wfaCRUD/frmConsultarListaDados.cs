using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace wfaCRUD
{
    public partial class frmConsultarListaDados : Form
    {
        public MySqlConnection objCnx = new MySqlConnection();
        public MySqlCommand objCmd = new MySqlCommand();
        public MySqlDataReader objDados;

        public frmConsultarListaDados()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            objCnx.Close();
            Close();
        }

        private void frmConsultarListaDados_Load(object sender, EventArgs e)
        {
            try
            {
                objCnx.ConnectionString = "Server=localhost;Database=bdaula;user=root;pwd=root";
                objCnx.Open();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro na conexão com o BD!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string strSQL = "select * from tblagenda order by agdnome";

                objCmd.Connection = objCnx;
                objCmd.CommandText = strSQL;
                objDados = objCmd.ExecuteReader();

                if (objDados.HasRows)
                {
                    dgvListaDados.Rows.Clear();

                    while (objDados.Read())
                    {
                        dgvListaDados.Rows.Add(objDados["agdid"].ToString(), objDados["agdcpf"].ToString(), objDados["agdnome"].ToString(), objDados["agdemail"].ToString(), objDados["agdtelefone"].ToString());
                    }
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
