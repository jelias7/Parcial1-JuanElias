﻿using Parcial1_JuanElias.BLL;
using Parcial1_JuanElias.DAL;
using Parcial1_JuanElias.Entidades;
using Parcial1_JuanElias.UI.Registros;
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
            ComboBox();
        }
        private void ComboBox()
        {
            var list = new List<Ubicaciones>();
            list = UbicacionesBLL.GetList(p => true);
            UbicacioncomboBox.DataSource = list;
            UbicacioncomboBox.DisplayMember = "Descripcion";
            UbicacioncomboBox.ValueMember = "UbicacionId";
        }
        private void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            CostonumericUpDown.Value = 0;
            ExistencianumericUpDown.Value = 0;
            ValorInventariotextBox.Text = string.Empty;
            MyErrorProvider.Clear();
        }
        private Productos LlenaClase()
        {
            Productos productos = new Productos();
            productos.ProductoId = Convert.ToInt32(IDnumericUpDown.Value);
            productos.Descripcion = DescripciontextBox.Text;
            productos.Costo = Convert.ToSingle(CostonumericUpDown.Value);
            productos.Existencia = Convert.ToInt32(ExistencianumericUpDown.Value);
            productos.ValorInventario = Convert.ToSingle(ValorInventariotextBox.Text);
            return productos;
        }

        private void LlenaCampo(Productos productos)
        {
            IDnumericUpDown.Value = productos.ProductoId;
            DescripciontextBox.Text = productos.Descripcion;
            ExistencianumericUpDown.Value = productos.Existencia;
            CostonumericUpDown.Value = Convert.ToDecimal(productos.Costo);
            ValorInventariotextBox.Text = productos.ValorInventario.ToString();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Productos productos = ProductosBLL.Buscar((int)IDnumericUpDown.Value);

            return (productos != null);
        }

        private bool ValidarGuardar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (DescripciontextBox.Text == string.Empty)
            {
                MyErrorProvider.SetError(DescripciontextBox, "El Campo no puede estar vacio.");
                DescripciontextBox.Focus();
                paso = false;
            }
            if (CostonumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(CostonumericUpDown, "El Campo no puede ser 0");
                CostonumericUpDown.Focus();
                paso = false;
            }
            if (ExistencianumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(ExistencianumericUpDown, "El Campo no puede ser 0");
                ExistencianumericUpDown.Focus();
                paso = false;
            }
            if (Repeticion(DescripciontextBox.Text))
            {
                MessageBox.Show("No se puede ingresar un producto ya creado");
                DescripciontextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool ValidarEliminar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if(IDnumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(IDnumericUpDown, "Busque un producto y luego eliminelo.");
                IDnumericUpDown.Focus();
                paso = false;
            }
            return paso;
        }
        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Productos productos;
            
            bool paso = false;
            if (!ValidarGuardar())
                return;

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
            {
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            MyErrorProvider.Clear();
            if (!ValidarEliminar())
                return;

            int id;
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            if (ProductosBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
                MyErrorProvider.SetError(IDnumericUpDown, "No se puede eliminar un producto que no existe.");
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

        private void Addbutton_Click(object sender, EventArgs e)
        {
            rUbicacion ub = new rUbicacion();
            ub.Show();
        }

        private void CostonumericUpDown_ValueChanged(object sender, EventArgs e)
        {

            if (CostonumericUpDown.Value > 0 && ExistencianumericUpDown.Value > 0)
                ValorInventariotextBox.Text = Convert.ToString(Convert.ToSingle(CostonumericUpDown.Value) * Convert.ToInt32(ExistencianumericUpDown.Value));

            if (CostonumericUpDown.Value > 0 && ExistencianumericUpDown.Value == 0)
                ValorInventariotextBox.Text = "0.0";

            if (CostonumericUpDown.Value == 0 && ExistencianumericUpDown.Value > 0)
                ValorInventariotextBox.Text = "0.0";

            if (CostonumericUpDown.Value == 0 && ExistencianumericUpDown.Value == 0)
                ValorInventariotextBox.Text = "0.0";
        }

        private void ExistencianumericUpDown_ValueChanged(object sender, EventArgs e)
        {

            if (CostonumericUpDown.Value > 0 && ExistencianumericUpDown.Value > 0)
                ValorInventariotextBox.Text = Convert.ToString(Convert.ToSingle(CostonumericUpDown.Value) * Convert.ToInt32(ExistencianumericUpDown.Value));

            if (CostonumericUpDown.Value > 0 && ExistencianumericUpDown.Value == 0)
                ValorInventariotextBox.Text = "0.0";

            if (CostonumericUpDown.Value == 0 && ExistencianumericUpDown.Value > 0)
                ValorInventariotextBox.Text = "0.0";

            if (CostonumericUpDown.Value == 0 && ExistencianumericUpDown.Value == 0)
                ValorInventariotextBox.Text = "0.0";
        }

        public static bool Repeticion(string d)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.productos.Any(p => p.Descripcion.Equals(d)))
                {
                    paso = true;
                }               
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }
    }
    
}
