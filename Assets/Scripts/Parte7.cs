using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parte7 : MonoBehaviour

{

    public int numero;

    public static Parte7 instance;
    
    private void Awake()
    {
        instance = this;        // ??????
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //numero = 4;
            if(Parte8.instance.objeto.activeSelf)
            {
                StartCoroutine("Espera");
            }
        }
    }
        IEnumerator Espera()
    {
        Parte8.instance.objeto.gameObject.SetActive(false);
        yield return new WaitForSeconds(17);
        numero = 0;
        Parte8.instance.objeto.gameObject.SetActive(true);
    
    }
    

}
