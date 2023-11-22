using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolForProyectiles : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private GameObject objectPrefab2;

    [SerializeField] private int poolSize = 5;

    private List<GameObject> pooledObjects;

    void Start(){
        pooledObjects = new List<GameObject>();

        for(int i = 0; i < poolSize; i++){
            GameObject obj;
            if(Random.Range(0,2) == 0) obj = Instantiate(objectPrefab);
            else obj = Instantiate(objectPrefab2);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject(){
        foreach(GameObject obj in pooledObjects){
            if(!obj.activeInHierarchy){
                return obj;
            }
        }
        return null;
    }
}
