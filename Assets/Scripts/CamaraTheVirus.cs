using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Permite que la cámara siga al personaje
 * Autores:
 * José Benjamín Ruiz García
 * Jeovani Hernández Bastida
 * Eduardo Acosta Hernández
 * Eric Alexis Castañeda
 */
public class CamaraTheVirus : MonoBehaviour
{
    public GameObject personaje;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(personaje.transform.position.x, min: 0, max: 26);
        float y = Mathf.Clamp(personaje.transform.position.y, min: 0, max: 2);
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
