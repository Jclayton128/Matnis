using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/GameMode")]

public class GameMode : ScriptableObject
{
    public Sprite ModeSprite = null;
    public string ModeName = "";
    public enum Mode { Zeros, SmallMix, SmallDoubles, PlusOne, PlusTwo, PlusThree, PlusFour};
    public Mode SelectedMode;
}
