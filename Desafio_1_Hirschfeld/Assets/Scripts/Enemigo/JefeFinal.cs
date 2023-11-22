using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFinal : MonoBehaviour
{
    [SerializeField] [Range(0.5f, 5f)] float tiempoEntreDisparos;
    [SerializeField] [Range(0.5f, 5f)] float tiempoIntervaloEntreDisparos;
    [SerializeField] float tiempoEntreEmbestidas;
    [SerializeField] float tiempoEntreMovimientos;

    [SerializeField] GameObject prefabProyectil;
    [SerializeField] GameObject prefabProyectil2;
    [SerializeField] Transform puntoSpawnProyectil;

    private float tiempoActualEspera;
    private int estadoActual;

    // Estados del jefe
    private const int DispararProyectil = 0;
    private const int Embestir = 1;
    private const int Mover = 2;

    private ObjectPool objectPool;

    private void Awake(){
        objectPool = GetComponent<ObjectPool>();
    }

    void Start()
    {
        estadoActual = DispararProyectil;
        
        StartCoroutine(ComportamientoJefe());
    }

    private IEnumerator ComportamientoJefe()
    {
        while (true)
        {
            switch (estadoActual)
            {
                case DispararProyectil:
                    StartCoroutine(Disparar());
                    tiempoActualEspera = tiempoEntreDisparos;
                    break;
                case Embestir:
                    StartCoroutine(Embestida());
                    tiempoActualEspera = tiempoEntreEmbestidas;
                    break;
                case Mover:
                    StartCoroutine(Movimiento());
                    tiempoActualEspera = tiempoEntreMovimientos;
                    break;
            }
            Debug.Log(estadoActual);
            yield return new WaitForSeconds(tiempoActualEspera);
            ActualizarEstado();
        }
    }

    private IEnumerator Disparar()
    {
        for (int i = 0; i < 3; i++)
        {
                yield return new WaitForSeconds(0.5f);
                InvokeRepeating(nameof(GeneradorProyectiles), tiempoEntreDisparos, tiempoIntervaloEntreDisparos);
        }
    }

    private IEnumerator Embestida()
    {
        float tiempoEmbestida = 2f;
        float tiempoInicio = Time.time;
        float velocidadEmbestida = -10f; // Ajusta la velocidad de la embestida según tus necesidades

        Vector2 posicionInicial = transform.position;
        Vector2 posicionObjetivo = new Vector2(transform.position.x + velocidadEmbestida, transform.position.y);

        // Mover hacia adelante
        while (Time.time < tiempoInicio + tiempoEmbestida / 2)
        {
            transform.position = Vector2.Lerp(posicionInicial, posicionObjetivo, (Time.time - tiempoInicio) / (tiempoEmbestida / 2));
            yield return null;
        }
        // Mover hacia atrás (retroceso)
        tiempoInicio = Time.time;
        while (Time.time < tiempoInicio + tiempoEmbestida / 2)
        {
            transform.position = Vector2.Lerp(posicionObjetivo, posicionInicial, (Time.time - tiempoInicio) / (tiempoEmbestida / 2));
            yield return null;
        }
    }

    private IEnumerator Movimiento()
    {
        float tiempoMovimiento = 3f; // Ajusta la duración del movimiento según tus necesidades
        float tiempoInicio = Time.time;
        float velocidadMovimiento = 6f;

        Vector2 posicionInicial = transform.position;
        Vector2 posicionObjetivo = new Vector2(transform.position.x, transform.position.y + velocidadMovimiento);

        // Mover hacia la posición objetivo
        while (Time.time < tiempoInicio + tiempoMovimiento / 2)
        {
            transform.position = Vector2.Lerp(posicionInicial, posicionObjetivo, (Time.time - tiempoInicio) / (tiempoMovimiento / 2));
            yield return null;
        }

        // Mover hacia la posición inicial
        tiempoInicio = Time.time;
        while (Time.time < tiempoInicio + tiempoMovimiento / 2)
        {
            transform.position = Vector2.Lerp(posicionObjetivo, posicionInicial, (Time.time - tiempoInicio) / (tiempoMovimiento / 2));
            yield return null;
        }
    }

    private void ActualizarEstado()
    {
        // Actualiza el estado actual según las probabilidades y condiciones que desees
        // Puedes usar Random.Range para generar números aleatorios y decidir el siguiente estado
        estadoActual = Random.Range(0, 3);
    }

    void GeneradorProyectiles(){
        GameObject pooledObject = objectPool.GetPooledObject();

        if(pooledObject != null){
            pooledObject.transform.position =  transform.position;
            pooledObject.transform.rotation = Quaternion.identity;
            pooledObject.SetActive(true);
        }
    }
}
