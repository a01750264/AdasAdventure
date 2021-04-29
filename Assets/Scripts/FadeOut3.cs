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

public class FadeOut3 : MonoBehaviour
{
    public Image imagenFadeOut;
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(Comenzar());
    }

    public IEnumerator Comenzar()
    {
        yield return new WaitForSeconds(2);
        imagenFadeOut.canvasRenderer.SetAlpha(0);
        imagenFadeOut.gameObject.SetActive(true);  // Activamos la imagen para el efecto
        imagenFadeOut.CrossFadeAlpha(1, 0.35f, true);
        SceneManager.LoadScene("PuzzleBenja");
    }
}
