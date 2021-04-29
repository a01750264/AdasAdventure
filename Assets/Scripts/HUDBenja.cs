using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Script que muestra el HUD en la pantalla PuzzleBenja
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class HUDBenja : MonoBehaviour
{
    public Image imagen1;
    public Image imagen2;
    public Image imagen3;

    public static HUDBenja instance;

    /*
     * Se ejecuta cuando el objeto se activa (antes de Start)
     */
    public void Awake()
    {
        instance = this;
    }

    // Vidas
    public void ActualizarVidas()
    {
        int vidas = SaludBenja.instance.vidas;
        if (vidas == 2)
        {
            imagen3.enabled = false;
        }
        else if (vidas == 1)
        {
            imagen2.enabled = false;
        }
        else if (vidas == 0)
        {
            imagen1.enabled = false;
        }
    }
}
