using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour
{

    public float scale;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = transform.localScale + new Vector3(scale, 0, 0);
        transform.localScale = transform.localScale + new Vector3(0, scale, 0);
    }
}
