using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script que cambia entre frames para animar al personaje
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      Jos� Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class CambiarAnimacion : MonoBehaviour
{
    private Rigidbody2D rb2D;
    // Animator
    private Animator anim;      // Animator, actualizar el par�metro velocidad
    // SpriteRenderer, es para cambiar la orientaci�n. FlipX, FlipY
    private SpriteRenderer sprRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // velocidad
        float velocidad = Mathf.Abs(rb2D.velocity.x);
        anim.SetFloat("velocidad", velocidad);

        // Orientaci�n
        if (rb2D.velocity.x > 0)
        {
            sprRenderer.flipX = false;
        }
        else if (rb2D.velocity.x < 0)
        {
            sprRenderer.flipX = true;
        }

        // saltando
        anim.SetBool("saltando", !PruebaPiso.estaEnPiso);
    }
}





