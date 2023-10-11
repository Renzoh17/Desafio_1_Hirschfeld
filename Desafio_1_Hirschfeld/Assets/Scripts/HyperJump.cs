using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperJump : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] float fuerza = 5f;
    [SerializeField] int puntosexp = 5;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            Saltar salto = other.GetComponent<Saltar>();
            salto.AumentarSalto(fuerza);
            PlayerProgression exp = other.GetComponent<PlayerProgression>();
            exp.GainExperience(puntosexp);
        }
    }
}
