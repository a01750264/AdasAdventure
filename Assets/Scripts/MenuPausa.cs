using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controlador del menu pausa (muestra/ouclta)
 * Autor: Roberto Mtz. Román
 */
public class MenuPausa : MonoBehaviour
{
    private bool estaPausado;       // true->Estoy en pausa, 
    public GameObject pantallaPausa;   // PANEL

    // El usuario Solicita pausar/quitar la pausa
    public void Pausar()
    {
        estaPausado = !estaPausado;    
        // Prende/apaga la pantalla
        pantallaPausa.SetActive(estaPausado);
        // Escala de tiempo -if terciario-
        Time.timeScale = estaPausado ? 0 : 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();
        }
    }
}
