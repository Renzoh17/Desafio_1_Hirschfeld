using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI miTexto;

    [SerializeField] GameObject iconoJump;
    [SerializeField] GameObject contenedorIconosJump;
    [SerializeField] GameObject menuConfig;

    private void OnEnable(){
        GameEvents.OnPause += Pausar;
        GameEvents.OnResume += Reanudar;
    }

    private void OnDisable(){
        GameEvents.OnPause -= Pausar;
        GameEvents.OnResume -= Reanudar;
    }

    private void Pausar(){
        menuConfig.SetActive(true);
    }

    private void Reanudar(){
        menuConfig.SetActive(false);
    }

    public void UpdateTextHUD(string newText){
        miTexto.text = newText;
    }

    public void UpdateHyperJumpsHUD(int hyperJumps){
        if(EstaVacioContenedor()){
            CargarContenedor(hyperJumps);
            return;
        }

        if(CantidadIconosJumps() > hyperJumps){
            EliminarUltimoIcono();
        }
        else{
            CrearIcono();
        }
    }


    private bool EstaVacioContenedor(){
        return contenedorIconosJump.transform.childCount == 0;
    }

    private int CantidadIconosJumps(){
        return contenedorIconosJump.transform.childCount;
    }

    private void EliminarUltimoIcono(){
        Transform contenedor = contenedorIconosJump.transform;
        GameObject.Destroy(contenedor.GetChild(contenedor.childCount - 1).gameObject);
    }

    private void CargarContenedor(int cantidadIconos){
        for(int i = 0; i < cantidadIconos; i++){
            CrearIcono();
        }
    }

    private void CrearIcono(){
        Instantiate(iconoJump, contenedorIconosJump.transform);
    }
}
