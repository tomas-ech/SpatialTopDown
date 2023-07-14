using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Enemy
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float bulletSpeed;
    private Rigidbody2D enemyRb;
    private Transform path;
    private bool isWalking = true;

    private float shootTimer = 1.5f;
    private float timer = 1;

    void Start()
    {
        path = GameManager.Instance.enemyPaths[Random.Range(0, GameManager.Instance.enemyPaths.Length)].transform;
        enemyRb = GetComponent<Rigidbody2D>();

        hitPoints = 1;
    }

    void Update()
    {
        if (GameManager.Instance.isDead) {return;}

        if (!target) {GetTarget();}

        if (isWalking)
        {
            WalkToPoint();

            if (Vector2.Distance(transform.position, path.position) < 0.5f)
            {
                enemyRb.velocity = Vector2.zero;
                isWalking = false;
            }
        }

        else
        {
            RotateToTarget(target);
            Shoot();
        }


    }

    private void Shoot()
    {
        timer += Time.deltaTime;

        if (timer > shootTimer)
        {
            timer = 0;
            GameObject attack = Instantiate(bulletPrefab, firePoint.position, transform.rotation);

            Rigidbody2D rbAttack = attack.GetComponent<Rigidbody2D>();

            rbAttack.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        }

    }

    private void WalkToPoint()
    {
        RotateToTarget(path);
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
