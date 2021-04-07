using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Eric Alexis Casta eda Bravo
public class PruebaPiso : MonoBehaviour
{

    public static bool estaEnPiso = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Moneda")
        {
            estaEnPiso = true;
            //print("esta en piso");
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        estaEnPiso = false;
        //print("no esta en piso");
    }


}
