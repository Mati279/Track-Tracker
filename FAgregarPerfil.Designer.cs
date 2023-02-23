namespace Track_Tracker
{
    partial class FAgregarPerfil
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
            this.textboxNombrePerfil = new System.Windows.Forms.TextBox();
            this.butAgregarPerfil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textboxNombrePerfil
            // 
            this.textboxNombrePerfil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textboxNombrePerfil.Location = new System.Drawing.Point(35, 29);
            this.textboxNombrePerfil.Name = "textboxNombrePerfil";
            this.textboxNombrePerfil.PlaceholderText = "Ingrese Nombre";
            this.textboxNombrePerfil.Size = new System.Drawing.Size(101, 23);
            this.textboxNombrePerfil.TabIndex = 0;
            // 
            // butAgregarPerfil
            // 
            this.butAgregarPerfil.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.butAgregarPerfil.Location = new System.Drawing.Point(151, 29);
            this.butAgregarPerfil.Name = "butAgregarPerfil";
            this.butAgregarPerfil.Size = new System.Drawing.Size(53, 23);
            this.butAgregarPerfil.TabIndex = 1;
            this.butAgregarPerfil.Text = "Agregar";
            this.butAgregarPerfil.UseVisualStyleBackColor = true;
            this.butAgregarPerfil.Click += new System.EventHandler(this.butAgregarPerfil_Click);
            // 
            // FAgregarPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 83);
            this.Controls.Add(this.butAgregarPerfil);
            this.Controls.Add(this.textboxNombrePerfil);
            this.Name = "FAgregarPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear Perfil";
            this.Load += new System.EventHandler(this.FAgregarPerfil_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textboxNombrePerfil;
        private Button butAgregarPerfil;
    }
}