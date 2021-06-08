using AppVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVentas.DAO
{
    class ClsDdetalle
    {

        public void saveDetalleVenta(tb_detalleVenta detalles) 
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities()) 
            {
                tb_detalleVenta Detalleventa = new tb_detalleVenta();

                Detalleventa.idVenta = detalles.idVenta;
                Detalleventa.idProducto = detalles.idProducto;
                Detalleventa.cantidad = detalles.cantidad;
                Detalleventa.precio = detalles.precio;
                Detalleventa.total = detalles.total;
                db.tb_detalleVenta.Add(Detalleventa);
                db.SaveChanges();


            }


        }


    }
}
