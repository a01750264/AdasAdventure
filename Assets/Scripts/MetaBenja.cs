using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetaBenja : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("meta"))
        {
            SceneManager.LoadScene("EscenaInstruccionesBenja");
        }
    }
}
