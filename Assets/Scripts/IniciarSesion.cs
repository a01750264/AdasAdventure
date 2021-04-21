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

    public Text textoUsuario;
    public Text textoContra;

    public GameObject botonJugar;

    public void IniciarJuego()
    {
        SceneManager.LoadScene("EscenaMapa");
    }

    public void EscribirTextoPlano()
    {
        StartCoroutine(SubirTextoPlano());
    }

    private IEnumerator SubirTextoPlano()
    {
        //Encapsular los datos que se suben a la red con el método POST
        WWWForm forma = new WWWForm();
        forma.AddField("usuarioUsuario", textoUsuario.text);
        forma.AddField("passwordUsuario", textoContra.text);

        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/obtenerRegistros", forma);
        yield return request.SendWebRequest();   //Regresa, ejecuta, espera...

        if (request.result == UnityWebRequest.Result.Success)  //200 OK
        {
            string textoPlano = request.downloadHandler.text;  //Datos descargados de la red
            resultado.text = textoPlano;
            if (textoPlano == "Bienvenid@")
            {
                botonJugar.SetActive(true);
                PlayerPrefs.SetString("nombreUsuario", textoUsuario.text);
                PlayerPrefs.Save();
            } else
            {
                botonJugar.SetActive(false);
            }
        }
        else
        {
            resultado.text = "Error en la descarga: " + request.responseCode.ToString();
        }
    }
}
