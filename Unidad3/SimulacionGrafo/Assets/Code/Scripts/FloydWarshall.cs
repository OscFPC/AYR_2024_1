using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

public class FloydWarshall {
    static int [,] grafo;
    static int [,] matrizDistancias;
    static int [,] matrizTrayectorias;
    static int nodos;

    public void generarGrafo(string filePath)
    {
        List<string[]> matrizOriginal = new List<string[]>();

        using (var reader = new StreamReader(filePath))
        {
            while (!reader.EndOfStream)
            {
                var linea = reader.ReadLine();
                var valores = linea.Split(',');
                matrizOriginal.Add(valores);
            }
        }

        grafo = new int[matrizOriginal.Count, matrizOriginal[0].Length];
        int columnas = matrizOriginal[0].Length;
        int filas = matrizOriginal.Count;

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                switch (matrizOriginal[i][j])
                {
                    case "A":
                        grafo[i, j] = 0;
                        break;
                    case "B":
                        grafo[i, j] = 1;
                        break;
                    case "C":
                        grafo[i, j] = 2;
                        break;
                    case "D":
                        grafo[i, j] = 3;
                        break;
                    case "E":
                        grafo[i, j] = 4;
                        break;
                    case "F":
                        grafo[i, j] = 5;
                        break;
                    case "G":
                        grafo[i, j] = 6;
                        break;
                    case "H":
                        grafo[i, j] = 7;
                        break;
                    case "I":
                        grafo[i, j] = 8;
                        break;
                    case "J":
                        grafo[i, j] = 9;
                        break;
                    case "K":
                        grafo[i, j] = 10;
                        break;
                    case "L":
                        grafo[i, j] = 11;
                        break;
                    default:
                        grafo[i, j] = int.Parse(matrizOriginal[i][j]);
                        break;
                }
            }
        }
    }

    void definirNumeroNodos()
    {
        List<int> arregloAuxiliar = new List<int>();

        for (int i = 0; i < grafo.GetLength(0); i++)
        {
            for (int j = 0; j < grafo.GetLength(1); j++)
            {
                if (!arregloAuxiliar.Contains(grafo[i, j]))
                {
                    arregloAuxiliar.Add(grafo[i, j]);
                }
            }
        }
        nodos = arregloAuxiliar.Count;
    }


    public void generarMatrizDistancias()
    {
        int filas = grafo.GetLength(0);
        definirNumeroNodos();
        matrizDistancias = new int[nodos, nodos];

        for (int i = 0; i < filas; i++)
        {
            int valor1 = grafo[i, 0];
            int valor2 = grafo[i, 1];
            matrizDistancias[valor1, valor2] = grafo[i, 2];
        }

        for (int i = 0; i < nodos; i++)
        {
            for (int j = 0; j < nodos; j++)
            {
                if (matrizDistancias[i, j] == 0 && i != j)
                {
                    matrizDistancias[i, j] = 9999;
                }
            }
        }
    }

    public void generarMatrizTrayectorias()
    {
        matrizTrayectorias = new int[nodos, nodos];

        for (int i = 0; i < nodos; i++)
        {
            for (int j = 0; j < nodos; j++)
            {
                if (matrizDistancias[i, j] == 9999) 
                    matrizTrayectorias[i, j] = -1;
                else 
                    matrizTrayectorias[i, j] = j;
            }
        }
    }

    public void floydWarshall()
    {
        int i, j, k;

        for (k = 0; k < nodos; k++)
        {
            for (i = 0; i < nodos; i++)
            {
                for (j = 0; j < nodos; j++)
                {
                    if (matrizDistancias[i, k] == 9999 || matrizDistancias[k, j] == 9999)
                    {
                        continue;
                    }

                    if (matrizDistancias[i, k] + matrizDistancias[k, j] < matrizDistancias[i, j])
                    {
                        matrizDistancias[i, j] = matrizDistancias[i, k] + matrizDistancias[k, j];
                        matrizTrayectorias[i, j] = matrizTrayectorias[i, k];
                    }
                }
            }
        }
    }

    public List<int> obtenerCaminoEnteros(int u, int v)
    {
        if (matrizTrayectorias[u, v] == -1) return null;

        List<int> camino = new List<int>();
        camino.Add(u);

        while (u!= v)
        {
            u = matrizTrayectorias[u, v];
            camino.Add(u);
        }
        return camino;
    }

    public List<string> obtenerCaminoLetras(List<int> camino)
    {
        List<string> caminoLetras = new List<string>();

        foreach (int nodo in camino)
        {
            int temp_i = nodo + 65;
            string letraInicio = ((char)(temp_i > 90 ? 65 : temp_i)).ToString();
            letraInicio += temp_i <= 90 ? "" : ((char)(temp_i % 91 + 65)).ToString();

            caminoLetras.Add(letraInicio);
        }
        return caminoLetras;
    }
}