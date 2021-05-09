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

        public int acceso(String usuario, String paswork) 
        {
            int variabledeAcceso = 0;
            using (sistema_ventasEntities db = new sistema_ventasEntities())  
            {
                var consulta = from user in db.tb_usuario
                               where user.email == usuario && user.contrasena == paswork
                               select user;

                if (consulta.Count()>0) 
                {
                    variabledeAcceso = 1;
                }



            
            }


                return variabledeAcceso;
        }




    }
}
