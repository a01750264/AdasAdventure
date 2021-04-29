using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Meta : MonoBehaviour
{
    public static float tiempoInicial;
    public static float tiempoTotal;
    public string escena;
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
        forma.AddField("puntuacion", SaludPersonaje.instance.vacunas.ToString());  // Puntuacion del jugador
        forma.AddField("usuario", PlayerPrefs.GetString("nombreUsuario"));       // Nombre de usuario
        forma.AddField("progreso", nivel);                                       // Nivel en el que se encuentra
        forma.AddField("tiempo", tiempoTotal.ToString());                        // Toma el tiempo actual y le resta el tiempoInicial para sacar el tiempo que tardó el usuario en llegar a la meta

        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8080/partida/agregarPartida", forma);  // Se manda la petición POST al servidor con los datos anteriores

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
