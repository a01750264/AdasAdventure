using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Parte2 : MonoBehaviour
{

    public GameObject objeto;
    //       public float tiempoDestuir = 5f;
    // Start is called before the first frame update
    void Start()
    {
        objeto.gameObject.SetActive(true);
    }


    // Update is called once per frame
    
    void Update()
    {
        if(Parte1.instance.numero == 1)
        {
            //tiempoDestuir -= Time.deltaTime;
            objeto.gameObject.SetActive(false);
            /*if(tiempoDestuir <= -5)
            {
                objeto.gameObject.SetActive(true);
            }*/
            
        }
    }
}
