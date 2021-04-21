using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private float velocidadX = 10;
    private Rigidbody2D rb;

    public int direccionDerecha = +1;

    private SpriteRenderer rendererProyectil; // Sabe si la cámara lo está viendo
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(direccionDerecha * velocidadX, 0);
        rendererProyectil = GetComponent<SpriteRenderer>();
        print("Start " + direccionDerecha);
    }

    public void CambiarDireccion(float velocidad)
    {
        direccionDerecha = velocidad < 0 ? -1 : +1;
        print("CambiarDir");
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.forward, 5);

        if (!rendererProyectil.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
