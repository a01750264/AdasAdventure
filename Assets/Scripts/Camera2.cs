using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Permite que la c�mara siga al personaje
 * Autores:
 * Jos� Benjam�n Ruiz Garc�a
 * Jeovani Hern�ndez Bastida
 * Eduardo Acosta Hern�ndez
 * Eric Alexis Casta�eda
 */
public class Camera2 : MonoBehaviour
{
    public GameObject personaje;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(personaje.transform.position.x, min: 0, max: 95);
        float y = Mathf.Clamp(personaje.transform.position.y, min: 0, max: 2);
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
