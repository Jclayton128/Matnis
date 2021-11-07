using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] UI_Driver[] _gamePanels = null;
    [SerializeField] UI_Driver _mainMenuPanel = null;
    [SerializeField] UI_Driver scorePanel = null;

    void Start()
    {
        ShowHideScoresPanel(false);
        ShowHideGameplayPanels(false);
        ShowHideMainMenuPanel(true);

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
