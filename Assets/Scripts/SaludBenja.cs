using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script para definir las vidas que tiene el jugador en PuzzleBenja
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class SaludBenja : MonoBehaviour
{
    public int vidas = 3;

    public static SaludBenja instance;

    private void Awake()
    {
        instance = this;
    }
}
