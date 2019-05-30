using Parcial1_JuanElias.DAL;
using Parcial1_JuanElias.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public static bool Modificar(Productos productos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(productos).State = EntityState.Modified;
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
                var eliminar = db.productos.Find(id);
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
        public static Productos Buscar(int id)
        {
            Contexto db = new Contexto();
            Productos productos = new Productos();

            try
            {
                productos = db.productos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return productos;
        }
    }
}
