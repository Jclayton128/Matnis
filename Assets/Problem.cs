using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Problem
{
    public int TopNumber;
    public int BottomNumber;
    public int Answer;

    Problem(int top, int bottom, int answer)
    {
        TopNumber = top;
        BottomNumber = bottom;
        Answer = answer;
    }
}
