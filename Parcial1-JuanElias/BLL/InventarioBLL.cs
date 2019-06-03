using Parcial1_JuanElias.DAL;
using Parcial1_JuanElias.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_JuanElias.BLL
{
    public class InventarioBLL
    {
        public static bool Guardar(Inventarios inventario)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.inventario.Add(inventario) != null)
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
        public static bool Modificar(Inventarios inventario)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(inventario).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
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
        public static Inventarios Buscar(int id)
        {
            Contexto db = new Contexto();
            Inventarios inventario = new Inventarios();

            try
            {
                inventario = db.inventario.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return inventario;
        }

    }
}
