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
            this.gbPerfil = new System.Windows.Forms.GroupBox();
            this.cboxPerfiles = new System.Windows.Forms.ComboBox();
            this.butGabi = new System.Windows.Forms.Button();
            this.butPablo = new System.Windows.Forms.Button();
            this.butMati = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.butPublicarTema = new System.Windows.Forms.Button();
            this.lbViendo = new System.Windows.Forms.Label();
            this.gbPerfil.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPerfil
            // 
            this.gbPerfil.Controls.Add(this.cboxPerfiles);
            this.gbPerfil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gbPerfil.Location = new System.Drawing.Point(12, 12);
            this.gbPerfil.Name = "gbPerfil";
            this.gbPerfil.Size = new System.Drawing.Size(112, 57);
            this.gbPerfil.TabIndex = 0;
            this.gbPerfil.TabStop = false;
            this.gbPerfil.Text = "Viendo como:";
            // 
            // cboxPerfiles
            // 
            this.cboxPerfiles.FormattingEnabled = true;
            this.cboxPerfiles.Location = new System.Drawing.Point(6, 22);
            this.cboxPerfiles.Name = "cboxPerfiles";
            this.cboxPerfiles.Size = new System.Drawing.Size(100, 23);
            this.cboxPerfiles.TabIndex = 0;
            this.cboxPerfiles.SelectedIndexChanged += new System.EventHandler(this.cboxPerfiles_SelectedIndexChanged_1);
            // 
            // butGabi
            // 
            this.butGabi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.butGabi.Location = new System.Drawing.Point(12, 97);
            this.butGabi.Name = "butGabi";
            this.butGabi.Size = new System.Drawing.Size(112, 32);
            this.butGabi.TabIndex = 1;
            this.butGabi.Text = "Gabi";
            this.butGabi.UseVisualStyleBackColor = true;
            this.butGabi.Click += new System.EventHandler(this.butGabi_Click);
            // 
            // butPablo
            // 
            this.butPablo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.butPablo.Location = new System.Drawing.Point(12, 152);
            this.butPablo.Name = "butPablo";
            this.butPablo.Size = new System.Drawing.Size(112, 32);
            this.butPablo.TabIndex = 1;
            this.butPablo.Text = "Pablo";
            this.butPablo.UseVisualStyleBackColor = true;
            this.butPablo.Click += new System.EventHandler(this.butPablo_Click);
            // 
            // butMati
            // 
            this.butMati.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.butMati.Location = new System.Drawing.Point(12, 207);
            this.butMati.Name = "butMati";
            this.butMati.Size = new System.Drawing.Size(112, 32);
            this.butMati.TabIndex = 1;
            this.butMati.Text = "Mati";
            this.butMati.UseVisualStyleBackColor = true;
            this.butMati.Click += new System.EventHandler(this.butMati_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Perfiles:";
            // 
            // butPublicarTema
            // 
            this.butPublicarTema.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.butPublicarTema.Location = new System.Drawing.Point(250, 21);
            this.butPublicarTema.Name = "butPublicarTema";
            this.butPublicarTema.Size = new System.Drawing.Size(146, 48);
            this.butPublicarTema.TabIndex = 3;
            this.butPublicarTema.Text = "Publicar Tema";
            this.butPublicarTema.UseVisualStyleBackColor = true;
            this.butPublicarTema.Click += new System.EventHandler(this.butPublicarTema_Click);
            // 
            // lbViendo
            // 
            this.lbViendo.AutoSize = true;
            this.lbViendo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbViendo.Location = new System.Drawing.Point(53, 330);
            this.lbViendo.Name = "lbViendo";
            this.lbViendo.Size = new System.Drawing.Size(57, 21);
            this.lbViendo.TabIndex = 4;
            this.lbViendo.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 450);
            this.Controls.Add(this.lbViendo);
            this.Controls.Add(this.butPublicarTema);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butMati);
            this.Controls.Add(this.butPablo);
            this.Controls.Add(this.butGabi);
            this.Controls.Add(this.gbPerfil);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbPerfil.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox gbPerfil;
        private Button butGabi;
        private Button butPablo;
        private Button butMati;
        private Label label1;
        private Button butPublicarTema;
        private ComboBox cboxPerfiles;
        private Label lbViendo;
    }
}