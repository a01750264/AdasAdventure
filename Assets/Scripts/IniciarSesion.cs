using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

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

    public void Registrar()
    {
        Application.OpenURL("http://localhost:8080/jugador/agregarJugador");
    }

    public void PaginaWeb()
    {
        Application.OpenURL("http://localhost:8080/jugador/iniciarSesion");
    }

    public void InicioSesion()
    {
        StartCoroutine(IniciaSesion());
    }

    private IEnumerator IniciaSesion()
    {
        //Encapsular los datos que se suben a la red con el método POST
        WWWForm forma = new WWWForm();
        forma.AddField("usuarioUsuario", textoUsuario.text);
        forma.AddField("passwordUsuario", textoContra.text);

        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/jugador/iniciarSesion", forma);
        yield return request.SendWebRequest();   //Regresa, ejecuta, espera...

        if (request.result == UnityWebRequest.Result.Success)  //200 OK
        {
            string textoPlano = request.downloadHandler.text;  //Datos descargados de la red
            resultado.text = textoPlano;
            if (textoPlano == "Bienvenid@")
            {
                PlayerPrefs.SetString("nombreUsuario", textoUsuario.text);
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

    public void Awake()
    {
        instance = this;
    }
}
