using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Permite que la c�mara siga al personaje
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
        float x = Mathf.Clamp(personaje.transform.position.x, -0.3f, 18);
        float y = Mathf.Clamp(personaje.transform.position.y, 0, 0);
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
