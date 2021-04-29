using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Controla los botones para la EscenaMenu
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
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
        SceneManager.LoadScene("Introduccion1");
    }

    public void Ayuda()
    {
        // Cambiar escena
        SceneManager.LoadScene("EscenaAyuda");
    }

    public void Creditos()
    {
        // Cambiar escena
        SceneManager.LoadScene("EscenaCreditos");
    }

    public void Controles()
    {
        // Cambiar escena
        SceneManager.LoadScene("EscenaControles");
    }
}
