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
    AnswerPanel_UI apd;
    AudioController ac;
    public Action OnGameStart;

    //param
    float penaltyDecreaseRate = 1.3f;  //scale change per second

    //state
    public bool IsInGame { get; private set; } = false;
    private float penaltyFactor = 0;
    private int recentIncorrectAnswerIndex = -1;


    private void Start()
    {
        uic = FindObjectOfType<UI_Controller>();
        gmh = GetComponent<GameModeHolder>();
        pf = FindObjectOfType<ProblemFactory>();
        sk = FindObjectOfType<ScoreKeeper>();
        dh = FindObjectOfType<DiamondHolder>();
        dh.OnNoDiamondsRemaining += MoveToScoreScreenAfterGameEnd;
        ef = FindObjectOfType<EnemyFactory>();
        apd = FindObjectOfType<AnswerPanel_UI>();
        ac = FindObjectOfType<AudioController>();
    }

    public void BeginGameplay()
    {
        ac.PlayEnterGame();
        uic.ShowHideGameplayPanels(true);
        uic.ShowHideMainMenuPanel(false);
        uic.ShowHideScoresPanel(false);
        IsInGame = true;
        OnGameStart?.Invoke();
        pf.CreateNewProblem();
        ef.CreateNewEnemyShip();
    }

    public void EscapeToMainMenu()
    {
        ac.PlayEscapeToMainMenu();
        penaltyFactor = 0;
        IsInGame = false;
        uic.ShowHideGameplayPanels(false);
        uic.ShowHideMainMenuPanel(true);
        uic.ShowHideScoresPanel(false);
        sk.ResetProblemCount();
        dh.ResetDiamondCount();
        ef.ResetOnNewGame();
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
            ac.PlayEnemyShipDestroyed();
            sk.IncrementProblemCount();
            pf.CreateNewProblem();
            ef.CreateNewEnemyShip();
        }

        if (wasDiamondStolen)
        {
            ac.PlayCrystalDestroyed();
            if (dh.CheckIfDiamondsAreLeft())
            {
                pf.CreateNewProblem();
                ef.CreateNewEnemyShip();
            }
        }

    }

    public void HandleIncorrectAnswer(int indexOfWrongAnswer)
    {
        Debug.Log("Wrong :(");
        //Do the bad effect or lose a life whatnot
        //Go to the next problem.
        ac.PlayWrongAnswer();
        penaltyFactor = 1;
        recentIncorrectAnswerIndex = indexOfWrongAnswer;
        //pf.CreateNewProblem();
        //ef.CreateNewEnemyShip();
    }

    public bool CheckIfStillInPenalty()
    {
        if (penaltyFactor > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void MoveToScoreScreenAfterGameEnd()
    {
        IsInGame = false;
        uic.ShowHideScoresPanel(true);
        uic.ShowHideGameplayPanels(false);
        uic.ShowHideMainMenuPanel(false);
    }

    private void Update()
    {
        if (penaltyFactor > 0)
        {
            penaltyFactor -= Time.deltaTime * penaltyDecreaseRate;
            apd.UpdateWrongAnswerChoiceWithPenaltyFactor(recentIncorrectAnswerIndex, penaltyFactor);
        }
    }
}
