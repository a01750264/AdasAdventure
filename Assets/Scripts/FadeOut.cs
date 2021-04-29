using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Reproduce el efecto de fade-out en toda la escena
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class FadeOut : MonoBehaviour
{
    public Image imagenFadeOut;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Esperar());
    }

    // Update is called once per frame
    private IEnumerator Esperar()
    {
        yield return new WaitForSeconds(8);
        imagenFadeOut.canvasRenderer.SetAlpha(0);
        imagenFadeOut.gameObject.SetActive(true); // Activamos la imagen para el efecto
        imagenFadeOut.CrossFadeAlpha(1, 0.35f, true);
        SceneManager.LoadScene("Introduccion2");
    }
}
