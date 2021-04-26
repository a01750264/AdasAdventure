using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Parte6 : MonoBehaviour
{

    public GameObject objeto;
    public static Parte6 instance;
    private void Awake()
    {
        instance = this;        // ??????
    }
    
    void Start()
    {
        objeto.gameObject.SetActive(true);
    }


    // Update is called once per frame
    
    void Update()
    {
        if(Parte5.instance.numero == 3)
        {
            objeto.gameObject.SetActive(false);       
        }
        else
        {
            objeto.gameObject.SetActive(true);
        }
    }

}

