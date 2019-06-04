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
    public class UbicacionesBLL
    {
        public static Ubicaciones Buscar(int id)
        {
            Contexto db = new Contexto();
            Ubicaciones ubicacion = new Ubicaciones();

            try
            {
                ubicacion = db.ubicacion.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return ubicacion;
        }
        public static bool Guardar(Ubicaciones ubicacion)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {
                if (db.ubicacion.Add(ubicacion) != null)
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
        public static bool Modificar(Ubicaciones ubicacion)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {

                db.Entry(ubicacion).State = EntityState.Modified;
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
                var eliminar = db.ubicacion.Find(id);

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


        public static List<Ubicaciones> GetList(Expression<Func<Ubicaciones, bool>> ubicacion)
        {
            List<Ubicaciones> Lista = new List<Ubicaciones>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.ubicacion.Where(ubicacion).ToList();
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
