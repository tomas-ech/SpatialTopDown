using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    [Header("Bullets Info")]
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 10f;
    private float timer;
    private float shootTimer = 0.3f;

    void Start()
    {
        
    }

    void Update()
    {
        if (!GameManager.Instance.canPlay) {return;}
        
        PlayerShoot1();
    }

    private void PlayerShoot1()
    {
        timer += Time.deltaTime;

        if (timer > shootTimer && Input.GetButtonDown("Fire1"))
        {
            timer = 0;

            AudioManager.Instance.PlaySFX(0);

            GameObject attack = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Rigidbody2D rbAttack = attack.GetComponent<Rigidbody2D>();

            rbAttack.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}
