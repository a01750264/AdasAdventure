using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Permite agregar las preguntas que se van a responder en un quiz
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class QuizDB : MonoBehaviour
{
    [SerializeField] private List<Question> m_questionList = null;

    private List<Question> m_backup = null;

    private void Awake()
    {
        m_backup = m_questionList; 
    }

    public Question GetRandom(bool remove = true)
    {
        if (m_questionList.Count == 0)
            RestoreBackup();

        int index = Random.Range(0, m_questionList.Count);

        if (!remove)
            return m_questionList[index];

        Question q = m_questionList[index];
        m_questionList.RemoveAt(index);

        return q;
    }

    private void RestoreBackup()
    {
        m_questionList = m_backup;
    }

}