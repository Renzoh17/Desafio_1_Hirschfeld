using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilRecto : Proyectil
{
    protected override void Mover()
    {
        Vector2 direccion = Vector2.left;
        //Aplica velocidad al RigidBody
        rb.velocity = direccion * velocidad;
    }
}
