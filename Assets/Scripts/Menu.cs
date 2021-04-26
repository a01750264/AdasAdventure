using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Controla los metodos para atender los componentes del men�
 * Autores: 
 *          Eduardo Acosta Hern�ndez
 *          Eric Alexis Casta�eda Bravo
 *          Jeovani Hern�ndez Bastida
 *          Jose Benjam�n Ru�z Garc�a          
 */

public class Menu : MonoBehaviour
{

    public void Salir()
    {
        // Regresa al Sistema Operativo
        Application.Quit();
    }

    public void IniciarJuego()
    {
        // Cambiar escena
        //print(message:"Click al boton");

        // Cambiar escena
        SceneManager.LoadScene("TheVirus");
    }

    public void Ayuda()
    {
        // Cambiar escena
        //print(message:"Click al boton");

        // Cambiar escena
        SceneManager.LoadScene("EscenaAyuda");
    }

    public void Creditos()
    {
        // Cambiar escena
        //print(message:"Click al boton");

        // Cambiar escena
        SceneManager.LoadScene("EscenaCreditos");
    }
}
