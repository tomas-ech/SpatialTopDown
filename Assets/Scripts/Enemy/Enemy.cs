using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target {get; protected set;}
    public int hitPoints {get; protected set;}
    public float baseSpeed = 3f;
    public float rotationSpeed;
    public GameObject deadFx;

    private void Start()
    {
        
    }

    protected virtual void GetTarget()
    {
        if (GameManager.Instance.canPlay && !GameManager.Instance.isDead)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    protected virtual void RotateToTarget(Transform objetive)
    {
        Vector2 dir = objetive.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;

        Quaternion rotationQ = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotationQ, rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.isDead = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            hitPoints -= 1;

            if (hitPoints < 1)
            {
                GameManager.Instance.enemies += 1;

                deadFx.SetActive(true);
                deadFx.transform.SetParent(null);
                AudioManager.Instance.PlaySFX(1);
                Destroy(deadFx, 0.5f);
                Destroy(gameObject);
            }
                        
        }
    }
}
