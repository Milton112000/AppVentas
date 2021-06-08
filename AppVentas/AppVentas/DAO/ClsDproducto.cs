using AppVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVentas.DAO
{
    class ClsDproducto
    {
        public List<tb_producto> Cargarproducto(String filto)
        {
            List<tb_producto> tbProducto = new List<tb_producto>();
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                tbProducto = (from litado in db.tb_producto
                              where litado.nombreProducto.Contains(filto)
                              select litado).ToList();
            }
            return tbProducto;
        }
        public List<tb_producto> BuscarProducto (int codigo)
        {
            List<tb_producto> tbProducto = new List<tb_producto>();
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                tbProducto = (from litado in db.tb_producto
                              where litado.idProducto==codigo
                              select litado).ToList();
            }
            return tbProducto;
        }
       
        
    }
}
