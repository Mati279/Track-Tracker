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
            this.lbNombreTema = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.cbSelDisco = new System.Windows.Forms.ComboBox();
<<<<<<< Updated upstream
            this.cbSelTipo = new System.Windows.Forms.ComboBox();
            this.butAgregarEstilo = new System.Windows.Forms.Button();
            this.tbNombreTema = new System.Windows.Forms.TextBox();
            this.butAgregarDisco = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
=======
            this.cbSelEstilo = new System.Windows.Forms.ComboBox();
            this.butSelEstilo = new System.Windows.Forms.Button();
            this.tbNombreTema = new System.Windows.Forms.TextBox();
            this.butAgregarDisco = new System.Windows.Forms.Button();
>>>>>>> Stashed changes
            this.SuspendLayout();
            // 
            // butAgrArtista
            // 
            this.butAgrArtista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.butAgrArtista.Location = new System.Drawing.Point(139, 68);
            this.butAgrArtista.Name = "butAgrArtista";
            this.butAgrArtista.Size = new System.Drawing.Size(109, 23);
            this.butAgrArtista.TabIndex = 0;
            this.butAgrArtista.Text = "Agregar Artista";
            this.butAgrArtista.UseVisualStyleBackColor = true;
            this.butAgrArtista.Click += new System.EventHandler(this.butAgrArtista_Click);
            // 
            // cbSelArtista
            // 
            this.cbSelArtista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbSelArtista.FormattingEnabled = true;
            this.cbSelArtista.Location = new System.Drawing.Point(12, 69);
            this.cbSelArtista.Name = "cbSelArtista";
            this.cbSelArtista.Size = new System.Drawing.Size(121, 23);
            this.cbSelArtista.TabIndex = 1;
            // 
            // lbNombreTema
            // 
            this.lbNombreTema.AutoSize = true;
            this.lbNombreTema.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbNombreTema.Location = new System.Drawing.Point(139, 31);
            this.lbNombreTema.Name = "lbNombreTema";
            this.lbNombreTema.Size = new System.Drawing.Size(53, 15);
            this.lbNombreTema.TabIndex = 5;
            this.lbNombreTema.Text = "Nombre";
            // 
            // btOK
            // 
            this.btOK.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btOK.Location = new System.Drawing.Point(94, 213);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 6;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
<<<<<<< Updated upstream
=======
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
>>>>>>> Stashed changes
            // 
            // cbSelDisco
            // 
            this.cbSelDisco.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbSelDisco.FormattingEnabled = true;
            this.cbSelDisco.Location = new System.Drawing.Point(12, 113);
            this.cbSelDisco.Name = "cbSelDisco";
            this.cbSelDisco.Size = new System.Drawing.Size(121, 23);
            this.cbSelDisco.TabIndex = 1;
            // 
            // cbSelEstilo
            // 
<<<<<<< Updated upstream
            this.cbSelTipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbSelTipo.FormattingEnabled = true;
            this.cbSelTipo.Location = new System.Drawing.Point(12, 157);
            this.cbSelTipo.Name = "cbSelTipo";
            this.cbSelTipo.Size = new System.Drawing.Size(121, 23);
            this.cbSelTipo.TabIndex = 1;
            // 
            // butAgregarEstilo
            // 
            this.butAgregarEstilo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.butAgregarEstilo.Location = new System.Drawing.Point(181, 156);
            this.butAgregarEstilo.Name = "butAgregarEstilo";
            this.butAgregarEstilo.Size = new System.Drawing.Size(30, 23);
            this.butAgregarEstilo.TabIndex = 7;
            this.butAgregarEstilo.Text = "+";
            this.butAgregarEstilo.UseVisualStyleBackColor = true;
            this.butAgregarEstilo.Click += new System.EventHandler(this.button1_Click);
=======
            this.cbSelEstilo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbSelEstilo.FormattingEnabled = true;
            this.cbSelEstilo.Location = new System.Drawing.Point(12, 157);
            this.cbSelEstilo.Name = "cbSelEstilo";
            this.cbSelEstilo.Size = new System.Drawing.Size(121, 23);
            this.cbSelEstilo.TabIndex = 1;
            // 
            // butSelEstilo
            // 
            this.butSelEstilo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.butSelEstilo.Location = new System.Drawing.Point(139, 157);
            this.butSelEstilo.Name = "butSelEstilo";
            this.butSelEstilo.Size = new System.Drawing.Size(30, 23);
            this.butSelEstilo.TabIndex = 7;
            this.butSelEstilo.Text = "+";
            this.butSelEstilo.UseVisualStyleBackColor = true;
            this.butSelEstilo.Click += new System.EventHandler(this.butSelEstilo_Click);
>>>>>>> Stashed changes
            // 
            // tbNombreTema
            // 
            this.tbNombreTema.Location = new System.Drawing.Point(12, 28);
            this.tbNombreTema.Name = "tbNombreTema";
            this.tbNombreTema.Size = new System.Drawing.Size(121, 23);
            this.tbNombreTema.TabIndex = 8;
            // 
            // butAgregarDisco
            // 
            this.butAgregarDisco.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.butAgregarDisco.Location = new System.Drawing.Point(139, 113);
            this.butAgregarDisco.Name = "butAgregarDisco";
            this.butAgregarDisco.Size = new System.Drawing.Size(109, 23);
            this.butAgregarDisco.TabIndex = 9;
            this.butAgregarDisco.Text = "Agregar Disco";
            this.butAgregarDisco.UseVisualStyleBackColor = true;
            this.butAgregarDisco.Click += new System.EventHandler(this.butAgregarDisco_Click);
<<<<<<< Updated upstream
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(139, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Estilo";
=======
>>>>>>> Stashed changes
            // 
            // FAgregarTema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 254);
            this.Controls.Add(this.butAgregarDisco);
            this.Controls.Add(this.tbNombreTema);
<<<<<<< Updated upstream
            this.Controls.Add(this.butAgregarEstilo);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbNombreTema);
            this.Controls.Add(this.cbSelTipo);
=======
            this.Controls.Add(this.butSelEstilo);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.lbNombreTema);
            this.Controls.Add(this.cbSelEstilo);
>>>>>>> Stashed changes
            this.Controls.Add(this.cbSelDisco);
            this.Controls.Add(this.cbSelArtista);
            this.Controls.Add(this.butAgrArtista);
            this.Name = "FAgregarTema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FAgregarTema";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button butAgrArtista;
        private ComboBox cbSelArtista;
        private Label lbNombreTema;
        private Button btOK;
        private ComboBox cbSelDisco;
<<<<<<< Updated upstream
        private ComboBox cbSelTipo;
        private Button butAgregarEstilo;
=======
        private ComboBox cbSelEstilo;
        private Button butSelEstilo;
>>>>>>> Stashed changes
        private TextBox tbNombreTema;
        private Button butAgregarDisco;
        private Label label1;
    }
}