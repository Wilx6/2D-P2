using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class WallBounce : MonoBehaviour
{

    public float scale;

    [SerializeField] private AudioClip wallSoundClip;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player")
        {
            transform.localScale = transform.localScale + new Vector3(0, 0, scale);
            transform.localScale = transform.localScale + new Vector3(scale, 0, 0);

            audioSource.clip = wallSoundClip;
            audioSource.Play();

            StartCoroutine(scaleDownZ());
            StartCoroutine(scaleDownX());
        }


    }

    IEnumerator scaleDownZ()
    {
        yield return new WaitForSeconds(.25f);

        transform.localScale = transform.localScale + new Vector3(0, 0, -scale);
    }

    IEnumerator scaleDownX()
    {
        yield return new WaitForSeconds(.25f);

        transform.localScale = transform.localScale + new Vector3(-scale, 0, 0);
    }

}
