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
using AppVentas.VISTA;

namespace AppVentas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
           
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            ClsAcceso acceso = new ClsAcceso();
            int valor = acceso.Acceso(txtUsuario.Text, txtPaswork.Text);

            if (valor == 1)
            {
                MessageBox.Show("Inicio de sesion valido", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmMenu frm = new FrmMenu();
                frm.lblCorreo.Text = txtUsuario.Text;
                frm.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Tu correo o clave son incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FrmRegistrarse regis = new FrmRegistrarse();
            regis.Show();
        }
    }
    }

