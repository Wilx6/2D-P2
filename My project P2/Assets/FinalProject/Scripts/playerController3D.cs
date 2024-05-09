using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class playerController3D : MonoBehaviour
{
    [Header("Base Vars")]
    public float speed = 10f;
    


    Rigidbody myRB;
    

    Vector3 myLook;


    public float force;

    public float scale = .1f;

    Renderer ren;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();

        ren = GetComponent<Renderer>();
        

    }
    // Update is called once per frame
    void Update()
    {

       
    }

    void FixedUpdate()
    {
        Vector3 pMove = transform.TransformDirection(Dir());
        myRB.AddForce(pMove * speed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.Space) & Input.GetKey(KeyCode.W))
        {
            myRB.AddForce(Vector3.forward * force);

            transform.localScale = transform.localScale + new Vector3(0, 0, scale);

            ren.material.color = Color.red;

            StartCoroutine(scaleDownZ());
            
        }

        if (Input.GetKey(KeyCode.Space) & Input.GetKey(KeyCode.S))
        {
            myRB.AddForce(Vector3.back * force);

            transform.localScale = transform.localScale + new Vector3(0, 0, scale);

            ren.material.color = Color.red;

            StartCoroutine(scaleDownZ());
        }

        if (Input.GetKey(KeyCode.Space) & Input.GetKey(KeyCode.A))
        {
            myRB.AddForce(Vector3.left * force);

            transform.localScale = transform.localScale + new Vector3(scale, 0, 0);

            ren.material.color = Color.red;

            StartCoroutine(scaleDownX());
        }

        if (Input.GetKey(KeyCode.Space) & Input.GetKey(KeyCode.D))
        {
            myRB.AddForce(Vector3.right * force);

            transform.localScale = transform.localScale + new Vector3(scale, 0, 0);

            ren.material.color = Color.red;

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
        if (other.tag == "Respawn")
        {
           
            transform.position = new Vector3(-31f, 5f, -15f);

        }

        
    }

    IEnumerator scaleDownZ()
    {
        yield return new WaitForSeconds(.3f);

        ren.material.color = Color.green;
        transform.localScale = transform.localScale + new Vector3(0, 0, -scale);
    }

    IEnumerator scaleDownX()
    {
        yield return new WaitForSeconds(.3f);

        ren.material.color = Color.green;
        transform.localScale = transform.localScale + new Vector3(-scale, 0, 0);
    }
}
