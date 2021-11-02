using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] GameObject enemyShipPrefab = null;
    DiamondHolder dh;
    GameController gc;
    ScoreKeeper sk;

    //param
    float baseMoveSpeed = 0.5f;
    float speedPerWin = 0.2f;
    Vector2 shipStartPoint = new Vector2(0, 4f);

    //state
    EnemyShip _currentEnemyShip;
    float _currentMoveSpeed = 0;

    void Start()
    {
        dh = FindObjectOfType<DiamondHolder>();
        gc = FindObjectOfType<GameController>();
        sk = FindObjectOfType<ScoreKeeper>();
    }
    public void CreateNewEnemyShip()
    {
        if (_currentEnemyShip != null)
        {
            Debug.Log("There already is a ship alive.");
            return;
        }
        _currentMoveSpeed = baseMoveSpeed + sk.GetProblemCount() * speedPerWin;
        _currentEnemyShip = Instantiate(enemyShipPrefab, shipStartPoint, Quaternion.identity).GetComponent<EnemyShip>();
        _currentEnemyShip.SetNavData(dh.GetClosestDiamondTransform(), shipStartPoint, _currentMoveSpeed, this);
    }

    public void AutoKillCurrentEnemy()
    {
        _currentEnemyShip.DestroyEnemyShip();
    }

    public void HandleEnemyShipDeath()
    {
        gc.HandleEnemyShipDestroyed(false);
    }

    public void HandleEnemyShipReturnWithDiamond()
    {
        dh.DestroyClosestDiamondPostCapture();
        gc.HandleEnemyShipDestroyed(true);
    }
}
