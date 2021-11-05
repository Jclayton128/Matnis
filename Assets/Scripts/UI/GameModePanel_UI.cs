using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameModePanel_UI : UI_Driver
{
    
    [SerializeField] TextMeshProUGUI modeTMP = null;
    [SerializeField] Image modeFrameImage = null;
    [SerializeField] Image modeImage = null;


    public override void ShowHideAllUIElements(bool shouldBeShown)
    {
        modeTMP.enabled = shouldBeShown;
        modeImage.enabled = shouldBeShown;
        modeFrameImage.enabled = shouldBeShown;
    }

    public void UpdateGameModeUI(GameMode mode)
    {
        modeTMP.text = mode.ModeName;
        modeImage.sprite = mode.ModeSprite;

    }
}
