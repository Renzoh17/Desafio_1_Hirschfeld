using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetoLoopWithPool : MonoBehaviour
{
    private ObjectPool objectPool;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoEspera;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoIntervalo;

    private void Awake(){
        objectPool =  GetComponent<ObjectPool>();
    }

    void GenerarObjetoLoop()
    {
        GameObject pooledObject = objectPool.GetPooledObject();

        if(pooledObject != null){
            pooledObject.transform.position = transform.position;
            pooledObject.transform.rotation = Quaternion.identity;
            pooledObject.SetActive(true);

        }
    }

    private void OnBecameInvisible()
    {
        Debug.Log("El SpriteRenderer deja de ser visible por las cámaras en la escena");
        CancelInvoke(nameof(GenerarObjetoLoop));
    }

    private void OnBecameVisible()
    {
        Debug.Log("El SpriteRenderer es visible por las cámaras en la escena");
        InvokeRepeating(nameof(GenerarObjetoLoop), tiempoEspera, tiempoIntervalo);
    }
}