using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public Transform camera;
    public GameObject poof;
    void Start()
    {
        
    }
   void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            camera.parent = null;
            Instantiate(poof,gameObject.transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
