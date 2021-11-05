using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DiamondHolder : MonoBehaviour
{
    [SerializeField] GameObject[] startingDiamonds = null;

    [SerializeField] List<Transform> _remainingDiamonds = new List<Transform>();

    public Action OnNoDiamondsRemaining;

    List<Vector3> _startingPositions = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        GenerateStartingPositions();
        ResetDiamondCount();
    }

    private void GenerateStartingPositions()
    {
        foreach (var diamond in startingDiamonds)
        {
            _startingPositions.Add(diamond.transform.position);
        }
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
        _remainingDiamonds.Clear();
        foreach (var diamond in startingDiamonds)
        {
            _remainingDiamonds.Add(diamond.transform);
        }
        for (int i = 0; i < _remainingDiamonds.Count; i++)
        {
            _remainingDiamonds[i].transform.position = _startingPositions[i];
        }
    }

    public bool CheckIfDiamondsAreLeft()
    {
        if (_remainingDiamonds.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
