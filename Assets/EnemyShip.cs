using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    Transform targetDiamond;
    Vector3 homePosition;
    EnemyFactory ef;
    AudioController ac;

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
        ac.PlayCrystalPickUp();
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

    public void InitializeShip(Transform target, Vector3 returnPosition, float moveSpeed, EnemyFactory enemyFactorRef, AudioController ac)
    {
        targetDiamond = target;
        homePosition = returnPosition;
        _moveSpeed = moveSpeed;
        ef = enemyFactorRef;
        this.ac = ac;
    }

    public void DestroyEnemyShip()
    {
        ef.HandleEnemyShipDeath();
        targetDiamond.transform.parent = null ;
        Destroy(gameObject);
    }

    public void ReturnToBase()
    {
        ef.HandleEnemyShipReturnWithDiamond();
        targetDiamond.transform.parent = null;
        Destroy(gameObject);
    }
}
