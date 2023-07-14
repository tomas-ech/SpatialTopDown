using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : Enemy
{
    private Rigidbody2D enemyRb;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        hitPoints = 3;
    }

    private void Update()
    {
        if (GameManager.Instance.isDead) {return;}
        if (!target) {GetTarget();}
        else {RotateToTarget(target);}
    }

    void FixedUpdate()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        enemyRb.velocity = transform.up * GameManager.Instance.enemySpeed * baseSpeed;
    }

    protected override void GetTarget()
    {
        base.GetTarget();
    }

    protected override void RotateToTarget(Transform objetive)
    {
        base.RotateToTarget(objetive);
    }
}
