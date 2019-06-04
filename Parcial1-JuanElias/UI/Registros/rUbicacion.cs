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

namespace Parcial1_JuanElias.UI.Registros
{
    public partial class rUbicacion : Form
    {
        public rUbicacion()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            IDnumericUpDown.Value = 0;
            DescripciontextBox.Text = string.Empty;
            MyErrorProvider.Clear();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void LlenaCampo(Ubicacion ubicacion)
        {
            IDnumericUpDown.Value = ubicacion.id;
            DescripciontextBox.Text = ubicacion.descripcion;   
        }
        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            Ubicacion ubicacion = new Ubicacion();
            int.TryParse(IDnumericUpDown.Text, out id);

            Limpiar();

            ubicacion = UbicacionBLL.Buscar(id);

            if (ubicacion != null)
            {
                LlenaCampo(ubicacion);
            }
            else
                MessageBox.Show("Ubicacion no encontrada.");
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Ubicacion ubicacion = UbicacionBLL.Buscar((int)IDnumericUpDown.Value);

            return (ubicacion != null);
        }

        private Ubicacion LlenaClase()
        {
            Ubicacion ubicacion = new Ubicacion();
            ubicacion.id = Convert.ToInt32(IDnumericUpDown.Value);
            ubicacion.descripcion = DescripciontextBox.Text;
            return ubicacion;
        }
        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Ubicacion ubicacion;

            bool paso = false;

            if (!ValidarGuardar())
                return;

            ubicacion = LlenaClase();


            if (IDnumericUpDown.Value == 0)

                paso = UbicacionBLL.Guardar(ubicacion);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No existe.", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = UbicacionBLL.Modificar(ubicacion);
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

            if (UbicacionBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MyErrorProvider.SetError(IDnumericUpDown, "No se puede eliminar.");
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
            return paso;
        }
        private bool ValidarEliminar()
        {
            bool paso = true;
            MyErrorProvider.Clear();

            if (IDnumericUpDown.Value == 0)
            {
                MyErrorProvider.SetError(IDnumericUpDown, "Busque y luego elimine.");
                IDnumericUpDown.Focus();
                paso = false;
            }
            return paso;
        }


    }
    
    }
