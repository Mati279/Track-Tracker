namespace Track_Tracker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbPerfil = new GroupBox();
            cboxPerfiles = new ComboBox();
            lbViendo = new Label();
            butGabi = new Button();
            butPablo = new Button();
            butMati = new Button();
            label1 = new Label();
            butPublicarTema = new Button();
            butAgregarPerfil = new Button();
            lbGabTemActual = new Label();
            lbGabNombreTema = new Label();
            lbGabBandaTema = new Label();
            lbPabTemaActual = new Label();
            lbPabNombreTema = new Label();
            lbPabBandaTema = new Label();
            lbMatTemaActual = new Label();
            lbMatNombreTema = new Label();
            lbMatBandaTema = new Label();
            gbPerfil.SuspendLayout();
            SuspendLayout();
            // 
            // gbPerfil
            // 
            gbPerfil.Controls.Add(cboxPerfiles);
            gbPerfil.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            gbPerfil.Location = new Point(12, 12);
            gbPerfil.Name = "gbPerfil";
            gbPerfil.Size = new Size(112, 57);
            gbPerfil.TabIndex = 0;
            gbPerfil.TabStop = false;
            gbPerfil.Text = "Viendo como:";
            // 
            // cboxPerfiles
            // 
            cboxPerfiles.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxPerfiles.FormattingEnabled = true;
            cboxPerfiles.Location = new Point(12, 22);
            cboxPerfiles.Name = "cboxPerfiles";
            cboxPerfiles.Size = new Size(84, 23);
            cboxPerfiles.TabIndex = 0;
            cboxPerfiles.SelectedIndexChanged += cboxPerfiles_SelectedIndexChanged;
            // 
            // lbViendo
            // 
            lbViendo.AutoSize = true;
            lbViendo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            lbViendo.Location = new Point(55, 367);
            lbViendo.Name = "lbViendo";
            lbViendo.Size = new Size(53, 25);
            lbViendo.TabIndex = 0;
            lbViendo.Text = "Gabi";
            // 
            // butGabi
            // 
            butGabi.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            butGabi.Location = new Point(12, 97);
            butGabi.Name = "butGabi";
            butGabi.Size = new Size(112, 32);
            butGabi.TabIndex = 1;
            butGabi.Text = "Gabi";
            butGabi.UseVisualStyleBackColor = true;
            butGabi.Click += butGabi_Click;
            // 
            // butPablo
            // 
            butPablo.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            butPablo.Location = new Point(12, 152);
            butPablo.Name = "butPablo";
            butPablo.Size = new Size(112, 32);
            butPablo.TabIndex = 1;
            butPablo.Text = "Pablo";
            butPablo.UseVisualStyleBackColor = true;
            butPablo.Click += butPablo_Click;
            // 
            // butMati
            // 
            butMati.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            butMati.Location = new Point(12, 207);
            butMati.Name = "butMati";
            butMati.Size = new Size(112, 32);
            butMati.TabIndex = 1;
            butMati.Text = "Mati";
            butMati.UseVisualStyleBackColor = true;
            butMati.Click += butMati_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 79);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 2;
            label1.Text = "Perfiles:";
            // 
            // butPublicarTema
            // 
            butPublicarTema.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            butPublicarTema.Location = new Point(250, 21);
            butPublicarTema.Name = "butPublicarTema";
            butPublicarTema.Size = new Size(146, 48);
            butPublicarTema.TabIndex = 3;
            butPublicarTema.Text = "Publicar Tema";
            butPublicarTema.UseVisualStyleBackColor = true;
            butPublicarTema.Click += butPublicarTema_Click_1;
            // 
            // butAgregarPerfil
            // 
            butAgregarPerfil.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point);
            butAgregarPerfil.Location = new Point(130, 36);
            butAgregarPerfil.Name = "butAgregarPerfil";
            butAgregarPerfil.Size = new Size(20, 19);
            butAgregarPerfil.TabIndex = 4;
            butAgregarPerfil.Text = "+";
            butAgregarPerfil.UseMnemonic = false;
            butAgregarPerfil.UseVisualStyleBackColor = true;
            butAgregarPerfil.Click += butAgregarPerfil_Click;
            // 
            // lbGabTemActual
            // 
            lbGabTemActual.AutoSize = true;
            lbGabTemActual.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lbGabTemActual.Location = new Point(151, 104);
            lbGabTemActual.Name = "lbGabTemActual";
            lbGabTemActual.Size = new Size(95, 19);
            lbGabTemActual.TabIndex = 5;
            lbGabTemActual.Text = "Tema Actual:";
            // 
            // lbGabNombreTema
            // 
            lbGabNombreTema.AutoSize = true;
            lbGabNombreTema.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbGabNombreTema.Location = new Point(250, 106);
            lbGabNombreTema.Name = "lbGabNombreTema";
            lbGabNombreTema.Size = new Size(79, 15);
            lbGabNombreTema.TabIndex = 5;
            lbGabNombreTema.Text = "NombreTema";
            // 
            // lbGabBandaTema
            // 
            lbGabBandaTema.AutoSize = true;
            lbGabBandaTema.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbGabBandaTema.Location = new Point(357, 106);
            lbGabBandaTema.Name = "lbGabBandaTema";
            lbGabBandaTema.Size = new Size(40, 15);
            lbGabBandaTema.TabIndex = 5;
            lbGabBandaTema.Text = "Banda";
            // 
            // lbPabTemaActual
            // 
            lbPabTemaActual.AutoSize = true;
            lbPabTemaActual.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lbPabTemaActual.Location = new Point(151, 160);
            lbPabTemaActual.Name = "lbPabTemaActual";
            lbPabTemaActual.Size = new Size(95, 19);
            lbPabTemaActual.TabIndex = 5;
            lbPabTemaActual.Text = "Tema Actual:";
            // 
            // lbPabNombreTema
            // 
            lbPabNombreTema.AutoSize = true;
            lbPabNombreTema.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbPabNombreTema.Location = new Point(250, 162);
            lbPabNombreTema.Name = "lbPabNombreTema";
            lbPabNombreTema.Size = new Size(79, 15);
            lbPabNombreTema.TabIndex = 5;
            lbPabNombreTema.Text = "NombreTema";
            // 
            // lbPabBandaTema
            // 
            lbPabBandaTema.AutoSize = true;
            lbPabBandaTema.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbPabBandaTema.Location = new Point(357, 162);
            lbPabBandaTema.Name = "lbPabBandaTema";
            lbPabBandaTema.Size = new Size(40, 15);
            lbPabBandaTema.TabIndex = 5;
            lbPabBandaTema.Text = "Banda";
            // 
            // lbMatTemaActual
            // 
            lbMatTemaActual.AutoSize = true;
            lbMatTemaActual.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            lbMatTemaActual.Location = new Point(151, 215);
            lbMatTemaActual.Name = "lbMatTemaActual";
            lbMatTemaActual.Size = new Size(95, 19);
            lbMatTemaActual.TabIndex = 5;
            lbMatTemaActual.Text = "Tema Actual:";
            // 
            // lbMatNombreTema
            // 
            lbMatNombreTema.AutoSize = true;
            lbMatNombreTema.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbMatNombreTema.Location = new Point(250, 217);
            lbMatNombreTema.Name = "lbMatNombreTema";
            lbMatNombreTema.Size = new Size(79, 15);
            lbMatNombreTema.TabIndex = 5;
            lbMatNombreTema.Text = "NombreTema";
            // 
            // lbMatBandaTema
            // 
            lbMatBandaTema.AutoSize = true;
            lbMatBandaTema.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lbMatBandaTema.Location = new Point(357, 217);
            lbMatBandaTema.Name = "lbMatBandaTema";
            lbMatBandaTema.Size = new Size(40, 15);
            lbMatBandaTema.TabIndex = 5;
            lbMatBandaTema.Text = "Banda";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(690, 450);
            Controls.Add(lbMatBandaTema);
            Controls.Add(lbPabBandaTema);
            Controls.Add(lbGabBandaTema);
            Controls.Add(lbMatNombreTema);
            Controls.Add(lbPabNombreTema);
            Controls.Add(lbGabNombreTema);
            Controls.Add(lbMatTemaActual);
            Controls.Add(lbPabTemaActual);
            Controls.Add(lbGabTemActual);
            Controls.Add(butAgregarPerfil);
            Controls.Add(lbViendo);
            Controls.Add(butPublicarTema);
            Controls.Add(label1);
            Controls.Add(butMati);
            Controls.Add(butPablo);
            Controls.Add(butGabi);
            Controls.Add(gbPerfil);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            gbPerfil.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbPerfil;
        private Label lbViendo;
        private Button butGabi;
        private Button butPablo;
        private Button butMati;
        private Label label1;
        private Button butPublicarTema;
        private ComboBox cboxPerfiles;
        private Button butAgregarPerfil;
        private Label lbGabTemActual;
        private Label lbGabNombreTema;
        private Label lbGabBandaTema;
        private Label lbPabTemaActual;
        private Label lbPabNombreTema;
        private Label lbPabBandaTema;
        private Label lbMatTemaActual;
        private Label lbMatNombreTema;
        private Label lbMatBandaTema;
    }
}