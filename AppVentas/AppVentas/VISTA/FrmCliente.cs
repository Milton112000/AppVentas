using AppVentas.DAO;
using AppVentas.Model;
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
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }
        private bool modificar= false;

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ClsCrudCliente cliente = new ClsCrudCliente();

            cliente.Insertar_Cliente(txtNombreCliente.Text, txtDireccionCliente.Text, txtDuiCliente.Text);
            Carga();
            Vaciar();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            Carga();
        }
        void Carga()
        {
            dataGridView1.Rows.Clear();
            using (sistema_ventasEntities db = new sistema_ventasEntities())

            {
                var lista = db.tb_cliente.ToList();
                foreach (var iteracion in lista)
                {
                    dataGridView1.Rows.Add(iteracion.iDCliente,iteracion.nombreCliente, iteracion.direccionCliente, iteracion.duiCliente);
                }
            }

        }

        void Vaciar() 
        {
            txtId.Text = "";
            txtNombreCliente.Text = "";
            txtDireccionCliente.Text = "";
            txtDuiCliente.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String direccion = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            String dui = dataGridView1.CurrentRow.Cells[3].Value.ToString();
          
            txtId.Text = id;
            txtNombreCliente.Text = nombre;
            txtDireccionCliente.Text = direccion;
            txtDuiCliente.Text = dui;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ClsCrudCliente cliente = new ClsCrudCliente();
            cliente.Eliminar_Clien(Convert.ToInt32(txtId.Text));
            Carga();
            Vaciar();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ClsCrudCliente Clasecliente = new ClsCrudCliente();
            tb_cliente Tablacliente = new tb_cliente();
            try
            {
                Tablacliente.iDCliente = Convert.ToInt32(txtId.Text);
                Tablacliente.nombreCliente = txtNombreCliente.Text;
                Tablacliente.direccionCliente = txtDireccionCliente.Text;
                Tablacliente.duiCliente = txtDuiCliente.Text;

                Clasecliente.Actulizar_Cliente(Tablacliente);

                Carga();
                Vaciar();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
