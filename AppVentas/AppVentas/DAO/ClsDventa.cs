using AppVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVentas.DAO
{
    class ClsDventa
    {
        public List<tb_venta> UltimaVenta()
        {
            List<tb_venta> consultarVenta = new List<tb_venta>();
        using (sistema_ventasEntities db = new sistema_ventasEntities()) 
         {
                consultarVenta = db.tb_venta.ToList();
         }
            return consultarVenta;
        }
        public void save(tb_venta ventas ) {
            using (sistema_ventasEntities db = new sistema_ventasEntities()) 
            {

                tb_venta venta = new tb_venta();
                venta.iDDocumento = ventas.iDDocumento;
                venta.iDCliente = ventas.iDCliente;
                venta.iDUsuario = ventas.iDUsuario;
                venta.totalVenta = ventas.totalVenta;
                venta.fecha = ventas.fecha;

                db.tb_venta.Add(venta);
                db.SaveChanges();

            }
        
        }

    }
}
