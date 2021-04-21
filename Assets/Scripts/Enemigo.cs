using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Detecta la colisión del enemigo con el personaje
 * Autor: Jeovani Hernández Bastida
 */

public class Enemigo : MonoBehaviour
{
    public AudioSource efectoEnemigo;
    public AudioSource efectoMuere;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Reproducir el efecto 
            efectoEnemigo.Play();

            // Descontar una vida
            SaludPersonaje.instance.vidas--;
            // Actualizar los corazones
            HUD.instance.ActualizarVidas();
            if (SaludPersonaje.instance.vidas == 0)
            {
                // Almacenar en Preferencias las Monedas recolectadas
                PlayerPrefs.SetInt("numeroMonedas", SaludPersonaje.instance.monedas);
                PlayerPrefs.Save();     // Inmediato guarda el valor

                efectoMuere.Play();
                Destroy(other.gameObject, t: 0.3f);
                SceneManager.LoadScene("EscenaMenu"); // Pierde, regresa al menú
            }
        }
    }
}

