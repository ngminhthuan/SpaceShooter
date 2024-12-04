using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveCtlr : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float minMoveRange = 2f;
    public float moveRange = 2f;
    public float maxMoveRange = 4f;

    private Vector3 startPosition;
    private bool movingRight = true;

    [SerializeField] EnemyController enemyController; 

    void Start()
    {
        enemyController.transform.position = new Vector3(0,3.82f,0);
        SetRandomMoveRange();
    }


    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (movingRight)
        {
            enemyController.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (enemyController.transform.position.x > startPosition.x + moveRange)
            {
                movingRight = false;
                SetRandomMoveRange();
            }
        }
        else
        {
            enemyController.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            if (enemyController.transform.position.x < startPosition.x - moveRange)
            {
                movingRight = true;
                SetRandomMoveRange();
            }
        }
    }

    void SetRandomMoveRange()
    {
        moveRange = Random.Range(minMoveRange, maxMoveRange);
    }
}
