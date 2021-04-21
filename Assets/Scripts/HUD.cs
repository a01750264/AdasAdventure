using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // Para Image

public class HUD : MonoBehaviour
{
    public Image imagen1;
    public Image imagen2;
    public Image imagen3;
    public static string fechaHoraInicioString;

    public Text textoMonedas;

    public Slider slider;

    public static HUD instance;

    public void CambiaSlider()
    {
        float valor = slider.value;
        Time.timeScale = valor;
    }

    private void Start()
    {
        fechaHoraInicioString = System.DateTime.Now.ToString();
        print(fechaHoraInicioString);
        print(PlayerPrefs.GetString("nombreUsuario"));
        //Leer el valor desde las preferencias
        int numeroMonedas = PlayerPrefs.GetInt("numeroMonedas", 0);
        textoMonedas.text = numeroMonedas.ToString();
        SaludPersonaje.instance.monedas = numeroMonedas;
    }

    /*
     * Se ejecuta cuando el objeto se activa (antes de Start)
     */
    private void Awake()
    {
        instance = this;
    }
    
    public void ActualizarMonedas()
    {
        textoMonedas.text = SaludPersonaje.instance.monedas.ToString();
    }

    public void ActualizarVidas()
    {
        int vidas = SaludPersonaje.instance.vidas;
        if (vidas == 2)
        {
            imagen3.enabled = false;
        } else if (vidas == 1)
        {
            imagen2.enabled = false;
        } else if (vidas == 0)
        {
            imagen1.enabled = false;
        }
    }
}




