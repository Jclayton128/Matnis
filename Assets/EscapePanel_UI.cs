using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapePanel_UI : UI_Driver
{
    [SerializeField] Image escapeImage = null;
    GameController gc;

    private void Start()
    {
        gc = FindObjectOfType<GameController>();
    }


    public override void ShowHideAllUIElements(bool shouldBeShown)
    {
        escapeImage.enabled = shouldBeShown;
    }

    public void HandleEscapeButtonPress()
    {
        gc.EscapeToMainMenu();
    }
}
