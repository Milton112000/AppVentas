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

namespace AppVentas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {

            ClsAcceso acces = new ClsAcceso();

            int valor = acces.acceso(txtUsuario.Text,txtPaswork.Text);
            if (valor == 1)
            {
                MessageBox.Show("Welcome");
            }
            else
            
                MessageBox.Show("error");
            }

        }
    }

