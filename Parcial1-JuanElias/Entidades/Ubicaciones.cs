using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_JuanElias.Entidades
{
     public class Ubicaciones
    {
        [Key]
        public int UbicacionId { get; set; }
        public string Descripcion { get; set; }

        public Ubicaciones()
        {
            UbicacionId = 0;
            Descripcion = string.Empty;
        }
    }
}
