using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBenja : MonoBehaviour
{
    public Image imagen1;
    public Image imagen2;
    public Image imagen3;

    public static HUDBenja instance;

    public void Awake()
    {
        instance = this;
    }

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
