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
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
        }
        void ultimaventa()
        {

            var consultaVenta = new ClsDventa();
            int lista = 0;
            foreach (var list in consultaVenta.UltimaVenta())
            {
                lista = list.iDVenta;
            }
            lista++;
            txtUltimaVeta.Text = lista.ToString();
        }


        private void FrmVentas_Load(object sender, EventArgs e)
        {
            ultimaventa();

           

            ClsDcliente clsCliente = new ClsDcliente();

                CbxCliente.DataSource = clsCliente.cargarComboCliente();
                CbxCliente.DisplayMember = "NombreCliente ";
                CbxCliente.ValueMember = "iDCliente";


            //var consultadocumento = db.tb_documento.ToList();

            //var consultadocumento = (from documento in db.tb_documento
            //                         select new
            //                         {

            //                             documento.iDDocumento,
            //                             documento.nombreDocumento
            //                         }).ToList(); 

                  ClsDdocumento clsDocumento = new ClsDdocumento();
                CbxTipoDocumento.DataSource = clsDocumento.cargarComboDocumento();
                CbxTipoDocumento.DisplayMember = "nombreDocumento ";
                CbxTipoDocumento.ValueMember = "iDDocumento";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGestionarProducto gestionar = new FrmGestionarProducto();
            gestionar.Show();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            calcular();
        }
        void calcular() {

            try
            {
                Double precio, cantidad, total;

                cantidad = Convert.ToDouble(txtCantidad.Text);
                precio = Convert.ToDouble(txtCantidad.Text);
                total = precio * cantidad;
                txtTotal.Text = total.ToString();
            }
            catch (Exception ex)
            {
                if (txtCantidad.Text.Equals(""))
                {
                    txtCantidad.Text.Equals("1");
                    txtCantidad.SelectAll();
                }
            }
        }
        void calcularTotal()
        {

            Double suma = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //String precio = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                String datosAOperarTotal = dataGridView1.Rows[i].Cells[4].Value.ToString();
                Double datoConvertidos = Convert.ToDouble(datosAOperarTotal);


                suma += datoConvertidos;
                txtTotalFinal.Text = suma.ToString();
               
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            calcular();
            dataGridView1.Rows.Add(txtCodigoProducto.Text,txtNombreProducto.Text,txtPrecioProducto.Text,txtCantidad.Text,txtTotal.Text);
            calcularTotal();
            
                txtCodigoProducto.Text = "";
                txtNombreProducto.Text = "";
                txtPrecioProducto.Text = "";
                txtCantidad.Text = "";
                txtTotal.Text = "";
                
            

            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
            int ultimafila = dataGridView1.Rows.Count - 1;
            dataGridView1.FirstDisplayedScrollingRowIndex = ultimafila;
            dataGridView1.Rows[ultimafila].Selected = true;

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBuscarProducto.Text.Equals(""))
            {

                if (e.KeyChar == 13)
                {
                    btnBuscar.PerformClick();
                    e.Handled = true;
                    //txtCantidad.Focus();
                }
            }
            else 
            {
                if (e.KeyChar==13) 
                {
                    ClsDproducto prod = new ClsDproducto();
                    var busqueda = prod.BuscarProducto(Convert.ToInt32(txtBuscarProducto.Text)); ;
                    foreach (var iterar in busqueda)
                    {
                        txtCodigoProducto.Text = iterar.idProducto.ToString();
                        txtNombreProducto.Text = iterar.nombreProducto.ToString();
                        txtPrecioProducto.Text = iterar.precioProducto.ToString();
                        txtCantidad.Text = "1";
                        txtCantidad.Focus();
                        txtBuscarProducto.Text = "";


                    }


                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13) 
            {
                e.Handled = true;
                btnAgregar.PerformClick();
                txtBuscarProducto.Focus();
            }
        }

        private void txtBuscarProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBuscarProducto.Text.Equals("")) 
            {
                if (e.KeyChar == 13)
                {
                    
                    btnBuscar.PerformClick();
                    e.Handled = true;
                    //txtCantidad.Focus();

                }

            }else 
            {
                ClsDproducto prod = new ClsDproducto();
                var busqueda = prod.BuscarProducto(Convert.ToInt32(txtBuscarProducto.Text));
                if (busqueda.Count<1) {

                    MessageBox.Show("el resultado no existe");
                    txtBuscarProducto.Text = "";
                }
                foreach (var iterar in busqueda)
                {
                    txtCodigoProducto.Text = iterar.idProducto.ToString();
                    txtNombreProducto.Text = iterar.nombreProducto.ToString();
                    txtPrecioProducto.Text = iterar.precioProducto.ToString();
                    txtCantidad.Text = "1";
                    txtCantidad.Focus();
                    txtBuscarProducto.Text = "";

                }
            
            
            }
            

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try { 
            ClsDventa ventas = new ClsDventa();
            tb_venta venta = new tb_venta();

            venta.iDDocumento = Convert.ToInt32(CbxTipoDocumento.SelectedValue.ToString());
            venta.iDCliente = Convert.ToInt32(CbxCliente.SelectedValue.ToString());
            venta.iDUsuario = 1;
            venta.totalVenta = Convert.ToDecimal(txtTotalFinal.Text);
            venta.fecha = Convert.ToDateTime(dateTimePicker1.Text);
            ventas.save(venta);

                ClsDdetalle detalle = new ClsDdetalle();
                tb_detalleVenta thDetalle = new tb_detalleVenta(); 
                foreach (DataGridViewRow dtgv in dataGridView1.Rows) 
                {
                    thDetalle.idVenta = Convert.ToInt32(txtUltimaVeta.Text);
                    thDetalle.idProducto = Convert.ToInt32(dtgv.Cells[0].Value.ToString());
                    thDetalle.cantidad = Convert.ToInt32(dtgv.Cells[3].Value.ToString());
                    thDetalle.precio = Convert.ToDecimal(dtgv.Cells[2].Value.ToString());
                    thDetalle.total = Convert.ToDecimal(dtgv.Cells[4].Value.ToString());
                    detalle.saveDetalleVenta(thDetalle);


                }
                ultimaventa();
                dataGridView1.Rows.Clear();
                txtTotalFinal.Text = "";

                MessageBox.Show("save");
            }
            catch (Exception ex) 
            {
                MessageBox.Show("error"+ ex );
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calcularTotal();
        }
    }
}
