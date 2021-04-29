using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

/*
 * Script que permite modificar las preguntas y sus componentes
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      Jose Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    // Inicializar variables
    [SerializeField] private Color m_correctColor = Color.black;
    [SerializeField] private Color m_incorrectColor = Color.black;
    [SerializeField] private float m_waitTime = 0.0f;

    public static float tiempoInicial;
    public static float tiempoTotal;
    public int nivel;
    public int competencia;
    public int tiempo;
    private QuizDB m_quizDB = null;
    private QuizUI m_quizUI = null;

    // De aquí traemos las preguntas que se tienen almacenadas
    private void Start()
    {
        tiempoInicial = Time.time;
        m_quizDB = GameObject.FindObjectOfType<QuizDB>();
        m_quizUI = GameObject.FindObjectOfType<QuizUI>();

        NextQuestion();
    }

    // Siguiente pregunta
    private void NextQuestion()
    {
        m_quizUI.Construtc(m_quizDB.GetRandom(), GiveAnswer);
    }

    // Nos indica que boton tiene la respuesta correcta
    private void GiveAnswer(OptionButton optionButton)
    {
        StartCoroutine(GiveAnswerRoutine(optionButton));
    }

    // Aqui comparamos si el jugador contesta bien o mal
    private IEnumerator GiveAnswerRoutine(OptionButton optionButton)
    {
        yield return new WaitForSeconds(m_waitTime);

        // Si contesta bien
        if (optionButton.Option.correct)
        {
            if (nivel == 5)
            {
                SubirPartida();  // Se crea una nueva partida
                Siguiente();     // Se pasa al siguiente nivel
            } else
            {
                SubirPartida();  // Se crea una nueva partida
                Fin();           // Se pasa a los creditos
            }
        }
        else  // Si contesta mal
        {
            if (nivel == 5)
            {
                SubirPartida();  // Se crea una nueva partida
                GameOver2();     // Se regresa al nivel anterior
            } else
            {
                SubirPartida();  // Se crea una nueva partida
                GameOver();      // Se regresa al nivel anterior
            }
            
        }
    }


    // Los siguientes metodos sirven para cambiar entre escenas
    private void GameOver()
    {
        SceneManager.LoadScene("ElEncuentroFinal");
    }

    private void GameOver2()
    {
        SceneManager.LoadScene("HaciaLaCima");
    }

    private void Fin()
    {
        SceneManager.LoadScene("EscenaCreditos");
    }

    private void Siguiente()
    {
        SceneManager.LoadScene("EscenaAlexis");
    }


    public void SubirPartida()
    {
        StartCoroutine(CrearPartida());  // Corutina para crear una partida en la base de datos
    }

    // Codigo para subir una partida a la base de datos por medio de un metodo POST
    public IEnumerator CrearPartida()
    {
        tiempoTotal = Time.time - tiempoInicial;  // Calculamos el tiempo en el que se manda a llamar este metodo para calcular el tiempo que paso el jugador en la escena

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
            forma.AddField("usuario", PlayerPrefs.GetString("nombreUsuario"));
            forma.AddField("progreso", nivel);
            forma.AddField("tiempo", tiempoTotal.ToString());
        }

        UnityWebRequest request = UnityWebRequest.Post("http://3.141.197.134:8080/partida/agregarPartida", forma);

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