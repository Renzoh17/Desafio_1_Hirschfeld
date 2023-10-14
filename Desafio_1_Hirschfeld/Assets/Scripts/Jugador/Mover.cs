using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{   
    [SerializeField]
    private PlayerData playerPerfil;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        playerPerfil.MiRigidbody2D = GetComponent<Rigidbody2D>();
        playerPerfil.MiAnimator = GetComponent<Animator>();
        playerPerfil.MiSprite = GetComponent<SpriteRenderer>();
        playerPerfil.MiCollider2D = GetComponent<PolygonCollider2D>();
        playerPerfil.SaltarMask = LayerMask.GetMask("Pisos", "Plataformas", "Enemigos");
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        playerPerfil.MoverHorizontal = Input.GetAxis("Horizontal");
        playerPerfil.Direccion = new Vector2(playerPerfil.MoverHorizontal, 0f);
       
        int velocidadX = (int)playerPerfil.MiRigidbody2D.velocity.x;
        playerPerfil.MiSprite.flipX = velocidadX < 0;
        playerPerfil.MiAnimator.SetInteger("Velocidad", velocidadX);

        playerPerfil.MiAnimator.SetBool("EnAire", !EnContactoConPlataforma());
        
    }

    private void FixedUpdate()
    {
        playerPerfil.MiRigidbody2D.AddForce(playerPerfil.Direccion * playerPerfil.Velocidad);
    }

    private bool EnContactoConPlataforma()
    {
        return playerPerfil.MiCollider2D.IsTouchingLayers(playerPerfil.SaltarMask);
    }
}



