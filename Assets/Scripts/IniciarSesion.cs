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

    public void Registrar()
    {
        Application.OpenURL("http://localhost:8080/jugador/agregarJugador");
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
                SceneManager.LoadScene("EscenaMenu");
            }
        }
        else
        {
            resultado.text = "Error en la descarga: " + request.responseCode.ToString();
        }
    }
}
