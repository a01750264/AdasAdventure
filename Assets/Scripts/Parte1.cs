using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Detecta las colisiones con las cajas en el laberinto
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      Jos? Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class Parte1 : MonoBehaviour
{

    public int numero;

    public static Parte1 instance;
    
    private void Awake()
    {
        instance = this;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //numero = 1;
            if(Parte2.instance.objeto.activeSelf)
            {
                StartCoroutine("Espera");
            }
        }
    }
        IEnumerator Espera()
    {
        Parte2.instance.objeto.gameObject.SetActive(false);
        yield return new WaitForSeconds(10);
        numero = 0;
        Parte2.instance.objeto.gameObject.SetActive(true);
    
    }

}
