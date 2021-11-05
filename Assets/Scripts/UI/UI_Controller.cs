using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] UI_Driver[] _gamePanels = null;
    [SerializeField] UI_Driver _mainMenuPanel = null;
    [SerializeField] UI_Driver scorePanel = null;
    [SerializeField] UI_Driver escapePanel = null;

    void Start()
    {
        ShowHideScoresPanel(false);
        ShowHideGameplayPanels(false);
        ShowHideEscapePanel(false);
        ShowHideMainMenuPanel(true);

    }

    public void ShowHideEscapePanel(bool shouldBeShown)
    {
        escapePanel.ShowHideAllUIElements(shouldBeShown);
    }

    public void ShowHideScoresPanel(bool shouldBeShown)
    {
        scorePanel.ShowHideAllUIElements(shouldBeShown);
    }

    public void ShowHideGameplayPanels(bool shouldBeShown)
    {
        foreach (var panel in _gamePanels)
        {
            panel.ShowHideAllUIElements(shouldBeShown);
        }
    }

    public void ShowHideMainMenuPanel(bool shouldBeShown)
    {
        _mainMenuPanel.ShowHideAllUIElements(shouldBeShown);
    }

}
