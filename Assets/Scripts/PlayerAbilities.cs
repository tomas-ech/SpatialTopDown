using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletSpeed = 10f;

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
