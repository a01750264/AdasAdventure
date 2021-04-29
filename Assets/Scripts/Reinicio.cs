using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reinicio : MonoBehaviour
{
    // Start is called before the first frame update
    public void reiniciar()
    {
        SceneManager.LoadScene("Alexis2");
    }
}
