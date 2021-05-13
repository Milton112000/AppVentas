using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppVentas.DAO;
using AppVentas.Model;

namespace AppVentas.VISTA
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            
        }

      


       
    
        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            FrmCliente cliente = new FrmCliente();
            cliente.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FrmProducto producto = new FrmProducto();
            producto.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmUsuario usuario = new FrmUsuario();
            usuario.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FrmDocumeto documeto = new FrmDocumeto();
            documeto.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            FrmCliente cliente = new FrmCliente();
            cliente.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FrmProducto producto = new FrmProducto();
            producto.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FrmDocumeto documeto = new FrmDocumeto();
            documeto.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FrmUsuario usuario = new FrmUsuario();
            usuario.Show();
        }
    }
}
