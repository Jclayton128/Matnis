using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    //init
    UI_Controller uic;
    GameModeHolder gmh;
    public Action OnGameStart;
    ProblemFactory pf;

    //state
    public bool IsInGame { get; private set; } = false;

    private void Start()
    {
        uic = FindObjectOfType<UI_Controller>();
        gmh = GetComponent<GameModeHolder>();
        pf = FindObjectOfType<ProblemFactory>();

    }

    public void BeginGameplay()
    {
        uic.ShowHideGameplayPanels(true);
        uic.ShowHideMainMenuPanel(false);
        IsInGame = true;
        OnGameStart?.Invoke();
        pf.CreateNewProblem();
    }

    public void HandleCorrectAnswer()
    {
        Debug.Log("Correct!");
        //Do the fun effect
        //Go to the next problem.
        pf.CreateNewProblem();

    }

    public void HandleIncorrectAnswer()
    {
        Debug.Log("Wrong :(");
        //Do the bad effect or lose a life whatnot
        //Go to the next problem.
        pf.CreateNewProblem();
    }
}
