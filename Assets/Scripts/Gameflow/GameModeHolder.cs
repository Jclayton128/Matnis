using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeHolder : MonoBehaviour
{
    //inits
    GameModePanel_UI gmd;
    AudioController ac;

    //param
    [SerializeField] GameMode[] _possibleGameModes = null;

    //state
    int _index = 0;
    [SerializeField] GameMode _currentGameMode;


    // Start is called before the first frame update
    void Start()
    {
        ac = FindObjectOfType<AudioController>();
        gmd = FindObjectOfType<GameModePanel_UI>();
        _currentGameMode = _possibleGameModes[_index];
        gmd.UpdateGameModeUI(_currentGameMode);

    }

    public void ToggleLeft()
    {
        _index--;
        if (_index < 0)
        {
            _index = _possibleGameModes.Length - 1;
        }
        _currentGameMode = _possibleGameModes[_index];
        gmd.UpdateGameModeUI(_currentGameMode);
        ac.PlayToggleGameMode();
    }

    public void ToggleRight()
    {
        _index++;
        if (_index > _possibleGameModes.Length - 1)
        {
            _index = 0;
        }
        _currentGameMode = _possibleGameModes[_index];
        gmd.UpdateGameModeUI(_currentGameMode);
        ac.PlayToggleGameMode();
    }

    public GameMode GetCurrentGameMode()
    {
        return _currentGameMode;
    }

}
