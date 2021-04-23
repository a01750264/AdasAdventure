using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut2 : MonoBehaviour
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
        imagenFadeOut.gameObject.SetActive(true);
        imagenFadeOut.CrossFadeAlpha(1, 0.35f, true);
        SceneManager.LoadScene("TheVirus");
    }
}
