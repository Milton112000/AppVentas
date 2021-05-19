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
        public List<tb_producto> cargarProducto(String filtro)
        {
            List<tb_producto> tbProducto = new List<tb_producto>();
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                tbProducto = (from litado in db.tb_producto
                              where litado.nombreProducto.Contains(filtro)
                              select litado).ToList();
            }
            return tbProducto;
        }
    }
}
