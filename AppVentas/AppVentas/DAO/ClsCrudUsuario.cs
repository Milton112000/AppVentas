
using AppVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVentas.DAO
{
    class ClsCrudUsuario
    {
        public void Insertar_Usuario(String email, String contraseña)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                tb_usuario tablausuario = new tb_usuario();
                tablausuario.email = email;
                tablausuario.contrasena = contraseña;
                

                db.tb_usuario.Add(tablausuario);
                db.SaveChanges();

            }

        }
        public void Eliminar_Usuario(int id)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                tb_usuario r = new tb_usuario();
                int eliminar = Convert.ToInt32(id);
                r = db.tb_usuario.Find(eliminar);
                db.tb_usuario.Remove(r);
                db.SaveChanges();


            }

        }
        public void Actualizar_Usuario(tb_usuario cliente)
        {
            try
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    int update = cliente.iDUsuario;
                    tb_usuario modificarCliente = db.tb_usuario.Where(x => x.iDUsuario == update).FirstOrDefault();
                    modificarCliente.email = cliente.email;
                    modificarCliente.contrasena = cliente.contrasena;
                   

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
