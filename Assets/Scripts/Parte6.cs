using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Instanciar el objeto para prenderlo y apagarlo desde Parte1
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class Parte6 : MonoBehaviour
{

    public GameObject objeto;
    public static Parte6 instance;
    private void Awake()
    {
        instance = this;        // ??????
    }
    
    void Start()
    {
        objeto.gameObject.SetActive(true);
       // print(objeto.gameObject.activeSelf);
    }


}

