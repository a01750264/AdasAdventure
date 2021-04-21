using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Reproduce el efecto de fade-in en toda la escena
 * Autor: Benjamín Ruiz
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
