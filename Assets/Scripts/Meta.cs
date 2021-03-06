using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

/*
 * Deteccion de colision con objetos de tipo "meta"
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      Jos? Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class Meta : MonoBehaviour
{
    public static float tiempoInicial;
    public static float tiempoTotal;
    public string escena;
    public int competencia;
    public int tiempo;
    public int nivel;

    void Start()
    {
        tiempoInicial = Time.time;  // Empezamos a contar el tiempo cuando se entre a la escena
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("meta"))  // Cuando el jugador toque la meta
        {
            SubirPartidaPuntos();  // Manda a llamar una corutina que sube los datos necesarios para crear una partida en la base de datos
            SubirPartidaPuntos2();
            SceneManager.LoadScene(escena);  // Se cambia a la siguiente escena
        }
    }

    // Corutina para crear una partida en la base de datos
    public void SubirPartidaPuntos()
    {
        StartCoroutine(CrearPartidaPuntos());
    }

    // Se manda la peticion al servidor para subir los datos necesarios para crear la partida en la base de datos
    public IEnumerator CrearPartidaPuntos()
    {
        tiempoTotal = Time.time - tiempoInicial;

        WWWForm forma = new WWWForm();
        if (tiempoTotal <= tiempo)
        {
            forma.AddField("competencia", competencia);
            forma.AddField("usuario", PlayerPrefs.GetString("nombreUsuario"));
            forma.AddField("progreso", nivel);
            forma.AddField("tiempo", tiempoTotal.ToString());
            print(competencia);
            print("competencia adquirida");
            print(forma.data);
        }
        else
        {
            forma.AddField("puntuacion", SaludPersonaje.instance.vacunas.ToString());  // Puntuacion del jugador
            forma.AddField("usuario", PlayerPrefs.GetString("nombreUsuario"));       // Nombre de usuario
            forma.AddField("progreso", nivel);                                       // Nivel en el que se encuentra
            forma.AddField("tiempo", tiempoTotal.ToString());                        // Toma el tiempo actual y le resta el tiempoInicial para sacar el tiempo que tard? el usuario en llegar a la meta
        }

        UnityWebRequest request = UnityWebRequest.Post("http://3.141.197.134:8080/partida/agregarPartida", forma);  // Se manda la petici?n POST al servidor con los datos anteriores

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)  //200 OK
        {
            string textoPlano = request.downloadHandler.text;  //Datos descargados de la red
            print(textoPlano);
        }
        else
        {
            print("Error en la descarga: ");
        }
    }

    public void SubirPartidaPuntos2()
    {
        StartCoroutine(CrearPartidaPuntos2());
    }

    public IEnumerator CrearPartidaPuntos2()
    {
        tiempoTotal = Time.time - tiempoInicial;

        WWWForm forma = new WWWForm();
        if (tiempoTotal <= tiempo)
        {
            forma.AddField("competencia", 3);
            forma.AddField("usuario", PlayerPrefs.GetString("nombreUsuario"));
            forma.AddField("progreso", nivel);
            forma.AddField("tiempo", tiempoTotal.ToString());
            print(competencia);
            print("competencia adquirida");
            print(forma.data);
        }
        else
        {
            forma.AddField("puntuacion", SaludPersonaje.instance.vacunas.ToString());  // Puntuacion del jugador
            forma.AddField("usuario", PlayerPrefs.GetString("nombreUsuario"));       // Nombre de usuario
            forma.AddField("progreso", nivel);                                       // Nivel en el que se encuentra
            forma.AddField("tiempo", tiempoTotal.ToString());                        // Toma el tiempo actual y le resta el tiempoInicial para sacar el tiempo que tard? el usuario en llegar a la meta
        }

        UnityWebRequest request = UnityWebRequest.Post("http://3.141.197.134:8080/partida/agregarPartida", forma);  // Se manda la petici?n POST al servidor con los datos anteriores

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)  //200 OK
        {
            string textoPlano = request.downloadHandler.text;  //Datos descargados de la red
            print(textoPlano);
        }
        else
        {
            print("Error en la descarga: ");
        }
    }
}
