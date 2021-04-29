using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Detecta las colisiones con las cajas en el laberinto
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class Parte4 : MonoBehaviour

{

    public int numero;

    public static Parte4 instance;
    
    private void Awake()
    {
        instance = this;        // ??????
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            numero = 2;
        }
    }

    

}