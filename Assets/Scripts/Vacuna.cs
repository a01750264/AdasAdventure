using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que define el comportamiento de las vacunas (monedas)
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class Vacuna : MonoBehaviour
{
    // Referencia al sistema de partículas
    public ParticleSystem hit;

    // La moneda colisionó con otro objeto (colliders)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Mostrar explosión con el sistema de partículas
            hit.Play();

            // Recolectar
            // Dejar de dibujar a moneda
            GetComponent<SpriteRenderer>().enabled = false;
            // Prender la explosión
            // moneda.transform.hijo del transform(transform de la explosion).explosion.Se hace activa
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            
            Destroy(gameObject, 0.4f);
            
            // Contar monedas
            SaludPersonaje.instance.vacunas += 25;
            HUD.instance.ActualizarVacunas();
        }
    }
}
