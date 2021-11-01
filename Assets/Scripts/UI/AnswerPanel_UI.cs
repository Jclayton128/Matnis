﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerPanel_UI : UI_Driver
{
    [SerializeField] Image backgroundImage = null;
    [SerializeField] GameObject[] _answerButtons = null;
    [SerializeField] TextMeshProUGUI[] answerTMPs = null;
    GameController gc;

    //state
    int _indexOfCorrectAnswer;

    private void Start()
    {
        gc = FindObjectOfType<GameController>();
    }
    public override void ShowHideAllUIElements(bool shouldBeShown)
    {
        backgroundImage.enabled = false;
        foreach (var button in _answerButtons)
        {
            button.SetActive(shouldBeShown);
        }
    }

    public void UpdateAnswerButtonOptions(int[] answers, int indexOfCorrectAnswer)
    {
        if (answers.Length != answerTMPs.Length)
        {
            Debug.Log("incorrect number of incoming answers!");
            return;
        }

        _indexOfCorrectAnswer = indexOfCorrectAnswer;
        for (int i = 0; i < answers.Length; i++)
        {
            answerTMPs[i].text = answers[i].ToString();
        }

    }

    public void HandleAnswerButtonPress(int buttonIndex)
    {
        if (buttonIndex == _indexOfCorrectAnswer)
        {
            gc.HandleCorrectAnswer();

        }
        else
        {
            gc.HandleIncorrectAnswer();
        }
    }


}