using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperJump : MonoBehaviour
{
    [SerializeField] int puntosexp = 5;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            Saltar salto = other.GetComponent<Saltar>();
            salto.AumentarSalto();
            PlayerProgression exp = other.GetComponent<PlayerProgression>();
            exp.GainExperience(puntosexp);
        }
    }
}
