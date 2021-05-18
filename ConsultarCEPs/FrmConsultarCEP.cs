using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultarCEPs
{
    public partial class FrmConsultarCEP : Form
    {
        public FrmConsultarCEP()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            WSCorreios.AtendeClienteClient ws = new WSCorreios.AtendeClienteClient();

            if (!string.IsNullOrEmpty(txtCEP.Text))
            {

                //Verifica se cep é valido e realiza consulta pelo webservice
                //retornando endereco do cep
                try
                {
                    var endereco = ws.consultaCEPAsync(txtCEP.Text.Trim());
                    
                    txtEstado.Text = endereco.Result.@return.uf;
                    txtCidade.Text = endereco.Result.@return.cidade;
                    txtBairro.Text = endereco.Result.@return.bairro;
                    txtRua.Text = endereco.Result.@return.end;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Insira um CPF válido...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtEstado.Clear();
            txtCidade.Clear();
            txtBairro.Clear();
            txtRua.Clear();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
