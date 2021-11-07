using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScorePanel_UI : UI_Driver
{
    [SerializeField] TextMeshProUGUI scoreTMP = null;
    [SerializeField] Image scorePanel = null;
    [SerializeField] Image trophyImage = null;

    public override void ShowHideAllUIElements(bool shouldBeShown)
    {
        scoreTMP.enabled = shouldBeShown;
        scorePanel.enabled = shouldBeShown;
        trophyImage.enabled = shouldBeShown;
    }

    public void UpdateScore(int currentScore)
    {
        scoreTMP.text = currentScore.ToString();
    }
    
}
