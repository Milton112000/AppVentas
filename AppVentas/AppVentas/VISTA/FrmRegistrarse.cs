using AppVentas.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVentas.VISTA
{
    public partial class FrmRegistrarse : Form
    {
        public FrmRegistrarse()
        {
            InitializeComponent();
        }
        public void vaciar() 
        {
            txtEmailUsuario.Text = "";
            txtPasworkUsuario.Text = "";
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try {
                ClsCrudUsuario usuario = new ClsCrudUsuario();
                usuario.Insertar_Usuario(txtEmailUsuario.Text, txtPasworkUsuario.Text);
                MessageBox.Show("Se ha Registrado Correctamente ");
                vaciar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmRegistrarse_Load(object sender, EventArgs e)
        {

        }
    }
}
