using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    //init
    UI_Controller uic;
    ProblemFactory pf;
    ScoreKeeper sk;
    GameModeHolder gmh;
    public Action OnGameStart;


    //state
    public bool IsInGame { get; private set; } = false;

    private void Start()
    {
        uic = FindObjectOfType<UI_Controller>();
        gmh = GetComponent<GameModeHolder>();
        pf = FindObjectOfType<ProblemFactory>();
        sk = FindObjectOfType<ScoreKeeper>();


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
        sk.IncrementProblemCount();
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
