using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Permite que la camara siga al personaje
 * Autores:
 * Jose Benjamin Ruiz Garcia
 * Jeovani Hernandez Bastida
 * Eduardo Acosta Hernandez
 * Eric Alexis Castaneda
 */
public class CamaraLalo : MonoBehaviour
{
    public GameObject personaje;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(personaje.transform.position.x, min: 0, max: 4);
        float y = Mathf.Clamp(personaje.transform.position.y, min: 0, max: 80);
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}