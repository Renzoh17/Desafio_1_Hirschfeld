using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 10f;
    [SerializeField] private int vidaMaxima = 10;

    public void ModificarVida(float puntos)
    {
        if(vida <= vidaMaxima){
            vida += puntos;
        }
        Debug.Log(EstasVivo());
    }

    public void ModificarVidaMax(int vidamax){
        vidaMaxima += vidamax;
    }

    private bool EstasVivo()
    {
        if(vida == 0) {Debug.Log("PERDISTE");}
        return vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Meta")) { return; }

        if(vida > 0){Debug.Log("GANASTE");}
    }
}
