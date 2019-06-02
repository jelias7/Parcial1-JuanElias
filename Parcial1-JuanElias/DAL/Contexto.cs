using Parcial1_JuanElias.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_JuanElias.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Productos> productos { get; set; }
        public DbSet<Inventario> inventario { get; set; }
        public Contexto() : base("ConStr") { }
    }
}
