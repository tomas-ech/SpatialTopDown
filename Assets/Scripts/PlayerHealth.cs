using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            GameManager.Instance.isDead = true;
            this.gameObject.SetActive(false);
        }
    }
}
