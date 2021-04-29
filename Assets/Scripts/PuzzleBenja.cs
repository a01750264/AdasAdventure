using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PuzzleBenja : MonoBehaviour
{
    private int correctas;
    public static float tiempoInicial;
    public static float tiempoTotal;
    private int nivel;
    public GameObject panelGameOver;
    public GameObject panelVictory;
    public Button boton1;
    public Button boton2;
    public Button boton3;
    public Button boton4;
    public Button boton5;
    public Button boton6;
    public Button boton7;
    public Button boton8;
    public Button boton9;
    public Button boton10;
    public Button boton11;
    public Button boton12;
    public Button boton13;
    public Button boton14;
    public Button boton15;
    public Button boton16;
    public Button boton17;
    public Button boton18;
    public Button boton19;
    public Button boton20;
    public Button boton21;
    public Button boton22;
    public Button boton23;
    public Button boton24;
    public Button boton25;

    void Start()
    {
        tiempoInicial = Time.time;
    }

    public void Menu()
    {
        SceneManager.LoadScene("EscenaMenu");
    }

    public void Avanzar()
    {
        SceneManager.LoadScene("HaciaLaCima");
    }

    public void Reset()
    {
        SceneManager.LoadScene("PuzzleBenja");
    }

    public void RevisarRespuesta(Button boton)
    {
        if (boton.tag == "Incorrecto")
        {
            SaludBenja.instance.vidas--;
            HUDBenja.instance.ActualizarVidas();
            if (SaludBenja.instance.vidas == 0)
            {
                nivel = 2;
                SubirPartida();
                panelGameOver.SetActive(true);
            }
        }
        else
        {
            correctas++;
            if (correctas == 19)
            {
                nivel = 3;
                SubirPartida();
                panelVictory.SetActive(true);
            }
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

    public void DeshabilitarBoton1()
    {
        boton1.interactable = false;
        RevisarRespuesta(boton1);
    }

    public void DeshabilitarBoton2()
    {
        boton2.interactable = false;
        RevisarRespuesta(boton2);
    }

    public void DeshabilitarBoton3()
    {
        boton3.interactable = false;
        RevisarRespuesta(boton3);
    }

    public void DeshabilitarBoton4()
    {
        boton4.interactable = false;
        RevisarRespuesta(boton4);
    }

    public void DeshabilitarBoton5()
    {
        boton5.interactable = false;
        RevisarRespuesta(boton5);
    }

    public void DeshabilitarBoton6()
    {
        boton6.interactable = false;
        RevisarRespuesta(boton6);
    }

    public void DeshabilitarBoton7()
    {
        boton7.interactable = false;
        RevisarRespuesta(boton7);
    }

    public void DeshabilitarBoton8()
    {
        boton8.interactable = false;
        RevisarRespuesta(boton8);
    }

    public void DeshabilitarBoton9()
    {
        boton9.interactable = false;
        RevisarRespuesta(boton9);
    }

    public void DeshabilitarBoton10()
    {
        boton10.interactable = false;
        RevisarRespuesta(boton10);
    }

    public void DeshabilitarBoton11()
    {
        boton11.interactable = false;
        RevisarRespuesta(boton11);
    }

    public void DeshabilitarBoton12()
    {
        boton12.interactable = false;
        RevisarRespuesta(boton12);
    }

    public void DeshabilitarBoton13()
    {
        boton13.interactable = false;
        RevisarRespuesta(boton13);
    }

    public void DeshabilitarBoton14()
    {
        boton14.interactable = false;
        RevisarRespuesta(boton14);
    }

    public void DeshabilitarBoton15()
    {
        boton15.interactable = false;
        RevisarRespuesta(boton15);
    }

    public void DeshabilitarBoton16()
    {
        boton16.interactable = false;
        RevisarRespuesta(boton16);
    }

    public void DeshabilitarBoton17()
    {
        boton17.interactable = false;
        RevisarRespuesta(boton17);
    }

    public void DeshabilitarBoton18()
    {
        boton18.interactable = false;
        RevisarRespuesta(boton18);
    }

    public void DeshabilitarBoton19()
    {
        boton19.interactable = false;
        RevisarRespuesta(boton19);
    }

    public void DeshabilitarBoton20()
    {
        boton20.interactable = false;
        RevisarRespuesta(boton20);
    }

    public void DeshabilitarBoton21()
    {
        boton21.interactable = false;
        RevisarRespuesta(boton21);
    }

    public void DeshabilitarBoton22()
    {
        boton22.interactable = false;
        RevisarRespuesta(boton22);
    }

    public void DeshabilitarBoton23()
    {
        boton23.interactable = false;
        RevisarRespuesta(boton23);
    }

    public void DeshabilitarBoton24()
    {
        boton24.interactable = false;
        RevisarRespuesta(boton24);
    }

    public void DeshabilitarBoton25()
    {
        boton25.interactable = false;
        RevisarRespuesta(boton25);
    }
}
