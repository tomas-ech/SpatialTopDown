using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{
    private Camera cam;

    
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        if (!GameManager.Instance.canPlay || GameManager.Instance.isDead) {return;}
        
        transform.position = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0f);
    }
}
