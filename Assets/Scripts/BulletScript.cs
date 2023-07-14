using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BulletScript : MonoBehaviour
{
    public float lifeTime = 1.5f;
    public string[] tagsToCheck;
    private GameObject impactFx;

    private void Awake()
    {
        Destroy(this.gameObject, lifeTime);
    }

    void Start()
    {
        impactFx = transform.Find("ImpactFx").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Apply spell effects to whatever we hit
        //Apply hit particle effects
        //Apply sound effects


        if (tagsToCheck.Contains(other.tag))
        {
            Collider[] objectsInRange = Physics.OverlapSphere(transform.position, 1);

            foreach(Collider col in objectsInRange)
            {
                Rigidbody2D enemy = col.GetComponent<Rigidbody2D>();

                if (enemy != null)
                {
                    Destroy(gameObject);
                }
            }

            impactFx.SetActive(true);
            impactFx.transform.SetParent(null);
            //AudioManager.Instance.PlaySFX(5);
            Destroy(impactFx, 0.5f);
            Destroy(gameObject);
        }
    }
}
