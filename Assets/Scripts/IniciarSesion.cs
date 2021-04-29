using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

/*
 * Script que se encarga de manejar el inicio de sesion del usuario
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class IniciarSesion : MonoBehaviour
{
    public Text resultado;

    public InputField textoUsuario;
    public InputField textoContra;
    public static float tiempoInicial;
    public static float tiempoTotal;
    public int nivel;

    public static IniciarSesion instance;

    void Start()
    {
        tiempoInicial = Time.time;
    }

    // Si el usuario no esta registrado puede picar un boton que abre una nueva pestaña en el navegador en la pagina de /jugador/agregarJugador
    public void Registrar()
    {
        Application.OpenURL("http://3.141.197.134:8080/jugador/agregarJugador");
    }

    // El juegador puede ir al sitio web
    public void PaginaWeb()
    {
        Application.OpenURL("http://3.141.197.134:8080/jugador/iniciarSesion");
    }

    public void InicioSesion()
    {
        StartCoroutine(IniciaSesion());
    }

    // Script para revisar los datos que ingresa el jugador en la pantalla de IniciarSesion
    private IEnumerator IniciaSesion()
    {
        //Encapsular los datos que se suben a la red con el método POST
        WWWForm forma = new WWWForm();
        forma.AddField("usuarioUsuario", textoUsuario.text);  // nombre de usuario
        forma.AddField("passwordUsuario", textoContra.text);  // contrasena

        UnityWebRequest request = UnityWebRequest.Post("http://3.141.197.134:8080/jugador/iniciarSesion", forma);
        yield return request.SendWebRequest();   //Regresa, ejecuta, espera...

        if (request.result == UnityWebRequest.Result.Success)  //200 OK
        {
            string textoPlano = request.downloadHandler.text;  //Datos descargados de la red
            resultado.text = textoPlano;
            if (textoPlano == "Bienvenid@")
            {
                PlayerPrefs.SetString("nombreUsuario", textoUsuario.text);  // guardamos el nombre de usuario en las preferencias
                PlayerPrefs.Save();
                SubirPartida();
                SceneManager.LoadScene("EscenaMenu");
            }
        }
        else
        {
            resultado.text = "Error en la descarga: " + request.responseCode.ToString();
        }
    }

    // Con las siguientes funciones podemos crear partidas
    public void SubirPartida()
    {
        StartCoroutine(CrearPartida());
    }

    public IEnumerator CrearPartida()
    {
        tiempoTotal = Time.time - tiempoInicial;

        WWWForm forma = new WWWForm();
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

    public void Awake()
    {
        instance = this;
    }
}
