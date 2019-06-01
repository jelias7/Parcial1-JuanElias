using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_JuanElias.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoID { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public float Costo { get; set; }
        public float ValorInventario { get; set; }

        public Productos()
        {
            ProductoID = 0;
            Descripcion = string.Empty;
            Existencia = 0;
            Costo = 0.0f;
            ValorInventario = 0.0f;
        }
    }
}
