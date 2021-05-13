using AppVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVentas.DAO
{
    class ClsAcceso
    {

        public int Acceso(string usuario, string pass)
        {
            int variableAcceso = 0;
            using (sistema_ventasEntities bd = new sistema_ventasEntities())
            {
                var consulta = from user in bd.tb_usuario
                               where user.email == usuario && user.contrasena == pass

                               select user;

                if (consulta.Count() > 0)
                {
                    variableAcceso = 1;
                }
            }
            return variableAcceso;
        }




    }
}
