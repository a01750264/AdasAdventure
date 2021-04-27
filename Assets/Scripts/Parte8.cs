using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Parte8 : MonoBehaviour
{

    public GameObject objeto;
    public static Parte8 instance;
    private void Awake()
    {
        instance = this;        // ??????
    }

    void Start()
    {
        objeto.gameObject.SetActive(true);
    }


}
