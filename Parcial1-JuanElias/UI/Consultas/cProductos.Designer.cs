namespace Parcial1_JuanElias.UI.Consultas
{
    partial class cProductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ValorTotaltextBox = new System.Windows.Forms.TextBox();
            this.ValorTotallabel = new System.Windows.Forms.Label();
            this.Refrescarbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ValorTotaltextBox
            // 
            this.ValorTotaltextBox.Location = new System.Drawing.Point(12, 39);
            this.ValorTotaltextBox.Name = "ValorTotaltextBox";
            this.ValorTotaltextBox.Size = new System.Drawing.Size(211, 20);
            this.ValorTotaltextBox.TabIndex = 0;
            // 
            // ValorTotallabel
            // 
            this.ValorTotallabel.AutoSize = true;
            this.ValorTotallabel.Location = new System.Drawing.Point(12, 9);
            this.ValorTotallabel.Name = "ValorTotallabel";
            this.ValorTotallabel.Size = new System.Drawing.Size(168, 13);
            this.ValorTotallabel.TabIndex = 1;
            this.ValorTotallabel.Text = "VALOR TOTAL DE INVENTARIO";
            // 
            // Refrescarbutton
            // 
            this.Refrescarbutton.BackColor = System.Drawing.Color.Transparent;
            this.Refrescarbutton.Image = global::Parcial1_JuanElias.Properties.Resources.refresh_arrows_14418;
            this.Refrescarbutton.Location = new System.Drawing.Point(229, 21);
            this.Refrescarbutton.Name = "Refrescarbutton";
            this.Refrescarbutton.Size = new System.Drawing.Size(55, 55);
            this.Refrescarbutton.TabIndex = 2;
            this.Refrescarbutton.UseVisualStyleBackColor = false;
            // 
            // cProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 82);
            this.Controls.Add(this.Refrescarbutton);
            this.Controls.Add(this.ValorTotallabel);
            this.Controls.Add(this.ValorTotaltextBox);
            this.Name = "cProductos";
            this.Text = "Consulta de Productos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ValorTotaltextBox;
        private System.Windows.Forms.Label ValorTotallabel;
        private System.Windows.Forms.Button Refrescarbutton;
    }
}