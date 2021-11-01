using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuPanel_UI : UI_Driver
{
    [SerializeField] Image backgroundImage = null;
    [SerializeField] TextMeshProUGUI _blurbTMP = null;
    [SerializeField] GameObject[] _buttons = null;
    [SerializeField] UI_Driver _gameModePanel = null;

    public override void ShowHideAllUIElements(bool shouldBeShown)
    {
        backgroundImage.enabled = shouldBeShown;
        _blurbTMP.enabled = shouldBeShown;
        _gameModePanel.ShowHideAllUIElements(shouldBeShown);
        foreach (var button in _buttons)
        {
            button.SetActive(shouldBeShown);
        }
    }


}
