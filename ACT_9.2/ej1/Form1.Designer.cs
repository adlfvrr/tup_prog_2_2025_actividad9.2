namespace ej1
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbPatente = new TextBox();
            tbImporte = new TextBox();
            dtpVencimiento = new DateTimePicker();
            btnConfirmar = new Button();
            lsbVer = new ListBox();
            btnActualizar = new Button();
            btnImportar = new Button();
            btnExportar = new Button();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 38);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Patente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 74);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 1;
            label2.Text = "Vencimiento";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 114);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 2;
            label3.Text = "Importe";
            // 
            // tbPatente
            // 
            tbPatente.Location = new Point(131, 35);
            tbPatente.Name = "tbPatente";
            tbPatente.Size = new Size(188, 23);
            tbPatente.TabIndex = 3;
            // 
            // tbImporte
            // 
            tbImporte.Location = new Point(131, 106);
            tbImporte.Name = "tbImporte";
            tbImporte.Size = new Size(188, 23);
            tbImporte.TabIndex = 4;
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.CustomFormat = "dd/MM/yyyy";
            dtpVencimiento.Format = DateTimePickerFormat.Custom;
            dtpVencimiento.Location = new Point(131, 68);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.Size = new Size(188, 23);
            dtpVencimiento.TabIndex = 5;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(349, 60);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(146, 42);
            btnConfirmar.TabIndex = 6;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // lsbVer
            // 
            lsbVer.FormattingEnabled = true;
            lsbVer.HorizontalScrollbar = true;
            lsbVer.ItemHeight = 15;
            lsbVer.Location = new Point(34, 160);
            lsbVer.Name = "lsbVer";
            lsbVer.ScrollAlwaysVisible = true;
            lsbVer.Size = new Size(285, 244);
            lsbVer.TabIndex = 7;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(349, 194);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(146, 42);
            btnActualizar.TabIndex = 8;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(349, 252);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(146, 42);
            btnImportar.TabIndex = 9;
            btnImportar.Text = "Importar";
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
            // 
            // btnExportar
            // 
            btnExportar.Location = new Point(349, 309);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(146, 42);
            btnExportar.TabIndex = 10;
            btnExportar.Text = "Exportar";
            btnExportar.UseVisualStyleBackColor = true;
            btnExportar.Click += btnExportar_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 450);
            Controls.Add(btnExportar);
            Controls.Add(btnImportar);
            Controls.Add(btnActualizar);
            Controls.Add(lsbVer);
            Controls.Add(btnConfirmar);
            Controls.Add(dtpVencimiento);
            Controls.Add(tbImporte);
            Controls.Add(tbPatente);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ejercicio 1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbPatente;
        private TextBox tbImporte;
        private DateTimePicker dtpVencimiento;
        private Button btnConfirmar;
        private ListBox lsbVer;
        private Button btnActualizar;
        private Button btnImportar;
        private Button btnExportar;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}
