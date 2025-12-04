using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Clases
{
    public class Grafo
    {
        const int numUbica = 20;
        private int[,] matriz = new int[numUbica, numUbica];

        private int nodos;
        private Dictionary<char, int> mapaIndices = new Dictionary<char, int> { {'a', 0}, {'b', 1}, {'c', 2}, {'e', 3} };
        private Dictionary<int, char> mapaLetras = new Dictionary<int, char> { {0, 'a'}, {1, 'b'}, {2, 'c'}, {3, 'e'} };

        public Grafo()
        {
            nodos = 4;
            matriz = new int[4, 4] {
            {0, 3, 2, 6}, // a
            {0, 0, 0, 9}, // b
            {0, 0, 0, 9}, // c
            {0, 0, 0, 0}  // e
        };
        }

        public void Dijkstra(char inicio, char fin)
        {
            int origen = mapaIndices[inicio];
            int destino = mapaIndices[fin];

            int[] dist = new int[nodos];
            bool[] visitado = new bool[nodos];
            int[] previo = new int[nodos];

            for (int i = 0; i < nodos; i++)
            {
                dist[i] = int.MaxValue;
                visitado[i] = false;
                previo[i] = -1;
            }

            dist[origen] = 0;

            for (int count = 0; count < nodos - 1; count++)
            {
                int u = MinDistancia(dist, visitado);
                if (u == -1) break;
                visitado[u] = true;

                for (int v = 0; v < nodos; v++)
                {
                    if (!visitado[v] && matriz[u, v] > 0 &&
                        dist[u] != int.MaxValue &&
                        dist[u] + matriz[u, v] < dist[v])
                    {
                        dist[v] = dist[u] + matriz[u, v];
                        previo[v] = u;
                    }
                }
            }

            Console.WriteLine("\n[Dijkstra] Ruta más corta de {0} a {1}: {2}", inicio, fin, dist[destino]);
            MostrarRuta(previo, destino);
        }

        private int MinDistancia(int[] dist, bool[] visitado)
        {
            int min = int.MaxValue, min_index = -1;
            for (int v = 0; v < nodos; v++)
            {
                if (!visitado[v] && dist[v] <= min)
                {
                    min = dist[v];
                    min_index = v;
                }
            }
            return min_index;
        }

        private void MostrarRuta(int[] previo, int destino)
        {
            if (previo[destino] == -1)
            {
                Console.WriteLine("No hay ruta.");
                return;
            }

            Stack<int> ruta = new Stack<int>();
            int actual = destino;
            while (actual != -1)
            {
                ruta.Push(actual);
                actual = previo[actual];
            }

            Console.Write("Ruta: ");
            while (ruta.Count > 0)
            {
                Console.Write(mapaLetras[ruta.Pop()] + " ");
            }
            Console.WriteLine();
        }

        public void Floyd()
        {
            int[,] dist = new int[nodos, nodos];
            int[,] next = new int[nodos, nodos];

            for (int i = 0; i < nodos; i++)
            {
                for (int j = 0; j < nodos; j++)
                {
                    dist[i, j] = matriz[i, j] > 0 ? matriz[i, j] : (i == j ? 0 : int.MaxValue);
                    next[i, j] = matriz[i, j] > 0 ? j : -1;
                }
            }

            for (int k = 0; k < nodos; k++)
            {
                for (int i = 0; i < nodos; i++)
                {
                    for (int j = 0; j < nodos; j++)
                    {
                        if (dist[i, k] != int.MaxValue && dist[k, j] != int.MaxValue &&
                            dist[i, k] + dist[k, j] < dist[i, j])
                        {
                            dist[i, j] = dist[i, k] + dist[k, j];
                            next[i, j] = next[i, k];
                        }
                    }
                }
            }

            Console.WriteLine("\n[Floyd] Todas las rutas más cortas:");
            for (int i = 0; i < nodos; i++)
            {
                for (int j = 0; j < nodos; j++)
                {
                    if (i != j && dist[i, j] != int.MaxValue)
                    {
                        Console.Write("Ruta de {0} a {1} (dist: {2}): ", mapaLetras[i], mapaLetras[j], dist[i, j]);
                        MostrarRutaFloyd(next, i, j);
                    }
                }
            }
        }

        private void MostrarRutaFloyd(int[,] next, int u, int v)
        {
            if (next[u, v] == -1)
            {
                Console.WriteLine(" No hay ruta.");
                return;
            }

            Console.Write("{0}", mapaLetras[u]);
            while (u != v)
            {
                u = next[u, v];
                Console.Write(" -> {0}", mapaLetras[u]);
            }
            Console.WriteLine();
        }

        public void Warshall()
        {
            bool[,] alcance = new bool[nodos, nodos];
            for (int i = 0; i < nodos; i++)
                for (int j = 0; j < nodos; j++)
                    alcance[i, j] = matriz[i, j] > 0;

            for (int k = 0; k < nodos; k++)
                for (int i = 0; i < nodos; i++)
                    for (int j = 0; j < nodos; j++)
                        alcance[i, j] = alcance[i, j] || (alcance[i, k] && alcance[k, j]);

            Console.WriteLine("\n[Warshall] Matriz de Alcance (1 = hay camino):");
            for (int i = 0; i < nodos; i++)
            {
                for (int j = 0; j < nodos; j++)
                {
                    Console.Write((alcance[i, j] ? "1" : "0") + " ");
                }
                Console.WriteLine();
            }
        }
    }
}