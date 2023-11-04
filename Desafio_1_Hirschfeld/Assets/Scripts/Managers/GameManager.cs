using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    
    private int score;

    private void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    private void OnEnable(){
        GameEvents.OnPause += Pausar;
        GameEvents.OnResume += Reanudar;
    }

    private void OnDisable(){
        GameEvents.OnPause -= Pausar;
        GameEvents.OnResume -= Reanudar;

    }

    private void Pausar(){
        Time.timeScale = 0;
        Debug.Log("PAUSADO");
    }

    private void Reanudar(){
        Time.timeScale = 1;
        Debug.Log("REANUDADO");
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(Time.timeScale != 0){
                GameEvents.TriggerPause();
            }
            else{
                GameEvents.TriggerResume();
            }
        }
    }

    public void AddScore(int points){
        score += points;

        if(score < 0){
            ApplicationManager.Instance.GoToPreviusScene();
        }
    }

    public void ResetScore(){
        score = 0;
    }

    public int GetScore(){
        return score;
    }
}
