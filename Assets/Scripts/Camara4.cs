using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Permite que la cámara siga al personaje
 * Autor: 
 */
public class Camara4 : MonoBehaviour
{
    public GameObject personaje;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(personaje.transform.position.x, -0.3, 18.3f);
        float y = Mathf.Clamp(personaje.transform.position.y, 0, 6.0f);
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
