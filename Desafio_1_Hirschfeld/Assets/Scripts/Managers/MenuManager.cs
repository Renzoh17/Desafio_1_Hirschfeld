using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Slider mySlider;
    [SerializeField] private Toggle myToggle;
    
    void Start(){
        mySlider.value = PersistenceManager.Instance.GetFloat("MusicVolumen");
        myToggle.isOn = PersistenceManager.Instance.GetBool("Music");
    }

    private void OnDisable(){
        PersistenceManager.Instance.Save();
    }

    private void OnEnable(){
        PersistenceManager.Instance.SetInt("Puntaje", GameManager.Instance.GetScore());
    }
}
