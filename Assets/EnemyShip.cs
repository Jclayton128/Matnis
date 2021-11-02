using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    Transform targetDiamond;
    Vector3 homePosition;
    EnemyFactory ef;

    //param


    //state
    float _moveSpeed;
    bool _hasDiamond = false;

    // Update is called once per frame
    void Update()
    {
        if (!_hasDiamond && (transform.position - targetDiamond.position).magnitude <= Mathf.Epsilon)
        {
            PickUpDiamond();
        }
        if (_hasDiamond && (transform.position - homePosition).magnitude <= Mathf.Epsilon)
        {
            ReturnToBase();
        }
    }

    private void PickUpDiamond()
    {
        _hasDiamond = true;
        GetComponent<SpriteRenderer>().flipY = true;
        targetDiamond.transform.parent = transform;
    }

    private void FixedUpdate()
    {
        if (_hasDiamond)
        {
            transform.position = Vector3.MoveTowards(transform.position, homePosition, _moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetDiamond.position, _moveSpeed * Time.deltaTime);
        }
        
    }

    public void SetNavData(Transform target, Vector3 returnPosition, float moveSpeed, EnemyFactory enemyFactorRef)
    {
        targetDiamond = target;
        homePosition = returnPosition;
        _moveSpeed = moveSpeed;
        ef = enemyFactorRef;
    }

    public void DestroyEnemyShip()
    {
        ef.HandleEnemyShipDeath();
        targetDiamond.transform.parent = null;
        Destroy(gameObject);
    }

    public void ReturnToBase()
    {
        ef.HandleEnemyShipReturnWithDiamond();
        Destroy(gameObject);
    }
}
