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
        public static bool Guardar(Inventario inventario)
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
        public static bool Modificar(Inventario inventario)
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
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.inventario.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;

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
        public static Inventario Buscar(int id)
        {
            Contexto db = new Contexto();
            Inventario inventario = new Inventario();

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

        public static List<Inventario> GetList(Expression<Func<Inventario, bool>> inventario)
        {
            List<Inventario> Lista = new List<Inventario>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.inventario.Where(inventario).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }
    }
}
