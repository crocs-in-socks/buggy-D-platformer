using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadein : MonoBehaviour
{
    public SpriteRenderer rend;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a=0f;
        rend.material.color = c;
    }
    IEnumerator FadeIN()
    {
        for (float f= 0.05f; f<=2; f+=0.05f)
        {
            Color c = rend.material.color;
            c.a=f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    void OnEnable()
    {
        StartCoroutine("FadeIN");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
