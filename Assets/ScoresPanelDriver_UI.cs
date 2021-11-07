using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoresPanelDriver_UI : UI_Driver
{
    [SerializeField] Image panelImage = null;
    [SerializeField] Image gameModeImage = null;
    [SerializeField] Image trophyImage = null;
    [SerializeField] TextMeshProUGUI blurbTMP = null;
    [SerializeField] TextMeshProUGUI gameModeTMP = null;
    [SerializeField] TextMeshProUGUI scoreTMP = null;
    [SerializeField] GameObject acceptScoreButton = null;

    GameModeHolder gmh;
    EscapePanel_UI epd;
    DiamondHolder dh;
    ScoreKeeper sk;
    GameController gc;

    public override void ShowHideAllUIElements(bool shouldBeShown)
    {
        panelImage.enabled = shouldBeShown;
        gameModeImage.enabled = shouldBeShown;
        blurbTMP.enabled = shouldBeShown;
        gameModeTMP.enabled = shouldBeShown;
        trophyImage.enabled = shouldBeShown;
        scoreTMP.enabled = shouldBeShown;
        acceptScoreButton.SetActive(shouldBeShown);
    }

    // Start is called before the first frame update
    void Start()
    {
        gmh = FindObjectOfType<GameModeHolder>();
        dh = FindObjectOfType<DiamondHolder>();
        dh.OnNoDiamondsRemaining += UpdateScore;
        epd = FindObjectOfType<EscapePanel_UI>();
        sk = FindObjectOfType<ScoreKeeper>();
        gc = FindObjectOfType<GameController>();
    }

    public void UpdateScore()
    {
        gameModeImage.sprite = gmh.GetCurrentGameMode().ModeSprite;
        gameModeTMP.text = gmh.GetCurrentGameMode().ModeName;

        scoreTMP.text = sk.GetProblemCount().ToString();

        epd.ShowHideAllUIElements(true);
    }

    public void AcceptScore()
    {
        gc.EscapeToMainMenu();
    }
}
