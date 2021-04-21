using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
