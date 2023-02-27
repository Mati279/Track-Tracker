namespace Track_Tracker
{
    partial class FAgregarTema
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
            this.butAgrArtista = new System.Windows.Forms.Button();
            this.cbSelArtista = new System.Windows.Forms.ComboBox();
            this.tbNombreTema = new System.Windows.Forms.TextBox();
            this.tbDisco = new System.Windows.Forms.TextBox();
            this.lbDisco = new System.Windows.Forms.Label();
            this.lbNombreTema = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butAgrArtista
            // 
            this.butAgrArtista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.butAgrArtista.Location = new System.Drawing.Point(139, 22);
            this.butAgrArtista.Name = "butAgrArtista";
            this.butAgrArtista.Size = new System.Drawing.Size(119, 23);
            this.butAgrArtista.TabIndex = 0;
            this.butAgrArtista.Text = "Agregar Artista";
            this.butAgrArtista.UseVisualStyleBackColor = true;
            this.butAgrArtista.Click += new System.EventHandler(this.butAgrArtista_Click);
            // 
            // cbSelArtista
            // 
            this.cbSelArtista.FormattingEnabled = true;
            this.cbSelArtista.Location = new System.Drawing.Point(12, 22);
            this.cbSelArtista.Name = "cbSelArtista";
            this.cbSelArtista.Size = new System.Drawing.Size(121, 23);
            this.cbSelArtista.TabIndex = 1;
            this.cbSelArtista.Text = "Seleccionar artista";
            // 
            // tbNombreTema
            // 
            this.tbNombreTema.Location = new System.Drawing.Point(12, 110);
            this.tbNombreTema.Name = "tbNombreTema";
            this.tbNombreTema.Size = new System.Drawing.Size(121, 23);
            this.tbNombreTema.TabIndex = 2;
            // 
            // tbDisco
            // 
            this.tbDisco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbDisco.Location = new System.Drawing.Point(12, 66);
            this.tbDisco.Name = "tbDisco";
            this.tbDisco.Size = new System.Drawing.Size(121, 23);
            this.tbDisco.TabIndex = 3;
            // 
            // lbDisco
            // 
            this.lbDisco.AutoSize = true;
            this.lbDisco.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbDisco.Location = new System.Drawing.Point(139, 69);
            this.lbDisco.Name = "lbDisco";
            this.lbDisco.Size = new System.Drawing.Size(37, 15);
            this.lbDisco.TabIndex = 4;
            this.lbDisco.Text = "Disco";
            // 
            // lbNombreTema
            // 
            this.lbNombreTema.AutoSize = true;
            this.lbNombreTema.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbNombreTema.Location = new System.Drawing.Point(139, 113);
            this.lbNombreTema.Name = "lbNombreTema";
            this.lbNombreTema.Size = new System.Drawing.Size(53, 15);
            this.lbNombreTema.TabIndex = 5;
            this.lbNombreTema.Text = "Nombre";
            // 
            // FAgregarTema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbNombreTema);
            this.Controls.Add(this.lbDisco);
            this.Controls.Add(this.tbDisco);
            this.Controls.Add(this.tbNombreTema);
            this.Controls.Add(this.cbSelArtista);
            this.Controls.Add(this.butAgrArtista);
            this.Name = "FAgregarTema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FAgregarTema";
            this.Activated += new System.EventHandler(this.FAgregarTema_Activated);
            this.Load += new System.EventHandler(this.FAgregarTema_Load);
            this.EnabledChanged += new System.EventHandler(this.FAgregarTema_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button butAgrArtista;
        private ComboBox cbSelArtista;
        private TextBox tbNombreTema;
        private TextBox tbDisco;
        private Label lbDisco;
        private Label lbNombreTema;
    }
}