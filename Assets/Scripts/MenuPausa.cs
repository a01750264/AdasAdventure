using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Controla el menu de pausa en el juego
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
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
