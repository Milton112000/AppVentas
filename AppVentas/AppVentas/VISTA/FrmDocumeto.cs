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
    public partial class FrmDocumeto : Form
    {
        public FrmDocumeto()
        {
            InitializeComponent();
            carga();
            vaciar();
        }
        public void carga()
            
        {
         using (sistema_ventasEntities db = new sistema_ventasEntities()) 
            { 
            dataGridView1.Rows.Clear();
             foreach (var interacion in db.tb_documento.ToList())
             {
                    dataGridView1.Rows.Add(interacion.iDDocumento,interacion.nombreDocumento);
             }
            }

        }
        public void vaciar()
        {
            txtId.Text = "";
            txtNombreDocumento.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ClsCrudDocumento documento = new ClsCrudDocumento();
            documento.Insertar_Documento(txtNombreDocumento.Text);
            carga();
            vaciar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ClsCrudDocumento documento = new ClsCrudDocumento();
            documento.Eliminar_Documento(Convert.ToInt32(txtId.Text));
            carga();
            vaciar();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ClsCrudDocumento ClaseDocumento = new ClsCrudDocumento();
            tb_documento TablaDocumento = new tb_documento();

            TablaDocumento.iDDocumento = Convert.ToInt32(txtId.Text);
            TablaDocumento.nombreDocumento = txtNombreDocumento.Text;

            ClaseDocumento.Actulizar_Documento(TablaDocumento);
            carga();
            vaciar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            txtId.Text = id;
            txtNombreDocumento.Text = nombre;
        }
    }
}
