using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class Moverse : MonoBehaviour
{
    FloydWarshall fw = new FloydWarshall();
    List<int> caminoEnteros;
    public int nodoActual = 0;
    public int nodoDestino = 0;
    private string[] letras = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L"};
    private Transform[] nodos;
    public float velocidadRotacion = 20f;
    public float velocidadMovimiento = 15f;
    private bool seMueve = false;

    // Start is called before the first frame update
    void Start()
    {
        nodos = new Transform[letras.Length];

        for (int i = 0; i < letras.Length; i++)
        {   
            nodos[i] = GameObject.Find("NODO" + letras[i]).transform;
        }

        fw.generarGrafo("C:/Users/JArellano/Desktop/AYR_2024_1/Unidad3/SimulacionGrafo/Assets/Code/Scripts/Caminos.csv");
        fw.generarMatrizDistancias();
        fw.generarMatrizTrayectorias();
        fw.floydWarshall(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && nodoActual != 0)
        {
            nodoDestino = 0;
            caminoEnteros = fw.obtenerCaminoEnteros(nodoActual, nodoDestino);
            seMueve = true;
        }
        if (Input.GetKeyUp(KeyCode.A) && seMueve)
        {
            StartCoroutine(iterarCamino());
        }

        if (Input.GetKeyDown(KeyCode.B) && nodoActual != 1)
        {
            nodoDestino = 1;
            caminoEnteros = fw.obtenerCaminoEnteros(nodoActual, nodoDestino);
            seMueve = true;
        }
        if (Input.GetKeyUp(KeyCode.B) && seMueve)
        {
            StartCoroutine(iterarCamino());
        }

        if (Input.GetKeyDown(KeyCode.C) && nodoActual != 2)
        {
            nodoDestino = 2;
            caminoEnteros = fw.obtenerCaminoEnteros(nodoActual, nodoDestino);
            seMueve = true;
        }
        if (Input.GetKeyUp(KeyCode.C) && seMueve)
        {
            StartCoroutine(iterarCamino());
        }

        if (Input.GetKeyDown(KeyCode.D) && nodoActual != 3)
        {
            nodoDestino = 3;
            caminoEnteros = fw.obtenerCaminoEnteros(nodoActual, nodoDestino);
            seMueve = true;
        }
        if (Input.GetKeyUp(KeyCode.D) && seMueve)
        {
            StartCoroutine(iterarCamino());
        }

        if (Input.GetKeyDown(KeyCode.E) && nodoActual != 4)
        {
            nodoDestino = 4;
            caminoEnteros = fw.obtenerCaminoEnteros(nodoActual, nodoDestino);
            seMueve = true;
        }
        if (Input.GetKeyUp(KeyCode.E) && seMueve)
        {
            StartCoroutine(iterarCamino());
        }

        if (Input.GetKeyDown(KeyCode.F) && nodoActual != 5)
        {
            nodoDestino = 5;
            caminoEnteros = fw.obtenerCaminoEnteros(nodoActual, nodoDestino);
            seMueve = true;
        }
        if (Input.GetKeyUp(KeyCode.F) && seMueve)
        {
            StartCoroutine(iterarCamino());
        }

        if (Input.GetKeyDown(KeyCode.G) && nodoActual != 6)
        {
            nodoDestino = 6;
            caminoEnteros = fw.obtenerCaminoEnteros(nodoActual, nodoDestino);
            seMueve = true;
        }
        if (Input.GetKeyUp(KeyCode.G) && seMueve)
        {
            StartCoroutine(iterarCamino());
        }

        if (Input.GetKeyDown(KeyCode.H) && nodoActual != 7)
        {
            nodoDestino = 7;
            caminoEnteros = fw.obtenerCaminoEnteros(nodoActual, nodoDestino);
            seMueve = true;
        }
        if (Input.GetKeyUp(KeyCode.H) && seMueve)
        {
            StartCoroutine(iterarCamino());
        }

        if (Input.GetKeyDown(KeyCode.I) && nodoActual != 8)
        {
            nodoDestino = 8;
            caminoEnteros = fw.obtenerCaminoEnteros(nodoActual, nodoDestino);
            seMueve = true;
        }
        if (Input.GetKeyUp(KeyCode.I) && seMueve)
        {
            StartCoroutine(iterarCamino());
        }

        if (Input.GetKeyDown(KeyCode.J) && nodoActual != 9)
        {
            nodoDestino = 9;
            caminoEnteros = fw.obtenerCaminoEnteros(nodoActual, nodoDestino);
            seMueve = true;
        }
        if (Input.GetKeyUp(KeyCode.J) && seMueve)
        {
            StartCoroutine(iterarCamino());
        }

        if (Input.GetKeyDown(KeyCode.K) && nodoActual != 10)
        {
            nodoDestino = 10;
            caminoEnteros = fw.obtenerCaminoEnteros(nodoActual, nodoDestino);
            seMueve = true;
        }
        if (Input.GetKeyUp(KeyCode.K) && seMueve)
        {
            StartCoroutine(iterarCamino());
        }

        if (Input.GetKeyDown(KeyCode.L) && nodoActual != 11)
        {
            nodoDestino = 11;
            caminoEnteros = fw.obtenerCaminoEnteros(nodoActual, nodoDestino);
            seMueve = true;
        }
        if (Input.GetKeyUp(KeyCode.L) && seMueve)
        {
            StartCoroutine(iterarCamino());
        }

    }
//----------------------------------------------------------------
    IEnumerator iterarCamino()
    {
        for (int i = 1; i < caminoEnteros.Count; i++)
        {
            //Ejecuta rotarAvanzar para el elemento con el indice equivalente al valor de caminoEnteros en i
            yield return StartCoroutine(rotarAvanzar(nodos[caminoEnteros[i]]));
            Debug.Log("Llego a " + letras[caminoEnteros[i]]);
        }
        nodoActual = nodoDestino;
        seMueve = false;
    }

//---------------------------------------------------------------
    IEnumerator rotarAvanzar(Transform siguienteNodo)
    {
        Vector3 posicionFinal = siguienteNodo.position; // Posición del nodo al que va a avanzar
        // Vector3 direccion = (posicionFinal - transform.position).normalized;

        Quaternion rotacionObjetivo = Quaternion.LookRotation(posicionFinal - transform.position);

        while (Quaternion.Angle(transform.rotation, rotacionObjetivo) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, 
            velocidadRotacion * Time.deltaTime);
            yield return null;
        }

        while (Vector3.Distance(transform.position, posicionFinal) > 0.18f)
        {
            transform.position = Vector3.MoveTowards(transform.position, posicionFinal, 
            velocidadMovimiento * Time.deltaTime);
            yield return null;
        }
    }
}