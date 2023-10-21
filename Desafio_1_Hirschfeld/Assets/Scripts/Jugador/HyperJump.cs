using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperJump : MonoBehaviour
{
    [SerializeField] int puntos = 5;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            Saltar salto = other.GetComponent<Saltar>();
            salto.AumentarSalto();
            PlayerProgression exp = other.GetComponent<PlayerProgression>();
            exp.GainExperience(puntos);
            Jugador jugador = other.GetComponent<Jugador>();
            jugador.ModificarVida(puntos);
            Debug.Log(" PUNTOS DE VIDA REGENERADOS AL JUGADOR "+ puntos);
        }
    }
}
