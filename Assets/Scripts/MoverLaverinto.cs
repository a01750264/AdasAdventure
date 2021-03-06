using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controla el movimiento del jugador en la escena Alexis2 (laberinto)
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class MoverLaverinto : MonoBehaviour
{
    // VARIABLES
    public float maxVelocidadX = 10;    // Mov. horizontal  <-    ->
    public float maxVelocidadY = 7;    // Mov. Vertical ^

    private Rigidbody2D rigidbody;      // Para física
    
    private int direccion = 1;
    // Update is called once per frame

    // METODOS

    // Start is called before the first frame update
    void Start()
    {
        // Inicializar variables
        rigidbody = GetComponent<Rigidbody2D>();    // Enlazar RB -> script
    }

    // Update is called once per frame (FRECUENTEMENTE, 60 veces/seg)
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");   // [-1, 1]
        if (movHorizontal < -0.001)
        {
            direccion = -1;
        } else if (movHorizontal > 0.001)
        {
            direccion = +1;
        }

        rigidbody.velocity = new Vector2(movHorizontal * maxVelocidadX, rigidbody.velocity.y);

        // Salto (Después lo vamos a resolver con JUMP)
        float movVertical = Input.GetAxis("Vertical");
        if (movVertical > 0)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x,movVertical * maxVelocidadY );
        }

        
    }
}
