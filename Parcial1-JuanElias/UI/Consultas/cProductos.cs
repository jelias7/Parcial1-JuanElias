using Parcial1_JuanElias.BLL;
using Parcial1_JuanElias.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1_JuanElias.UI.Consultas
{
    public partial class cProductos : Form
    {
        public cProductos()
        {
            InitializeComponent();
        }

        private void Refrescarbutton_Click(object sender, EventArgs e)
        {
            Inventarios inventario = InventariosBLL.Buscar(1);
            double total = inventario.Total;
            ValorTotaltextBox.Text = total.ToString();
        }
    }
}
