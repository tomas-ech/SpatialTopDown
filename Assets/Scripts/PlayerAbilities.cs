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

    void Start()
    {
        
    }

    void Update()
    {
         if (Input.GetButtonDown("Fire1"))
        {
            GameObject attack = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Rigidbody2D rbAttack = attack.GetComponent<Rigidbody2D>();

            rbAttack.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        }   

    }

}
