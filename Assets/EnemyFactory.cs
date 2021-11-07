using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] GameObject enemyShipPrefab = null;
    [SerializeField] GameObject shipDebrisPrefab = null;
    DiamondHolder dh;
    GameController gc;
    ScoreKeeper sk;
    GameModeHolder gmh;

    //param
    float baseMoveSpeed = 0.5f;
    float speedPerWin = 0.1f;
    Vector2 shipStartPoint = new Vector2(0, 3f);

    //state
    EnemyShip _currentEnemyShip;
    float _currentMoveSpeed = 0;

    void Start()
    {
        dh = FindObjectOfType<DiamondHolder>();
        gc = FindObjectOfType<GameController>();
        sk = FindObjectOfType<ScoreKeeper>();
        gmh = FindObjectOfType<GameModeHolder>();
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
        _currentEnemyShip.GetComponent<SpriteRenderer>().sprite = gmh.GetCurrentGameMode().ModeSprite;
    }

    public void AutoKillCurrentEnemy()
    {
        _currentEnemyShip.DestroyEnemyShip();
    }

    public void HandleEnemyShipDeath()
    {
        Instantiate(shipDebrisPrefab, _currentEnemyShip.transform.position, Quaternion.identity);
        _currentEnemyShip = null;
        gc.HandleEnemyShipDestroyed(false);
        
    }

    public void HandleEnemyShipReturnWithDiamond()
    {
        dh.DestroyClosestDiamondPostCapture();
        _currentEnemyShip = null;
        gc.HandleEnemyShipDestroyed(true);

    }

    public void ResetOnNewGame()
    {
        //foreach (var go in GameObject.FindGameObjectsWithTag("EnemyShip"))
        //{
        //    Destroy(go);
        //}
        Destroy(_currentEnemyShip.gameObject);
        _currentEnemyShip = null;
    }
}
