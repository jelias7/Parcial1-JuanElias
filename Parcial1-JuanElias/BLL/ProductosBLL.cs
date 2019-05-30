using Parcial1_JuanElias.DAL;
using Parcial1_JuanElias.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_JuanElias.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos productos)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.productos.Add(productos) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
    }
}
