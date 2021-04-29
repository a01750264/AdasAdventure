using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * Boton de reinicio para escena Alexis2 (laberinto)
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class Reinicio : MonoBehaviour
{
    // Start is called before the first frame update
    public void reiniciar()
    {
        SceneManager.LoadScene("Alexis2");
    }
}
