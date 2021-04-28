using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludBenja : MonoBehaviour
{
    public int vidas = 3;

    public static SaludBenja instance;

    private void Awake()
    {
        instance = this;
    }
}
