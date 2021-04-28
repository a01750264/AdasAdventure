using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoverPersonaje : MonoBehaviour
{
    // VARIABLES
    public float maxVelocidadX = 10;    // Mov. horizontal  <-    ->
    public float maxVelocidadY = 7;    // Mov. Vertical ^

    private Rigidbody2D rigidbody;      // Para física
    
    public Proyectil proyectil;

    private int direccion = 1;


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
        //float movVertical = Input.GetAxis("Vertical");
        //if (movVertical > 0 && PruebaPiso.estaEnPiso)
        if (Input.GetButtonDown("Jump") && PruebaPiso.estaEnPiso)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, maxVelocidadY);
        }

        // Dispara!!!
        if (Input.GetButtonDown("Fire1"))
        {
            Proyectil nuevo = Instantiate(proyectil); // Copia el proyectil y regresa un nuevo objeto
            nuevo.transform.position = gameObject.transform.position;
            nuevo.CambiarDireccion(direccion);
            nuevo.gameObject.SetActive(true);
        }
    }
}


