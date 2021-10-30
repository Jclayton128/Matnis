using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "My Assets/GameMode")]

public class GameMode : ScriptableObject
{
    public Sprite ModeSprite = null;
    public string ModeName = "";
    public enum Mode { ZeroPlusSmallMix, SmallMixPlusSmallMix, SmallDoubles, SmallDoublesPlusOne};
    public Mode SelectedMode;
}
