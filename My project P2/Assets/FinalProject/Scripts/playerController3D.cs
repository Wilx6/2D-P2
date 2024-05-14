using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController3D : MonoBehaviour
{
    [Header("Base Vars")]
    public float speed = 10f;



    Rigidbody myRB;


    Vector3 myLook;


    public float force;

    public float scale;

    Renderer ren;
    private bool dashable = true;

    [Header("Sounds")]

    [SerializeField] private AudioClip dashSoundClip;
    [SerializeField] private AudioClip deathSoundClip;
    [SerializeField] private AudioClip enemydeathSoundClip;

    private AudioSource audioSource;

    
    

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();

        ren = GetComponent<Renderer>();

        audioSource = GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {

       
    }

    void FixedUpdate()
    {
        Vector3 pMove = transform.TransformDirection(Dir());
        myRB.AddForce(pMove * speed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.Space) & Input.GetKey(KeyCode.W) & dashable == true)
        {
            myRB.AddForce(Vector3.forward * force);

            transform.localScale = transform.localScale + new Vector3(0, 0, scale);

            ren.material.color = Color.red;

            audioSource.clip = dashSoundClip;
            audioSource.Play();

            dashable = false;

            StartCoroutine(scaleDownZ());
            
        }

        if (Input.GetKey(KeyCode.Space) & Input.GetKey(KeyCode.S) & dashable == true)
        {
            myRB.AddForce(Vector3.back * force);

            transform.localScale = transform.localScale + new Vector3(0, 0, scale);

            ren.material.color = Color.red;

            audioSource.clip = dashSoundClip;
            audioSource.Play();

            dashable = false;

            StartCoroutine(scaleDownZ());
        }

        if (Input.GetKey(KeyCode.Space) & Input.GetKey(KeyCode.A) & dashable == true)
        {
            myRB.AddForce(Vector3.left * force);

            transform.localScale = transform.localScale + new Vector3(scale, 0, 0);

            ren.material.color = Color.red;

            audioSource.clip = dashSoundClip;
            audioSource.Play();

            dashable = false;

            StartCoroutine(scaleDownX());
        }

        if (Input.GetKey(KeyCode.Space) & Input.GetKey(KeyCode.D) & dashable == true)
        {
            myRB.AddForce(Vector3.right * force);

            transform.localScale = transform.localScale + new Vector3(scale, 0, 0);

            ren.material.color = Color.red;

            audioSource.clip = dashSoundClip;
            audioSource.Play();

            dashable = false;

            StartCoroutine(scaleDownX());

          
        }

    }

    Vector3 Dir()
    {
        //reference Unity Input Manager virtual axes here
        //horizontal and vertical for WASD
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 myDir = new Vector3(x, 0, z);

        //remove console clutter by only logging direction when input is pressed
        if (myDir != Vector3.zero)
        {
            Debug.Log("Player Move Dir: " + myDir);
        }

        return myDir;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Win")
        {

            SceneManager.LoadScene(2);

        }

        if (other.tag == "EE")
        {
            SceneManager.LoadScene(3);
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" & dashable == true)
        {
            audioSource.clip = deathSoundClip;
            audioSource.Play();
            transform.position = new Vector3(-1843f, 2624f, 246f);
        }
        else if (other.gameObject.tag == "Enemy" & dashable == false)
        {

            audioSource.clip = enemydeathSoundClip;
            audioSource.Play();

            Destroy(other.gameObject);
          
        }

        if (other.gameObject.tag == "EEWall" & dashable == false)
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator scaleDownZ()
    {
        yield return new WaitForSeconds(.5f);

        dashable = true;
        ren.material.color = Color.green;
        transform.localScale = transform.localScale + new Vector3(0, 0, -scale);
    }

    IEnumerator scaleDownX()
    {
        yield return new WaitForSeconds(.5f);

        dashable = true;
        ren.material.color = Color.green;
        transform.localScale = transform.localScale + new Vector3(-scale, 0, 0);
    }
}
