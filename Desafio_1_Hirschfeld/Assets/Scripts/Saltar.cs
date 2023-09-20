using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{

    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] private float fuerzaSalto = 5f;
    [SerializeField] private float fuerzaSaltoaux = 0f;
    [SerializeField] private int hyperJumps = 0;

    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip collisionSFX;

    // Variables de uso interno en el script
    private bool puedoSaltar = true;
    private bool saltando = false;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private AudioSource miAudioSource;

    
    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAudioSource = GetComponent<AudioSource>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            puedoSaltar = false;
            if(hyperJumps != 0){hyperJumps--;}

        if (miAudioSource.isPlaying) { return; }
            miAudioSource.PlayOneShot(jumpSFX);
        }
    }

    private void FixedUpdate()
    {
        if (!puedoSaltar && !saltando)
        {
            miRigidbody2D.AddForce(Vector2.up * (fuerzaSalto + fuerzaSaltoaux), ForceMode2D.Impulse);
            saltando = true;
        }
    }

    // Codigo ejecutado cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        puedoSaltar = true;
        saltando = false;

        if(hyperJumps == 0){fuerzaSaltoaux = 0f;}

        if(miAudioSource.isPlaying) { return; }
            miAudioSource.PlayOneShot(collisionSFX);
            
    }
    
    public void AumentarSalto(float fuerza){
        fuerzaSaltoaux += fuerza;
        if(hyperJumps <= 2){
            hyperJumps++;
        }
    }
}