using Parcial1_JuanElias.DAL;
using Parcial1_JuanElias.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1_JuanElias.BLL
{
    public class ProductosBLL
    {
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
        public static Inventarios LlenaClase()
        {
            Inventarios inventario = new Inventarios();
            inventario.Total = 0;
            inventario.InventarioId = 1;

            return inventario;
        }
        public static bool Guardar(Productos productos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            Inventarios inventario = new Inventarios();
            try
            {
                inventario = InventariosBLL.Buscar(1);
                if (inventario == null)
                {

                    inventario = LlenaClase();
                    paso = InventariosBLL.Guardar(inventario);

                }



                if (contexto.productos.Add(productos) != null)
                    paso = contexto.SaveChanges() > 0;

                inventario.Total += productos.ValorInventario;
                InventariosBLL.Modificar(inventario);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static bool Modificar(Productos productos)
        {
            bool paso = false;
            Productos product = ProductosBLL.Buscar(productos.ProductoId);
            Contexto db = new Contexto();
            try
            {
                float resultado = productos.ValorInventario - product.ValorInventario;

                Inventarios inventario = InventariosBLL.Buscar(1);
                inventario.Total += resultado;
                InventariosBLL.Modificar(inventario);

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
                var Inventario = InventariosBLL.Buscar(1);
                Inventario.Total -= eliminar.ValorInventario;
                InventariosBLL.Modificar(Inventario);

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
        

        public static List<Productos> GetList(Expression<Func<Productos, bool>> productos)
        {
            List<Productos> Lista = new List<Productos>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.productos.Where(productos).ToList();
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
