using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public GameObject rod;
    public DestroyTraprod dtrscript;
    public DestorySpike dsscript;
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(rod,new Vector2(139.28f,21.879f),Quaternion.identity);
        dtrscript.destroytrap();
        dsscript.spikedestroy();
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
