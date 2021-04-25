using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Parte8 : MonoBehaviour
{

    public GameObject objeto;
    //               public float tiempoDestuir = 5f;
    // Start is called before the first frame update
    void Start()
    {
        objeto.gameObject.SetActive(true);
    }


    // Update is called once per frame
    
    void Update()
    {
        if(Parte5.instance.numero == 3 && Parte7.instance.numero == 4 )
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
