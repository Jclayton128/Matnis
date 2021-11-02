using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DiamondHolder : MonoBehaviour
{
    [SerializeField] GameObject[] startingDiamonds = null;

    List<Transform> _remainingDiamonds = new List<Transform>();

    public Action OnNoDiamondsRemaining;
    // Start is called before the first frame update
    void Start()
    {
        ResetDiamondCount();
    }

    public Transform GetClosestDiamondTransform()
    {
        return _remainingDiamonds[0];
    }

    public void DestroyClosestDiamondPostCapture()
    {
        _remainingDiamonds.RemoveAt(0);
        if (_remainingDiamonds.Count == 0)
        {
            OnNoDiamondsRemaining?.Invoke();
        }
    }
    
    public void ResetDiamondCount()
    {
        foreach (var diamond in startingDiamonds)
        {
            _remainingDiamonds.Add(diamond.transform);
        }
    }

}
