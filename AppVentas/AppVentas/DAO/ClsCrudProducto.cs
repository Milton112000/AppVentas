using AppVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVentas.DAO
{
    class ClsCrudProducto
    {
        public void Insertar_Producto(String nombre, String precio, String estado)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                tb_producto tablaProducto = new tb_producto();
                tablaProducto.nombreProducto = nombre;
                tablaProducto.precioProducto = precio;
                tablaProducto.estadoProducto = estado;

                db.tb_producto.Add(tablaProducto);
                db.SaveChanges();

            }

        }
        public void Eliminar_Producto(int id)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                tb_producto producto = new tb_producto();
                int eliminar = Convert.ToInt32(id);
                producto = db.tb_producto.Find(eliminar);
                db.tb_producto.Remove(producto);
                db.SaveChanges();


            }

        }
        public void Actulizar_Producto(tb_producto producto)
        {
            try
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    int update = producto.idProducto;
                    tb_producto agregarproducto = db.tb_producto.Where(x => x.idProducto == update).FirstOrDefault();
                    agregarproducto.nombreProducto = producto.nombreProducto;
                    agregarproducto.precioProducto = producto.precioProducto;
                    agregarproducto.estadoProducto = producto.estadoProducto;

                    db.SaveChanges();
                    MessageBox.Show("Actualizados correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }


    }
}
