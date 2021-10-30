using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandBool : object
{
    public static bool GetRandomBool()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            return false;
        }
        else 
        { 
            return true; 
        }
    }
}
