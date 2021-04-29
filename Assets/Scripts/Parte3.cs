using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Instanciar el objeto para prenderlo y apagarlo desde Parte4
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class Parte3 : MonoBehaviour
{

    public GameObject objeto;
    //public float tiempoDestuir = 5f;
    // Start is called before the first frame update
    void Start()
    {
        objeto.gameObject.SetActive(true);
    }


    // Update is called once per frame
    
    void Update()
    {
        if(Parte4.instance.numero == 2)
        {
            //tiempoDestuir -= Time.deltaTime;
            objeto.gameObject.SetActive(false);
            /*if(tiempoDestuir <= -5)
            {
                objeto.gameObject.SetActive(true);
            }*/
            
        }
    }
}
