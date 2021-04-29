using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

/*
 * Detecta la colisión del enemigo con el personaje
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class Enemigo : MonoBehaviour
{
    public static float tiempoInicial;
    public static float tiempoTotal;
    public string pierde;
    public int nivel;

    void Start()
    {
        tiempoInicial = Time.time;  // Sacamos el tiempo en el que inicio la escena
    }

    public void OnTriggerEnter2D(Collider2D other)  // Detectamos colision entre jugador y enemigo
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Descontar una vida
            SaludPersonaje.instance.vidas--;
            // Actualizar los corazones de HUD
            HUD.instance.ActualizarVidas();
            if (SaludPersonaje.instance.vidas == 0)
            {
                // Almacenar en Preferencias las Monedas recolectadas
                PlayerPrefs.SetInt("numeroVacunas", SaludPersonaje.instance.vacunas);
                PlayerPrefs.Save();     // Inmediato guarda el valor
                
                Destroy(other.gameObject, t: 0.3f);
                SubirPartidaPuntos();  // Crear una partida en la base de datos
                SceneManager.LoadScene(pierde); // Pierde, regresa al menú
            }
        } else if (other.gameObject.CompareTag("disparo"))
        {
            Destroy(gameObject);
        }
    }

    public void SubirPartidaPuntos()
    {
        StartCoroutine(CrearPartidaPuntos());  // Corutina para crear una partida en la base de datos
    }

    // Codigo para subir una partida a la base de datos por medio de un metodo POST
    public IEnumerator CrearPartidaPuntos()
    {
        tiempoTotal = Time.time - tiempoInicial;  // Calculamos el tiempo en el que se manda a llamar este metodo para calcular el tiempo que paso el jugador en la escena

        WWWForm forma = new WWWForm();
        forma.AddField("puntuacion", SaludPersonaje.instance.vacunas.ToString());
        forma.AddField("usuario", PlayerPrefs.GetString("nombreUsuario"));
        forma.AddField("progreso", nivel);
        forma.AddField("tiempo", tiempoTotal.ToString());

        UnityWebRequest request = UnityWebRequest.Post("http://3.141.197.134:8080/partida/agregarPartida", forma);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)  //200 OK
        {
            string textoPlano = request.downloadHandler.text;  //Datos descargados de la red
            print(textoPlano);
        }
        else
        {
            print("Error en la descarga: ");
        }
    }
}

