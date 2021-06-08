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
    public partial class FrmGestionarProducto : Form
    {
        public FrmGestionarProducto()
        {
            InitializeComponent();
            GestionarDatos();
        }
        void GestionarDatos()
        {
            var clsPro = new ClsDproducto();
            dataGridView1.Rows.Clear();

            foreach (var lista in clsPro.Cargarproducto(txtFiltro.Text)) 
            {
                dataGridView1.Rows.Add(lista.idProducto,lista.nombreProducto,lista.precioProducto);
            
            
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            GestionarDatos();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {




            

        }
        void envio() 
        {
            String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String precio = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            FrmMenu.ventas.txtCodigoProducto.Text = id;
            FrmMenu.ventas.txtNombreProducto.Text = nombre;
            FrmMenu.ventas.txtPrecioProducto.Text = precio;
            FrmMenu.ventas.txtCantidad.Focus();
            this.Close();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            envio();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            
            {
                envio();

            }
        }

        private void FrmGestionarProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
