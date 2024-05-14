using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{

    [SerializeField] string videoFileName;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayVid());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayVid()
    {
        yield return new WaitForSeconds(2.5f);

        PlayVideo();

    }


    public void PlayVideo()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(videoPath);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
        }
    }
}
