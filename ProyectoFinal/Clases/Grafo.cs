namespace ProyectoFinal.Clases
{
    public class Grafo
    {
        public const int INF = int.MaxValue / 4; //Constante utilizada para inicializar el grafo, representa un valor "infinito"
        public string[] Lugares;
        public Dictionary<string, int> mapaIndices;
        public Dictionary<int, string> mapaNombres;
        private int[,] matriz;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Grafo()
        {
            InicializarLugares();
            InicializarMatriz();
            InicializarCalles();
        }

        #region Métodos privados

        /// <summary>
        /// Llena array con lugares, alamcena información de lugares e indices en diccionarios.
        /// </summary>
        private void InicializarLugares()
        {
            //Llena array de lugares
            Lugares = new[]
            {
                "Familia Saucedo",             // 0
                "Multiplaza Escazú",           // 1
                "Familia Urbina",              // 2
                "Universidad Hispanoamericana",// 3
                "Parque Norte",                // 4
                "Hospital Clínica Bíblica",    // 5
                "Iglesia de la Soledad",       // 6
                "Familia Oviedo",              // 7
                "Multiplaza Curridabat",       // 8
                "Familia Durán",               // 9
                "Hospital la Catolica",        // 10
                "El Chino",                    // 11
                "Familia Curling",             // 12
                "Parque Central",              // 13
                "Universidad de Costa Rica",   // 14
                "Parque Oeste",                // 15
                "Familia Arazi",               // 16
                "Familia Cambronero",          // 17
                "Familia López",               // 18
                "Parque Sur"                   // 19
            };

            //Inicializa los diccionarios vacíos
            mapaIndices = new Dictionary<string, int>();
            mapaNombres = new Dictionary<int, string>();

            //Recorre el arreglo de lugares y llena los diccionarios
            for (int i = 0; i < Lugares.Length; i++)
            {
                mapaIndices[Lugares[i]] = i;
                mapaNombres[i] = Lugares[i];
            }
        }

        /// <summary>
        /// Inicializa la matriz
        /// </summary>
        private void InicializarMatriz()
        {
            int tamanio = Lugares.Length; //tamaño del array
            matriz = new int[tamanio, tamanio]; //inicializa matriz según el tamaño de la lista

            for (int i = 0; i < tamanio; i++)
            {
                for (int j = 0; j < tamanio; j++)
                {
                    //asigna valor a la matriz
                    matriz[i, j] = (i == j) ? 0 //mismo nodo
                                        : INF; //valor "infinito"
                }
            }
        }

        /// <summary>
        /// Asigna el peso 
        /// </summary>
        /// <param name="origen"></param>
        /// <param name="destino"></param>
        /// <param name="peso"></param>
        private void AgregarConexion(string origen, string destino, int peso)
        {
            int i = mapaIndices[origen];
            int j = mapaIndices[destino];
            matriz[i, j] = peso;
            matriz[j, i] = peso; 
        }

        /// <summary>
        /// Agrega cada conexión en el mapa y le asigna el costo entre cada una de ellas
        /// </summary>
        private void InicializarCalles()
        {
            AgregarConexion("Familia Saucedo", "Multiplaza Escazú", 3);
            AgregarConexion("Familia Saucedo", "Familia Urbina", 3);

            AgregarConexion("Multiplaza Escazú", "Familia Urbina", 3);
            AgregarConexion("Multiplaza Escazú", "Universidad Hispanoamericana", 3);

            AgregarConexion("Familia Urbina", "Universidad de Costa Rica", 4);

            AgregarConexion("Universidad Hispanoamericana", "Parque Norte", 7);
            AgregarConexion("Universidad Hispanoamericana", "Iglesia de la Soledad", 5);

            AgregarConexion("Parque Norte", "Hospital Clínica Bíblica", 5);
            AgregarConexion("Parque Norte", "Iglesia de la Soledad", 2);

            AgregarConexion("Iglesia de la Soledad", "Parque Central", 6);
            AgregarConexion("Iglesia de la Soledad", "Hospital Clínica Bíblica", 10);

            AgregarConexion("Hospital Clínica Bíblica", "Familia Oviedo", 3);

            AgregarConexion("Familia Oviedo", "Multiplaza Curridabat", 4);
            AgregarConexion("Familia Oviedo", "Iglesia de la Soledad", 6);

            AgregarConexion("Multiplaza Curridabat", "El Chino", 3);

            AgregarConexion("El Chino", "Familia Curling", 7);
            AgregarConexion("El Chino", "Familia Durán", 4);

            AgregarConexion("Familia Durán", "Hospital la Catolica", 5);

            AgregarConexion("Hospital la Catolica", "Parque Sur", 8);
            AgregarConexion("Hospital la Catolica", "El Chino", 3);

            AgregarConexion("Parque Central", "El Chino", 6);
            AgregarConexion("Parque Central", "Universidad Hispanoamericana", 4);

            AgregarConexion("Parque Sur", "Familia López", 9);
            AgregarConexion("Parque Sur", "Familia Cambronero", 10);

            AgregarConexion("Familia López", "Familia Arazi", 6);

            AgregarConexion("Familia Cambronero", "Familia Curling", 5);
            AgregarConexion("Familia Cambronero", "Familia Arazi", 6);

            AgregarConexion("Familia Arazi", "Parque Oeste", 4);

            AgregarConexion("Parque Oeste", "Universidad de Costa Rica", 7);
            AgregarConexion("Parque Oeste", "Familia Saucedo", 6);

            AgregarConexion("Universidad de Costa Rica", "Parque Central", 2);
            AgregarConexion("Universidad de Costa Rica", "Familia Curling", 4);
        }

        #endregion

        #region Métodos públicos
        /// <summary>
        /// Devuelve el nombre del camino según el indice
        /// </summary>
        /// <param name="camino"></param>
        /// <returns></returns>
        public List<string> ConvertirCaminoANombres(List<int> camino)
        {
            List<string> nombres = new List<string>();
            foreach (int indice in camino)
            {
                nombres.Add(mapaNombres[indice]);
            }
            return nombres;
        }
        
        /// <summary>
        /// Algoritmo Dijkstra muestra la ruta más corta
        /// </summary>
        /// <param name="origen"></param>
        /// <param name="destino"></param>
        /// <returns></returns>
        public (int distancia, List<int> camino) Dijkstra(int origen, int destino)
        {
            int n = Lugares.Length;
            int[] dist = new int[n];
            bool[] visitado = new bool[n];
            int[] previo = new int[n];

            for (int i = 0; i < n; i++)
            {
                dist[i] = INF;
                visitado[i] = false;
                previo[i] = -1;
            }

            dist[origen] = 0;

            for (int k = 0; k < n - 1; k++)
            {
                int u = -1;
                int minDist = INF;

                for (int i = 0; i < n; i++)
                {
                    if (!visitado[i] && dist[i] < minDist)
                    {
                        minDist = dist[i];
                        u = i;
                    }
                }

                if (u == -1 || dist[u] == INF)
                    break;

                visitado[u] = true;

                for (int v = 0; v < n; v++)
                {
                    if (!visitado[v] && matriz[u, v] < INF)
                    {
                        int nuevaDist = dist[u] + matriz[u, v];
                        if (nuevaDist < dist[v])
                        {
                            dist[v] = nuevaDist;
                            previo[v] = u;
                        }
                    }
                }
            }

            if (dist[destino] == INF)
            {
                return (INF, null);
            }

            // Reconstruir camino
            List<int> camino = new List<int>();
            int actual = destino;
            while (actual != -1)
            {
                camino.Add(actual);
                actual = previo[actual];
            }
            camino.Reverse();

            return (dist[destino], camino);
        }

        /// <summary>
        /// Muestra todas las rutas posibles
        /// </summary>
        /// <param name="dist"></param>
        /// <param name="next"></param>
        public void Floyd(out int[,] dist, out int[,] next)
        {
            int n = Lugares.Length;
            dist = new int[n, n];
            next = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dist[i, j] = matriz[i, j];
                    if (i != j && matriz[i, j] < INF)
                        next[i, j] = j;
                    else
                        next[i, j] = -1;
                }
            }

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (dist[i, k] >= INF) continue;
                    for (int j = 0; j < n; j++)
                    {
                        if (dist[k, j] >= INF) continue;

                        int nuevaDist = dist[i, k] + dist[k, j];
                        if (nuevaDist < dist[i, j])
                        {
                            dist[i, j] = nuevaDist;
                            next[i, j] = next[i, k];
                        }
                    }
                }
            }
        }

        public List<int> ReconstruirCaminoFloyd(int origen, int destino, int[,] next)
        {
            if (next[origen, destino] == -1)
                return null;

            List<int> camino = new List<int> { origen };
            while (origen != destino)
            {
                origen = next[origen, destino];
                if (origen == -1) return null;
                camino.Add(origen);
            }
            return camino;
        }

        /// <summary>
        /// Verifica si existe al menos una ruta
        /// </summary>
        /// <returns></returns>
        public bool[,] Warshall()
        {
            int nodos = Lugares.Length;
            bool[,] alcance = new bool[nodos, nodos];

            for (int i = 0; i < nodos; i++)
            {
                for (int j = 0; j < nodos; j++)
                    alcance[i, j] = (matriz[i, j] < INF);
                alcance[i, i] = true;
            }

            for (int k = 0; k < nodos; k++)
            {
                for (int i = 0; i < nodos; i++)
                {
                    if (!alcance[i, k]) continue;
                    for (int j = 0; j < nodos; j++)
                    {
                        if (alcance[i, j]) continue;
                        if (alcance[i, k] && alcance[k, j])
                            alcance[i, j] = true;
                    }
                }
            }

            return alcance;
        }

        #endregion

    }
}