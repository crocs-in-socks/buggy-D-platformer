using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer sprite1;
    public SpriteRenderer sprite2;
    public SpriteRenderer sprite3;
    public SpriteRenderer sprite4;
    public SpriteRenderer sprite5;
    public SpriteRenderer sprite6;
    public GameObject hitfx;
    public GameObject hitfxPosition;
    public GameObject deathfx;
    void Start()
    {
        
    }

    public float health=2f;

    public void takedamage()
    {
        Instantiate(hitfx,hitfxPosition.transform.position,Quaternion.identity);
        StartCoroutine("FlashRed");
        health-=1f;
    }
    public IEnumerator FlashRed()
    {
        sprite1.color = Color.red;
        sprite2.color = Color.red;
        sprite3.color = Color.red;
        sprite4.color = Color.red;
        sprite5.color = Color.red;
        sprite6.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite1.color = Color.white;
        sprite2.color = Color.white;
        sprite3.color = Color.white;
        sprite4.color = Color.white;
        sprite5.color = Color.white;
        sprite6.color = Color.white;
    }
    void Update()
    {
        if (health<=0)
        {
            Instantiate(deathfx,hitfxPosition.transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
