using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Controla los metodos para atender los componentes del menú
 * Autores: 
 *          Eduardo Acosta Hernández
 *          Eric Alexis Castañeda Bravo
 *          Jeovani Hernández Bastida
 *          Jose Benjamín Ruíz García          
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
