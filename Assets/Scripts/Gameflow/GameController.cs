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
    DiamondHolder dh;
    EnemyFactory ef;
    public Action OnGameStart;


    //state
    public bool IsInGame { get; private set; } = false;

    private void Start()
    {
        uic = FindObjectOfType<UI_Controller>();
        gmh = GetComponent<GameModeHolder>();
        pf = FindObjectOfType<ProblemFactory>();
        sk = FindObjectOfType<ScoreKeeper>();
        dh = FindObjectOfType<DiamondHolder>();
        ef = FindObjectOfType<EnemyFactory>();



    }

    public void BeginGameplay()
    {
        uic.ShowHideGameplayPanels(true);
        uic.ShowHideMainMenuPanel(false);
        IsInGame = true;
        OnGameStart?.Invoke();
        pf.CreateNewProblem();
        ef.CreateNewEnemyShip();
    }

    public void EscapeToMainMenu()
    {
        IsInGame = false;
        uic.ShowHideGameplayPanels(false);
        uic.ShowHideMainMenuPanel(true);
        sk.ResetProblemCount();
        dh.ResetDiamondCount();
    }

    public void HandleCorrectAnswer()
    {
        Debug.Log("Correct!");
        // Autokill for now, later have a cooler visual effect. Missile shooting?
        ef.AutoKillCurrentEnemy();
    }

    public void HandleEnemyShipDestroyed(bool wasDiamondStolen)
    {
        if (!wasDiamondStolen)
        {
            sk.IncrementProblemCount();
        }
        pf.CreateNewProblem();
        ef.CreateNewEnemyShip();
    }

    public void HandleIncorrectAnswer()
    {
        Debug.Log("Wrong :(");
        //Do the bad effect or lose a life whatnot
        //Go to the next problem.


        //pf.CreateNewProblem();
        //ef.CreateNewEnemyShip();
    }
}
