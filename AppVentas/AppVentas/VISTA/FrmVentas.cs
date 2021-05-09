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
            using (sistema_ventasEntities db= new sistema_ventasEntities())
            {
                var consultaCliente = db.tb_cliente.ToList();

                CbxCliente.DataSource = consultaCliente;
                CbxCliente.DisplayMember = "NombreCliente ";
                CbxCliente.ValueMember = "iDCliente";


                var consultadocumento = db.tb_documento.ToList();

                //var consultadocumento = (from documento in db.tb_documento
                //                         select new
                //                         {

                //                             documento.iDDocumento,
                //                             documento.nombreDocumento
                //                         }).ToList(); 

                CbxTipoDocumento.DataSource = consultadocumento;
                CbxTipoDocumento.DisplayMember = "nombreDocumento ";
                CbxTipoDocumento.ValueMember = "iDDocumento";
            }
        }
    }
}
