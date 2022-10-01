using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorySpike : MonoBehaviour
{
    public GameObject poof;
    void Start()
    {
        
    }
    public void spikedestroy()
    {
        Instantiate(poof,gameObject.transform.position,Quaternion.identity);
        Destroy(gameObject,10f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
