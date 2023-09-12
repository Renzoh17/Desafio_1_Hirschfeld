using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperJump : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] float puntos = 5f;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            Saltar salto = other.GetComponent<Saltar>();
            salto.AumentarSalto(puntos);
        }
    }
}
