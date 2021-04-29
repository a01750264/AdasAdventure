using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Genera un disparo para que el enemigo pueda disparar cada 1.35 segundos
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class EnemigoDispara : MonoBehaviour
{
    public GameObject proyectil;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerarDisparo());
    }

    private IEnumerator GenerarDisparo()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.35f);

            GameObject nuevo = Instantiate(proyectil);
            nuevo.transform.position = gameObject.transform.position;
            nuevo.SetActive(true);
        }
    }
}
