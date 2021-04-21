using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public Image imagenFondo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EfectoFadeOut());
    }

    private IEnumerator EfectoFadeOut()
    {
        yield return new WaitForSeconds(8);

        imagenFondo.canvasRenderer.SetAlpha(0);
        imagenFondo.gameObject.SetActive(true);
        imagenFondo.CrossFadeAlpha(1, 0.35f, true);

    }

}
