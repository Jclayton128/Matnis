using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Problem
{
    public int TopNumber;
    public int BottomNumber;
    public int Answer;
    public char OpChar;

    Problem(int top, int bottom, int answer, char operatorAsChar)
    {
        TopNumber = top;
        BottomNumber = bottom;
        Answer = answer;
        OpChar = operatorAsChar;
    }
}
