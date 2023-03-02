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
            butAgrArtista = new Button();
            cbSelArtista = new ComboBox();
            lbNombreTema = new Label();
            btOK = new Button();
            cbSelDisco = new ComboBox();
            cbSelTipo = new ComboBox();
            button1 = new Button();
            tbNombreTema = new TextBox();
            butAgregarDisco = new Button();
            SuspendLayout();
            // 
            // butAgrArtista
            // 
            butAgrArtista.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            butAgrArtista.Location = new Point(139, 68);
            butAgrArtista.Name = "butAgrArtista";
            butAgrArtista.Size = new Size(109, 23);
            butAgrArtista.TabIndex = 0;
            butAgrArtista.Text = "Agregar Artista";
            butAgrArtista.UseVisualStyleBackColor = true;
            butAgrArtista.Click += butAgrArtista_Click;
            // 
            // cbSelArtista
            // 
            cbSelArtista.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cbSelArtista.FormattingEnabled = true;
            cbSelArtista.Location = new Point(12, 69);
            cbSelArtista.Name = "cbSelArtista";
            cbSelArtista.Size = new Size(121, 23);
            cbSelArtista.TabIndex = 1;
            cbSelArtista.SelectedIndexChanged += cbSelArtista_SelectedIndexChanged;
            // 
            // lbNombreTema
            // 
            lbNombreTema.AutoSize = true;
            lbNombreTema.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbNombreTema.Location = new Point(139, 31);
            lbNombreTema.Name = "lbNombreTema";
            lbNombreTema.Size = new Size(53, 15);
            lbNombreTema.TabIndex = 5;
            lbNombreTema.Text = "Nombre";
            // 
            // btOK
            // 
            btOK.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btOK.Location = new Point(94, 213);
            btOK.Name = "btOK";
            btOK.Size = new Size(75, 23);
            btOK.TabIndex = 6;
            btOK.Text = "OK";
            btOK.UseVisualStyleBackColor = true;
            btOK.Click += btOK_Click;
            // 
            // cbSelDisco
            // 
            cbSelDisco.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cbSelDisco.FormattingEnabled = true;
            cbSelDisco.Location = new Point(12, 113);
            cbSelDisco.Name = "cbSelDisco";
            cbSelDisco.Size = new Size(121, 23);
            cbSelDisco.TabIndex = 1;
            // 
            // cbSelTipo
            // 
            cbSelTipo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cbSelTipo.FormattingEnabled = true;
            cbSelTipo.Location = new Point(12, 157);
            cbSelTipo.Name = "cbSelTipo";
            cbSelTipo.Size = new Size(121, 23);
            cbSelTipo.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(139, 157);
            button1.Name = "button1";
            button1.Size = new Size(30, 23);
            button1.TabIndex = 7;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tbNombreTema
            // 
            tbNombreTema.Location = new Point(12, 28);
            tbNombreTema.Name = "tbNombreTema";
            tbNombreTema.Size = new Size(121, 23);
            tbNombreTema.TabIndex = 8;
            // 
            // butAgregarDisco
            // 
            butAgregarDisco.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            butAgregarDisco.Location = new Point(139, 113);
            butAgregarDisco.Name = "butAgregarDisco";
            butAgregarDisco.Size = new Size(109, 23);
            butAgregarDisco.TabIndex = 9;
            butAgregarDisco.Text = "Agregar Disco";
            butAgregarDisco.UseVisualStyleBackColor = true;
            butAgregarDisco.Click += butAgregarDisco_Click;
            // 
            // FAgregarTema
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(262, 254);
            Controls.Add(butAgregarDisco);
            Controls.Add(tbNombreTema);
            Controls.Add(button1);
            Controls.Add(btOK);
            Controls.Add(lbNombreTema);
            Controls.Add(cbSelTipo);
            Controls.Add(cbSelDisco);
            Controls.Add(cbSelArtista);
            Controls.Add(butAgrArtista);
            Name = "FAgregarTema";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FAgregarTema";
            Load += FAgregarTema_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button butAgrArtista;
        private ComboBox cbSelArtista;
        private Label lbNombreTema;
        private Button btOK;
        private ComboBox cbSelDisco;
        private ComboBox cbSelTipo;
        private Button button1;
        private TextBox tbNombreTema;
        private Button butAgregarDisco;
    }
}