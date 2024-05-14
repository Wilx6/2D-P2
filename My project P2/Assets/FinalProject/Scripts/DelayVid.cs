using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DelayVid : MonoBehaviour
{

    private VideoPlayer myVid;


    // Start is called before the first frame update
    void Start()
    {
        myVid = GetComponent<VideoPlayer>();
        StartCoroutine(PlayVid());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator PlayVid()
    {
        yield return new WaitForSeconds(5f);

        myVid.enabled = true;
    }
}
