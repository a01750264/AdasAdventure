using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que define las vidas y las monedas del jugador durante el transcurso juego
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class SaludPersonaje : MonoBehaviour
{
    public int vidas = 3;

    public int vacunas = 0; // Recolectadas

    public static SaludPersonaje instance;

    private void Awake()
    {
        instance = this;        // ??????
    }

}
