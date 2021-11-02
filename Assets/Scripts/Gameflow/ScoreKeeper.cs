using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    ScorePanel_UI spd;

    //state
    int _problemCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        spd = FindObjectOfType<ScorePanel_UI>();
        spd.UpdateScore(_problemCount);
    }


    public void IncrementProblemCount()
    {
        _problemCount++;
        spd.UpdateScore(_problemCount);
    }

    public void ResetProblemCount()
    {
        _problemCount = 0;
        spd.UpdateScore(_problemCount);
    }

    public int GetProblemCount()
    {
        return _problemCount;
    }
}
