namespace ProyectoFinal
{
    partial class Mapa
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
            pbMapa = new PictureBox();
            lblInicio = new Label();
            lblFin = new Label();
            cbOrigen = new ComboBox();
            cbDestino = new ComboBox();
            btnRutaCorta = new Button();
            btnTodasRutasCortas = new Button();
            btnExisteCamino = new Button();
            lblNomAlgoritmo = new Label();
            lblDistancia = new Label();
            lblRutasPosibles = new Label();
            lblDirecciones = new Label();
            lblTiempo = new Label();
            ((System.ComponentModel.ISupportInitialize)pbMapa).BeginInit();
            SuspendLayout();
            // 
            // pbMapa
            // 
            pbMapa.BackgroundImageLayout = ImageLayout.Stretch;
            pbMapa.Location = new Point(343, 12);
            pbMapa.Name = "pbMapa";
            pbMapa.Size = new Size(750, 750);
            pbMapa.SizeMode = PictureBoxSizeMode.StretchImage;
            pbMapa.TabIndex = 0;
            pbMapa.TabStop = false;
            // 
            // lblInicio
            // 
            lblInicio.AutoSize = true;
            lblInicio.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInicio.Location = new Point(17, 60);
            lblInicio.Name = "lblInicio";
            lblInicio.Size = new Size(107, 17);
            lblInicio.TabIndex = 1;
            lblInicio.Text = "Lugar de origen:";
            // 
            // lblFin
            // 
            lblFin.AutoSize = true;
            lblFin.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFin.Location = new Point(17, 114);
            lblFin.Name = "lblFin";
            lblFin.Size = new Size(113, 17);
            lblFin.TabIndex = 2;
            lblFin.Text = "Lugar de destino:";
            // 
            // cbOrigen
            // 
            cbOrigen.FormattingEnabled = true;
            cbOrigen.Location = new Point(17, 80);
            cbOrigen.Name = "cbOrigen";
            cbOrigen.Size = new Size(302, 23);
            cbOrigen.TabIndex = 3;
            // 
            // cbDestino
            // 
            cbDestino.FormattingEnabled = true;
            cbDestino.Location = new Point(17, 134);
            cbDestino.Name = "cbDestino";
            cbDestino.Size = new Size(302, 23);
            cbDestino.TabIndex = 4;
            // 
            // btnRutaCorta
            // 
            btnRutaCorta.BackColor = Color.Teal;
            btnRutaCorta.FlatStyle = FlatStyle.Flat;
            btnRutaCorta.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRutaCorta.ForeColor = Color.White;
            btnRutaCorta.Location = new Point(20, 173);
            btnRutaCorta.Name = "btnRutaCorta";
            btnRutaCorta.Size = new Size(299, 35);
            btnRutaCorta.TabIndex = 5;
            btnRutaCorta.Text = "Ruta más corta";
            btnRutaCorta.UseVisualStyleBackColor = false;
            btnRutaCorta.Click += btnRutaCorta_Click;
            // 
            // btnTodasRutasCortas
            // 
            btnTodasRutasCortas.BackColor = Color.Maroon;
            btnTodasRutasCortas.FlatStyle = FlatStyle.Flat;
            btnTodasRutasCortas.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTodasRutasCortas.ForeColor = Color.White;
            btnTodasRutasCortas.Location = new Point(20, 214);
            btnTodasRutasCortas.Name = "btnTodasRutasCortas";
            btnTodasRutasCortas.Size = new Size(299, 35);
            btnTodasRutasCortas.TabIndex = 6;
            btnTodasRutasCortas.Text = "Todas las rutas cortas";
            btnTodasRutasCortas.UseVisualStyleBackColor = false;
            btnTodasRutasCortas.Click += btnTodasRutasCortas_Click;
            // 
            // btnExisteCamino
            // 
            btnExisteCamino.BackColor = Color.Green;
            btnExisteCamino.FlatStyle = FlatStyle.Flat;
            btnExisteCamino.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExisteCamino.ForeColor = Color.White;
            btnExisteCamino.Location = new Point(20, 255);
            btnExisteCamino.Name = "btnExisteCamino";
            btnExisteCamino.Size = new Size(299, 35);
            btnExisteCamino.TabIndex = 7;
            btnExisteCamino.Text = "Verificar si existe camino";
            btnExisteCamino.UseVisualStyleBackColor = false;
            btnExisteCamino.Click += btnExisteCamino_Click;
            // 
            // lblNomAlgoritmo
            // 
            lblNomAlgoritmo.AutoSize = true;
            lblNomAlgoritmo.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNomAlgoritmo.Location = new Point(20, 311);
            lblNomAlgoritmo.Name = "lblNomAlgoritmo";
            lblNomAlgoritmo.Size = new Size(0, 17);
            lblNomAlgoritmo.TabIndex = 10;
            // 
            // lblDistancia
            // 
            lblDistancia.AutoSize = true;
            lblDistancia.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDistancia.Location = new Point(20, 339);
            lblDistancia.Name = "lblDistancia";
            lblDistancia.Size = new Size(0, 17);
            lblDistancia.TabIndex = 11;
            // 
            // lblRutasPosibles
            // 
            lblRutasPosibles.AutoSize = true;
            lblRutasPosibles.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRutasPosibles.Location = new Point(20, 384);
            lblRutasPosibles.Name = "lblRutasPosibles";
            lblRutasPosibles.Size = new Size(0, 17);
            lblRutasPosibles.TabIndex = 12;
            // 
            // lblDirecciones
            // 
            lblDirecciones.AutoSize = true;
            lblDirecciones.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDirecciones.Location = new Point(20, 411);
            lblDirecciones.Name = "lblDirecciones";
            lblDirecciones.Size = new Size(0, 17);
            lblDirecciones.TabIndex = 13;
            // 
            // lblTiempo
            // 
            lblTiempo.AutoSize = true;
            lblTiempo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTiempo.Location = new Point(20, 367);
            lblTiempo.Name = "lblTiempo";
            lblTiempo.Size = new Size(0, 17);
            lblTiempo.TabIndex = 14;
            // 
            // Mapa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(226, 227, 225);
            ClientSize = new Size(1112, 776);
            Controls.Add(lblTiempo);
            Controls.Add(lblDirecciones);
            Controls.Add(lblRutasPosibles);
            Controls.Add(lblDistancia);
            Controls.Add(lblNomAlgoritmo);
            Controls.Add(btnExisteCamino);
            Controls.Add(btnTodasRutasCortas);
            Controls.Add(btnRutaCorta);
            Controls.Add(cbDestino);
            Controls.Add(cbOrigen);
            Controls.Add(lblFin);
            Controls.Add(lblInicio);
            Controls.Add(pbMapa);
            Name = "Mapa";
            Text = "Mapa";
            ((System.ComponentModel.ISupportInitialize)pbMapa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbMapa;
        private Label lblInicio;
        private Label lblFin;
        private ComboBox cbOrigen;
        private ComboBox cbDestino;
        private Button btnRutaCorta;
        private Button btnTodasRutasCortas;
        private Button btnExisteCamino;
        private Label lblNomAlgoritmo;
        private Label lblDistancia;
        private Label lblRutasPosibles;
        private Label lblDirecciones;
        private Label lblTiempo;
    }
}