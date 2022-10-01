using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTrigger : MonoBehaviour
{
    public LavaScript lavascript;
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        lavascript.lavarise();
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
