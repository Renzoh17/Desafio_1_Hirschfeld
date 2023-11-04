using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{
    private Jugador misDatos;
    
    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        misDatos = GetComponent<Jugador>();
        misDatos.PlayerPerfil.MiRigidbody2D = GetComponent<Rigidbody2D>();
        misDatos.PlayerPerfil.MiAudioSource = GetComponent<AudioSource>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && misDatos.PlayerPerfil.PuedoSaltar)
        {
            misDatos.PlayerPerfil.PuedoSaltar = false;
            if(misDatos.PlayerPerfil.HyperJumps != 0){misDatos.PlayerPerfil.HyperJumps--;}

        if (misDatos.PlayerPerfil.MiAudioSource.isPlaying) { return; }
            misDatos.PlayerPerfil.MiAudioSource.PlayOneShot(misDatos.PlayerPerfil.JumpSFX);
        }
    }

    private void FixedUpdate()
    {
        if (!misDatos.PlayerPerfil.PuedoSaltar && !misDatos.PlayerPerfil.Saltando)
        {
            misDatos.PlayerPerfil.MiRigidbody2D.AddForce(Vector2.up * (misDatos.PlayerPerfil.FuerzaSalto + TieneHyperJump()), ForceMode2D.Impulse);
            misDatos.PlayerPerfil.Saltando = true;
        }
    }

    // Codigo ejecutado cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        misDatos.PlayerPerfil.PuedoSaltar = true;
        misDatos.PlayerPerfil.Saltando = false;


        if(misDatos.PlayerPerfil.MiAudioSource.isPlaying) { return; }
            misDatos.PlayerPerfil.MiAudioSource.PlayOneShot(misDatos.PlayerPerfil.CollisionSFX);
            
    }
    
    public void AumentarSalto(){
        if(misDatos.PlayerPerfil.HyperJumps < 2){
            misDatos.PlayerPerfil.HyperJumps++;
        }
    }
    private float TieneHyperJump(){
        if(misDatos.PlayerPerfil.HyperJumps == 0){return 0f;} 
        return 5f;
    }
}