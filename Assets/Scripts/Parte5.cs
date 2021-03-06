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

public class Parte5 : MonoBehaviour

{

    public int numero;


    public static Parte5 instance;
    
    private void Awake()
    {
        instance = this;        // ??????
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //numero = 3;
            if(Parte6.instance.objeto.activeSelf)
            {
                StartCoroutine("Espera");
            }
            
        }
    }
    
    void Update()
    {
        
    }
        IEnumerator Espera()
    {
        Parte6.instance.objeto.gameObject.SetActive(false);
        yield return new WaitForSeconds(5);
        numero = 0;
        Parte6.instance.objeto.gameObject.SetActive(true);
    
    }

    

}