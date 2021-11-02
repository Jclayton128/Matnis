using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePanel_UI : UI_Driver
{
    [SerializeField] TextMeshProUGUI scoreTMP = null;

    public override void ShowHideAllUIElements(bool shouldBeShown)
    {
        scoreTMP.enabled = shouldBeShown;
    }

    public void UpdateScore(int currentScore)
    {
        scoreTMP.text = "S: " + currentScore.ToString();
    }
    
}
