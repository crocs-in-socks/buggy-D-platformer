using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDamage : MonoBehaviour
{
    public Transform camera;
    public GameObject poof;
    public FinishScript fs;
    void Start()
    {
        
    }
   void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            camera.parent = null;
            FindObjectOfType<AudioManager>().Play("Player_death");
            Instantiate(poof,gameObject.transform.position,Quaternion.identity);
            fs.RestartGame();
            Destroy(gameObject);

        }
    }
    

}
