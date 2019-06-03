using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_JuanElias.Entidades
{
    public class Inventarios
    {
        public int id { get; set; }
        public float total { get; set; }

        public Inventarios()
        {
            id = 0;
            total = 0;
        }
    }
}
