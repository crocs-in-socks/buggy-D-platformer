using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFx : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable()
    {
        Destroy(gameObject,0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
