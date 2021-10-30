using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AnswerFactory : MonoBehaviour
{
    AnswerPanel_UI apd;

   

    public void UpdateAnswerSelection(Problem problem)
    {
        int[] answerOptions = CreateCloseIncorrectAnswers(problem.Answer);
        int indexOfCorrectAnswer;
        answerOptions = InsertCorrectOption(answerOptions, problem.Answer, out indexOfCorrectAnswer);
        if (!apd)
        {
            apd = FindObjectOfType<AnswerPanel_UI>();
        }
        apd.UpdateAnswerButtonOptions(answerOptions, indexOfCorrectAnswer);
    }

    private int[] CreateCloseIncorrectAnswers(int seedAnswer)
    {
        int[] answerOptions = new int[4];

        for (int i = 0; i < 2; i++)
        {
            answerOptions[i] = seedAnswer - 2 + i;
        }
        for (int i = 2; i < 4; i++)
        {
            answerOptions[i] = seedAnswer + i -1;
        }
        Debug.Log($"Given {seedAnswer}, came up with {answerOptions[0]},{answerOptions[1]}, {answerOptions[2]}," +
            $"{answerOptions[3]}");
        return answerOptions;
    }

    private int[] InsertCorrectOption(int[] answerArray, int correctAnswer, out int indexOfCorrectAnswer)
    {
        indexOfCorrectAnswer = UnityEngine.Random.Range(0, answerArray.Length);
        answerArray[indexOfCorrectAnswer] = correctAnswer;
        Debug.Log($"inserted correct answer of {correctAnswer} in spot {indexOfCorrectAnswer} to yield {answerArray[0]}," +
            $"{answerArray[1]}, {answerArray[2]}, {answerArray[3]}");
        return answerArray;
    }
}
