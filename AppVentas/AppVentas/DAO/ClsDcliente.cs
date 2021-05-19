using AppVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVentas.DAO
{
    class ClsDcliente
    {

        public List<tb_cliente> cargarComboCliente() 
        {
            List<tb_cliente> tbCliente = new List<tb_cliente>();
            using (sistema_ventasEntities db = new sistema_ventasEntities()) 
            {
                tbCliente = db.tb_cliente.ToList();
            }
            return tbCliente;
        }
    }
}
