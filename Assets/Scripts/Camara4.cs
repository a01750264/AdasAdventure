using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Permite que la camara siga al personaje
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      Jose Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class Camara4 : MonoBehaviour
{
    public GameObject personaje;  // Personaje al que va a seguir la camara

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(personaje.transform.position.x, -0.3f, 18);  // Establecemos los limites en el eje x
        float y = Mathf.Clamp(personaje.transform.position.y, 0, 0);       // Establecemos los limites en el eje y
        float z = transform.position.z;                                    // Ponemos la camara a la altura de la escena en el eje z
        transform.position = new Vector3(x, y, z);                         // Metemos esos datos a un vector que usara la camara para moverse
    }
}
