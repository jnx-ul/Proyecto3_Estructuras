using ProyectoFinal.Clases;

namespace ProyectoFinal
{
    public partial class Mapa : Form
    {
        private Grafo grafo;
        // Para reutilizar resultados de Floyd
        private int[,] floydDist;
        private int[,] floydNext;

        public Mapa()
        {
            grafo = new Grafo();
            InitializeComponent();
            cargaInicial();
        }

        private void cargaInicial()
        {
            #region Imagenes
            pbMapa.Image = Image.FromFile(@"img\MapaCiudadGrafov2.png");
            pbMapa.SizeMode = PictureBoxSizeMode.StretchImage;
            #endregion

            #region Combos
            LlenarCombos();
            #endregion
        }

        #region Métodos privados

        /// <summary>
        /// Agrega a los combos de origen y destino las ubicaciones disponibles
        /// </summary>
        private void LlenarCombos()
        {
            cbOrigen.Items.Clear();
            cbDestino.Items.Clear();

            foreach (var nombre in grafo.Lugares)
            {
                cbOrigen.Items.Add(nombre);
                cbDestino.Items.Add(nombre);
            }

            if (cbOrigen.Items.Count > 0)
                cbOrigen.SelectedIndex = 0;

            if (cbDestino.Items.Count > 1)
                cbDestino.SelectedIndex = 1;
            else if (cbDestino.Items.Count == 1)
                cbDestino.SelectedIndex = 0;
        }
        #endregion

        #region Botones
        private void btnRutaCorta_Click(object sender, EventArgs e)
        {
            if (cbOrigen.SelectedItem == null || cbDestino.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un origen y un destino.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string origenNombre = cbOrigen.SelectedItem.ToString();
            string destinoNombre = cbDestino.SelectedItem.ToString();

            int origen = grafo.mapaIndices[origenNombre];
            int destino = grafo.mapaIndices[destinoNombre];

            var resultado = grafo.Dijkstra(origen, destino);

            lblNomAlgoritmo.Text = "Algoritmo de Dijkstra";

            if (resultado.distancia >= Grafo.INF / 2 || resultado.camino == null)
            {
                lblDirecciones.Text = $"No existe ruta entre \"{origenNombre}\" y \"{destinoNombre}\" usando este algoritmo.";
                return;
            }

            var nombresRuta = grafo.ConvertirCaminoANombres(resultado.camino);

            lblDistancia.Text = "Distancia mínima: " + resultado.distancia + "km";
            lblTiempo.Text = "Tiempo estimado de llegada " + (resultado.distancia * 1.5) + " minutos";
            lblRutasPosibles.Text = "Ruta más corta: ";
            lblDirecciones.Text = string.Join("  ->  " + Environment.NewLine, nombresRuta);
        }

        private void btnTodasRutasCortas_Click(object sender, EventArgs e)
        {
            if (cbOrigen.SelectedItem == null || cbDestino.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un origen y un destino.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string origenNombre = cbOrigen.SelectedItem.ToString();
            string destinoNombre = cbDestino.SelectedItem.ToString();

            int origen = grafo.mapaIndices[origenNombre];
            int destino = grafo.mapaIndices[destinoNombre];

            grafo.Floyd(out floydDist, out floydNext);

            var camino = grafo.ReconstruirCaminoFloyd(origen, destino, floydNext);

            lblNomAlgoritmo.Text = "Algoritmo de Floyd (todas las rutas más cortas)";

            if (camino == null)
            {
                lblDirecciones.Text = $"No existe ruta entre \"{origenNombre}\" y \"{destinoNombre}\".";
                return;
            }

            int distancia = floydDist[origen, destino];
            var nombresRuta = grafo.ConvertirCaminoANombres(camino);

            lblDistancia.Text = "Distancia mínima: " + distancia + "km";
            lblTiempo.Text = "Tiempo estimado de llegada " + (distancia * 1.5) + " minutos";
            lblRutasPosibles.Text = "Ruta más corta: ";
            lblDirecciones.Text = string.Join("  ->  " + Environment.NewLine, nombresRuta);
        }

        private void btnExisteCamino_Click(object sender, EventArgs e)
        {
            if (cbOrigen.SelectedItem == null || cbDestino.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un origen y un destino.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string origenNombre = cbOrigen.SelectedItem.ToString();
            string destinoNombre = cbDestino.SelectedItem.ToString();

            int origen = grafo.mapaIndices[origenNombre];
            int destino = grafo.mapaIndices[destinoNombre];

            var conectividad = grafo.Warshall();

            bool existeCamino = conectividad[origen, destino];

            lblNomAlgoritmo.Text = "Algoritmo de Warshall (conectividad)";
            lblTiempo.Text = "¿Existe algún camino entre:";
            lblRutasPosibles.Text = $"\"{origenNombre}\" y \"{destinoNombre}\"?";
            lblDirecciones.Text = (existeCamino ? "Resultado: SÍ existe camino."
                                              : "Resultado: NO existe camino.");
        }
        #endregion

    }
}
