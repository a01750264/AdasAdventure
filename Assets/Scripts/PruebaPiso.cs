using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script para probar si el jugador esta en el aire o en una plataforma
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class PruebaPiso : MonoBehaviour
{

    public static bool estaEnPiso = false;

    // Esto es para evitar que se pueda saltar en las monedas
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Moneda")
        {
            estaEnPiso = true;
        }
    }

    // Si es plataforma el jugador puede saltar
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "plataforma")
        {
            estaEnPiso = false;
        }
    }
}
