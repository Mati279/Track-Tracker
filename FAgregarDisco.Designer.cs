namespace Track_Tracker
{
    partial class FAgregarDisco
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
            this.tbAño = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSelEstilo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.butAgregarEstilo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbAño
            // 
            this.tbAño.Location = new System.Drawing.Point(64, 45);
            this.tbAño.Name = "tbAño";
            this.tbAño.Size = new System.Drawing.Size(120, 23);
            this.tbAño.TabIndex = 6;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(64, 16);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(120, 23);
            this.tbNombre.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Año";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(5, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre";
            // 
            // cbSelEstilo
            // 
            this.cbSelEstilo.FormattingEnabled = true;
            this.cbSelEstilo.Location = new System.Drawing.Point(64, 74);
            this.cbSelEstilo.Name = "cbSelEstilo";
            this.cbSelEstilo.Size = new System.Drawing.Size(120, 23);
            this.cbSelEstilo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(5, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Estilo";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(76, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // butAgregarEstilo
            // 
            this.butAgregarEstilo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.butAgregarEstilo.Location = new System.Drawing.Point(190, 74);
            this.butAgregarEstilo.Name = "butAgregarEstilo";
            this.butAgregarEstilo.Size = new System.Drawing.Size(28, 23);
            this.butAgregarEstilo.TabIndex = 9;
            this.butAgregarEstilo.Text = "+";
            this.butAgregarEstilo.UseVisualStyleBackColor = true;
            this.butAgregarEstilo.Click += new System.EventHandler(this.button2_Click);
            // 
            // FAgregarDisco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 171);
            this.Controls.Add(this.butAgregarEstilo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbSelEstilo);
            this.Controls.Add(this.tbAño);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FAgregarDisco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FAgregarDisco";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbAño;
        private TextBox tbNombre;
        private Label label2;
        private Label label1;
        private ComboBox cbSelEstilo;
        private Label label3;
        private Button button1;
        private Button butAgregarEstilo;
    }
}