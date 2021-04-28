using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut3 : MonoBehaviour
{
    public Image imagenFadeOut;
    // Start is called before the first frame update
    public void Comenzar()
    {
        imagenFadeOut.canvasRenderer.SetAlpha(0);
        imagenFadeOut.gameObject.SetActive(true);
        imagenFadeOut.CrossFadeAlpha(1, 0.35f, true);
        SceneManager.LoadScene("PuzzleBenja");
    }
}
