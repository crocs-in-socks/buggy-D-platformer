using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaScript : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 pos;
    Vector2 current;
    bool lesgo;
    public float speed;
    void Start()
    {
        current = new Vector2(36.5f,-10.7f);
        pos = new Vector2(95f,17.65f);
        lesgo=false;
    }
    public void lavarise()
    {
        lesgo=true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(lesgo==true)
        {
            float step = speed*Time.deltaTime;
            gameObject.transform.position = Vector2.MoveTowards(transform.position,pos,step);
        }
    }
}
