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

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Productos productos;
            bool paso = false;
            

            productos = LlenaClase();


            if (IDnumericUpDown.Value == 0)
                paso = ProductosBLL.Guardar(productos);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede guardar un producto que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = ProductosBLL.Modificar(productos);
            }

            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();

            int id;
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            if (ProductosBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IDnumericUpDown, "No se puede eliminar un usuario que no existe.");
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            Productos productos = new Productos();
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            productos = ProductosBLL.Buscar(id);

            if (productos != null)
            {
                MessageBox.Show("Producto Encontrado.");
                LlenaCampo(productos);
            }
            else
                MessageBox.Show("Producto no encontrado.");
        }
    }
    
}
