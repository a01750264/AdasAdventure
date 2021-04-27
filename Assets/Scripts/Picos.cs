using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Picos : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Reproducir el efecto 
            //efectoEnemigo.Play();

            // Descontar una vida
            SaludPersonaje.instance.vidas--;
            // Actualizar los corazones
            HUD.instance.ActualizarVidas();
            if (SaludPersonaje.instance.vidas == 0)
            {
                // Almacenar en Preferencias las Monedas recolectadas
                PlayerPrefs.SetInt("numeroVacunas", SaludPersonaje.instance.vacunas);
                PlayerPrefs.Save();     // Inmediato guarda el valor
                
                //efectoMuere.Play();
                Destroy(other.gameObject, t: 0.3f);
                SceneManager.LoadScene("EscenaMenu"); // Pierde, regresa al menú
            }
        }
    }
}
