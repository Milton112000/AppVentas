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

        private void FrmVentas_Load(object sender, EventArgs e)
        {

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
    }
}
