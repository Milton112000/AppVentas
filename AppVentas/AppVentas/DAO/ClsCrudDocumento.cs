using AppVentas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppVentas.DAO
{
    class ClsCrudDocumento
    {

        public void Insertar_Documento(String nombre)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                tb_documento documento = new tb_documento();
                documento.nombreDocumento = nombre;
                

                db.tb_documento.Add(documento);
                db.SaveChanges();

            }

        }
        public void Eliminar_Documento(int id)
        {
            using (sistema_ventasEntities db = new sistema_ventasEntities())
            {
                tb_documento documento = new tb_documento();
                int eliminar = Convert.ToInt32(id);
                documento = db.tb_documento.Find(eliminar);
                db.tb_documento.Remove(documento);
                db.SaveChanges();


            }

        }
        public void Actulizar_Documento(tb_documento documento)
        {
            try
            {
                using (sistema_ventasEntities db = new sistema_ventasEntities())
                {
                    int update = documento.iDDocumento;
                    tb_documento agregardocumento = db.tb_documento.Where(x => x.iDDocumento == update).FirstOrDefault();
                    agregardocumento.nombreDocumento = documento.nombreDocumento;


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
