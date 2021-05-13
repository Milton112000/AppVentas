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
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
            Carga();
        }
        void Carga()
        {
            dataGridView1.Rows.Clear();
            using (sistema_ventasEntities db = new sistema_ventasEntities())

            {
                var lista = db.tb_producto.ToList();
                foreach (var iteracion in lista)
                {
                    dataGridView1.Rows.Add(iteracion.idProducto, iteracion.nombreProducto, iteracion.precioProducto, iteracion.estadoProducto);
                }
            }

        }

        void Vaciar()
        {
            txtId.Text = "";
            txtNombreProducto.Text = "";
            txtPrecioProducto.Text = "";
            txtEstadoProducto.Text = "";
        }


        private void FrmProducto_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ClsCrudProducto producto = new ClsCrudProducto();

            producto.Insertar_Producto(txtNombreProducto.Text, txtPrecioProducto.Text, txtEstadoProducto.Text);
            Carga();
            Vaciar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ClsCrudProducto producto = new ClsCrudProducto();
            producto.Eliminar_Producto(Convert.ToInt32(txtId.Text));
            Carga();
            Vaciar();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ClsCrudProducto ClaseProducto = new ClsCrudProducto();
            tb_producto TablaProducto = new tb_producto();
            try
            {
                TablaProducto.idProducto = Convert.ToInt32(txtId.Text);
                TablaProducto.nombreProducto = txtNombreProducto.Text;
                TablaProducto.precioProducto = txtPrecioProducto.Text;
                TablaProducto.estadoProducto = txtEstadoProducto.Text;

                ClaseProducto.Actulizar_Producto(TablaProducto);

                Carga();
                Vaciar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String precio = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            String estado = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            txtId.Text = id;
            txtNombreProducto.Text = nombre;
            txtPrecioProducto.Text = precio;
            txtEstadoProducto.Text = estado;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
