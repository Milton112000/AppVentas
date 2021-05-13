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
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            Carga();
        }
        void Carga()
        {
            dataGridView1.Rows.Clear();
            using (sistema_ventasEntities db = new sistema_ventasEntities())

            {
               
                foreach (var iteracion in db.tb_usuario.ToList())
                {
                    dataGridView1.Rows.Add(iteracion.iDUsuario,iteracion.email,iteracion.contrasena);
                }
            }

        }

        void Vaciar()
        {
            txtId.Text = "";
            txtEmailUsuario.Text = "";
            txtPasworkUsuario.Text = "";
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ClsCrudUsuario usuario = new ClsCrudUsuario();
            usuario.Insertar_Usuario(txtEmailUsuario.Text,txtPasworkUsuario.Text);
            Carga();
            Vaciar();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ClsCrudUsuario usuario = new ClsCrudUsuario();
            usuario.Eliminar_Usuario(Convert.ToInt32(txtId.Text));
            Carga();
            Vaciar();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String email = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String paswork= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            

            txtId.Text = id;
            txtEmailUsuario.Text = email;
            txtPasworkUsuario.Text = paswork;
        
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            ClsCrudUsuario ClaseUsuario = new ClsCrudUsuario();
            tb_usuario Tablausuario = new tb_usuario();
            try
            {
                Tablausuario.iDUsuario = Convert.ToInt32(txtId.Text);
                Tablausuario.email = txtEmailUsuario.Text;
                Tablausuario.contrasena = txtPasworkUsuario.Text;
               ;

                ClaseUsuario.Actualizar_Usuario(Tablausuario);

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
