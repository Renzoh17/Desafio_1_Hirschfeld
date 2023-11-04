using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour
{

    public static ApplicationManager Instance {get; private set;}

    void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    public void GoToNextScene(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex < SceneManager.sceneCountInBuildSettings){
            SceneManager.LoadScene(nextSceneIndex);
        }
        else{
            Debug.LogWarning("No hay más escenas despúes de la actual en Build Settings.");
        }
    }

    public void GoToPreviusScene(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int previusSceneIndex = currentSceneIndex - 1;

        if(previusSceneIndex >= 0){
            SceneManager.LoadScene(previusSceneIndex);
        }
        else{
            Debug.LogWarning("No hay más escenas despúes de la actual en Build Settings.");
        }
    }
}
