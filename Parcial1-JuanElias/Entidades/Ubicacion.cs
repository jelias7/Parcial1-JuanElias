using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_JuanElias.Entidades
{
     public class Ubicacion
    {
        [Key]
        public int id { get; set; }
        public string descripcion { get; set; }

        public Ubicacion()
        {
            id = 0;
            descripcion = string.Empty;
        }
    }
}
