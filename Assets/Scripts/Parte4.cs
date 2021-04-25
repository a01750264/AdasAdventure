using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parte4 : MonoBehaviour

{

    public int numero;

    public static Parte4 instance;
    
    private void Awake()
    {
        instance = this;        // ??????
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            numero = 2;
        }
    }

    

}