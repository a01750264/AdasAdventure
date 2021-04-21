using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

/*
 * Detecta la colisión del enemigo con el personaje
 * Autor: Roberto Mtz. Román
 */
public class Enemigo : MonoBehaviour
{
    public AudioSource efectoEnemigo;
    public AudioSource efectoMuere;
    public static string fechaHoraFinalString;

    public IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            efectoEnemigo.Play();
            // Descontar una vida
            SaludPersonaje.instance.vidas--;
            // Actualizar los 'corazones'
            HUD.instance.ActualizarVidas();
            if (SaludPersonaje.instance.vidas == 0)
            {
                fechaHoraFinalString = System.DateTime.Now.ToString();
                PlayerPrefs.SetInt("numeroMonedas", SaludPersonaje.instance.monedas);
                PlayerPrefs.Save();
                efectoMuere.Play();
                Destroy(other.gameObject, 3f);

                WWWForm forma = new WWWForm();
                forma.AddField("usuario", PlayerPrefs.GetString("nombreUsuario"));
                forma.AddField("fechaInicio", HUD.fechaHoraInicioString);
                forma.AddField("fechaFinal", fechaHoraFinalString);

                UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/registrarSesion", forma);
                yield return request.SendWebRequest();   //Regresa, ejecuta, espera...

                if (request.result == UnityWebRequest.Result.Success)  //200 OK
                {
                    print(request.downloadHandler.text);  //Datos descargados de la red
                }
                else
                {
                    print("f");
                }
            }
        }
    }
}
