using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Parte2 : MonoBehaviour
{

    public GameObject objeto;
    public static Parte2 instance;
    private void Awake()
    {
        instance = this;        // ??????
    }

    void Start()
    {
        objeto.gameObject.SetActive(true);
    }


    // Update is called once per frame
    

}
