using AppVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVentas.DAO
{
    class ClsDdocumento
    {
        public List<tb_documento> cargarComboDocumento()
        {
            List<tb_documento> tbDocumento = new List<tb_documento>();
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                tbDocumento = db.tb_documento.ToList();
            }
            return tbDocumento;
        }


    }
}
