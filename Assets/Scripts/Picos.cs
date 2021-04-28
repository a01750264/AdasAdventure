using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Picos : MonoBehaviour
{
    public static float tiempoInicial;
    public static float tiempoTotal;
    public int nivel;

    void Start()
    {
        tiempoInicial = Time.time;
    }

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
                SubirPartidaPuntos();
                SceneManager.LoadScene("EscenaMenu"); // Pierde, regresa al menú
            }
        }
    }

    public void SubirPartidaPuntos()
    {
        StartCoroutine(CrearPartidaPuntos());
    }

    public IEnumerator CrearPartidaPuntos()
    {
        tiempoTotal = Time.time - tiempoInicial;

        WWWForm forma = new WWWForm();
        forma.AddField("puntuacion", SaludPersonaje.instance.vidas.ToString());
        forma.AddField("usuario", PlayerPrefs.GetString("nombreUsuario"));
        forma.AddField("progreso", nivel);
        forma.AddField("tiempo", tiempoTotal.ToString());

        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/partida/agregarPartida", forma);

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
