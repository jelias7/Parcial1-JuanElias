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

namespace Parcial1_JuanElias
{
    public partial class rProductos : Form
    {
        public rProductos()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            CostotextBox.Text = string.Empty;
            ExistenciatextBox.Text = string.Empty;
            ValorInventariotextBox.Text = string.Empty;
            MyErrorProvider.Clear();
        }
        private Productos LlenaClase()
        {
            Productos productos = new Productos();
            productos.ProductoID = Convert.ToInt32(IDnumericUpDown.Value);
            productos.Descripcion = DescripciontextBox.Text;
            productos.Costo = Convert.ToInt32(CostotextBox.Text);
            productos.Existencia = Convert.ToInt32(ExistenciatextBox.Text);
            productos.ValorInventario = Convert.ToInt32(ValorInventariotextBox.Text);
            return productos;
        }

        private void LlenaCampo(Productos productos)
        {
            IDnumericUpDown.Value = productos.ProductoID;
            DescripciontextBox.Text = productos.Descripcion;
            ExistenciatextBox.Text = productos.Existencia.ToString();
            CostotextBox.Text = productos.Costo.ToString();
            ValorInventariotextBox.Text = productos.ValorInventario.ToString();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Productos productos = ProductosBLL.Buscar((int)IDnumericUpDown.Value);

            return (productos != null);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
