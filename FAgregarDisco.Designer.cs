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
            tbAño = new TextBox();
            tbNombre = new TextBox();
            label2 = new Label();
            label1 = new Label();
            cbSelEstilo = new ComboBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // tbAño
            // 
            tbAño.Location = new Point(64, 45);
            tbAño.Name = "tbAño";
            tbAño.Size = new Size(120, 23);
            tbAño.TabIndex = 6;
            // 
            // tbNombre
            // 
            tbNombre.Location = new Point(64, 16);
            tbNombre.Name = "tbNombre";
            tbNombre.Size = new Size(120, 23);
            tbNombre.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(5, 48);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 3;
            label2.Text = "Año";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(5, 19);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 4;
            label1.Text = "Nombre";
            // 
            // cbSelEstilo
            // 
            cbSelEstilo.FormattingEnabled = true;
            cbSelEstilo.Location = new Point(64, 74);
            cbSelEstilo.Name = "cbSelEstilo";
            cbSelEstilo.Size = new Size(120, 23);
            cbSelEstilo.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(5, 77);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 3;
            label3.Text = "Estilo";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(76, 121);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(190, 74);
            button2.Name = "button2";
            button2.Size = new Size(28, 23);
            button2.TabIndex = 9;
            button2.Text = "+";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FAgregarDisco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(223, 171);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(cbSelEstilo);
            Controls.Add(tbAño);
            Controls.Add(tbNombre);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FAgregarDisco";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FAgregarDisco";
            Load += FAgregarDisco_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbAño;
        private TextBox tbNombre;
        private Label label2;
        private Label label1;
        private ComboBox cbSelEstilo;
        private Label label3;
        private Button button1;
        private Button button2;
    }
}