using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerPerfil;
    
    public void ModificarVida(float puntos)
    {
        if(playerPerfil.Vida <= playerPerfil.VidaMaxima){
            playerPerfil.Vida += puntos;
        }
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
