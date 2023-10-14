using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerPerfil;
    
    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        playerPerfil.MiRigidbody2D = GetComponent<Rigidbody2D>();
        playerPerfil.MiAudioSource = GetComponent<AudioSource>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerPerfil.PuedoSaltar)
        {
            playerPerfil.PuedoSaltar = false;
            if(playerPerfil.HyperJumps != 0){playerPerfil.HyperJumps--;}

        if (playerPerfil.MiAudioSource.isPlaying) { return; }
            playerPerfil.MiAudioSource.PlayOneShot(playerPerfil.JumpSFX);
        }
    }

    private void FixedUpdate()
    {
        if (!playerPerfil.PuedoSaltar && !playerPerfil.Saltando)
        {
            playerPerfil.MiRigidbody2D.AddForce(Vector2.up * (playerPerfil.FuerzaSalto + TieneHyperJump()), ForceMode2D.Impulse);
            playerPerfil.Saltando = true;
        }
    }

    // Codigo ejecutado cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerPerfil.PuedoSaltar = true;
        playerPerfil.Saltando = false;


        if(playerPerfil.MiAudioSource.isPlaying) { return; }
            playerPerfil.MiAudioSource.PlayOneShot(playerPerfil.CollisionSFX);
            
    }
    
    public void AumentarSalto(){
        if(playerPerfil.HyperJumps < 2){
            playerPerfil.HyperJumps++;
        }
    }
    private float TieneHyperJump(){
        if(playerPerfil.HyperJumps == 0){return 0f;} 
        return 5f;
    }
}