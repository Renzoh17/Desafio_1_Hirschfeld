using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerPerfil;

    //Eventos del Jugador

    [SerializeField]
    private UnityEvent<int> OnLivesChanged;

    [SerializeField]
    private UnityEvent<string> OnTextChanged;

    private void Start(){
        OnLivesChanged.Invoke(playerPerfil.Vida);
        OnTextChanged.Invoke(playerPerfil.Vida.ToString());
        
    }
    
    public void ModificarVida(int puntos)
    {
        if(puntos == 5 && playerPerfil.Vida < playerPerfil.VidaMaxima){
                playerPerfil.Vida += puntos;
        }
        if(puntos == -5 && playerPerfil.Vida != 0){
                playerPerfil.Vida += puntos;
        }
        OnTextChanged.Invoke(playerPerfil.Vida.ToString());
        Debug.Log(EstasVivo());
    }

    public void ModificarVidaMax(int vidamax){
        playerPerfil.VidaMaxima += vidamax;
    }

    private bool EstasVivo()
    {
        if(playerPerfil.Vida == 0) {Debug.Log("PERDISTE");}
        return playerPerfil.Vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Meta")) { return; }

        if(playerPerfil.Vida > 0){Debug.Log("GANASTE");}
    }
}
