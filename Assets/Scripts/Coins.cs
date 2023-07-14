using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //AudioManager.instance.PlaySFX(0);
            GameManager.Instance.coins++;
            Destroy(gameObject);
        }

        /*if (other.GetComponent<Enemy>() != null)
        {
            Destroy(gameObject);
        }*/
    }
}
