using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*
 * Reproduce el efecto de fade-in en toda la escena
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class FadeIn : MonoBehaviour
{
    // La ImagenFondo
    public Image imagenFondo;
    // Start is called before the first frame update
    void Start()
    {
        imagenFondo.CrossFadeAlpha(0, 0.35f, true);
    }
}
