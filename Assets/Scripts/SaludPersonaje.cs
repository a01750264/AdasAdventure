using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Mantiene información de la salud del personaje
 * Autor: Roberto Mtz. Román
 */
public class SaludPersonaje : MonoBehaviour
{
    public int vidas = 3;

    public int monedas = 0; // Recolectadas

    public static SaludPersonaje instance;

    private void Awake()
    {
        instance = this;        // ??????
    }

}
