using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Script que permite agregar los botones y el texto de estos para las preguntas de los quizzes
 * Autores:
 *      Jeovani Hernandez Bastida - a01749164
 *      José Benjamin Ruiz Garcia - a01750246
 *      Alexis Castaneda Bravo - a01750119
 *      Eduardo Acosta Hernandez - a01375206
 */

public class QuizUI : MonoBehaviour
{
    [SerializeField] private Text m_question = null;
    [SerializeField] private List<OptionButton> m_buttonList = null;

    public void Construtc(Question q , Action<OptionButton> callback)
    {
        m_question.text = q.text;

        for (int n = 0 ; n < m_buttonList.Count ; n++)
        {
            m_buttonList[n].Construtc(q.options[n] , callback);
        }
    }
   
}
