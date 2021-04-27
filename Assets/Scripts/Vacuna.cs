using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Detecta la colisión de la moneda con el personaje
 * Autor: Roberto Mtz. Román
 */
public class Vacuna : MonoBehaviour
{
    // Referencia al AudioSource
    //public AudioSource efectoMoneda;

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
            // Reproducir un efecto de sonido
            //efectoMoneda.Play();
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
