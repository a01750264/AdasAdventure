using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Controlador del menu pausa (muestra/ouclta)
 * Autor: Roberto Mtz. Román
 */
public class MenuPausa : MonoBehaviour
{
    private bool estaPausado;       // true->Estoy en pausa, 
    public GameObject pantallaPausa;   // PANEL
    private bool estaEnControles;
    public GameObject pantallaControles;

    // El usuario Solicita pausar/quitar la pausa
    public void Pausar()
    {
        estaPausado = !estaPausado;    
        // Prende/apaga la pantalla
        pantallaPausa.SetActive(estaPausado);
        // Escala de tiempo -if terciario-
        Time.timeScale = estaPausado ? 0 : 1f;
    }

    public void Controles()
    {
        estaEnControles = !estaEnControles;
        pantallaControles.SetActive(estaEnControles);
    }

    public void MenuPrincial()
    {
        SceneManager.LoadScene("EscenaMenu");
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
