using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement3D : MonoBehaviour
{

    private Rigidbody rb;

    public float speedX;
    public float speedZ;
    private float moveX;
    private float moveZ;

    public float jump;
    public bool onGround = false;

    public float lookSpeed = 100f;
    public Camera myCam;
    public float camLock;

    Vector3 myLook;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        myLook = myCam.transform.forward;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerLook = myCam.transform.forward;
        Vector3 newLook = DeltaLook();
        myLook += DeltaLook() * Time.deltaTime;

        myLook.y = Mathf.Clamp(myLook.y, -camLock, camLock);
        
        transform.rotation = Quaternion.Euler(0f, myLook.x, 0f);
        myCam.transform.rotation = Quaternion.Euler(-myLook.y, myLook.x, 0f);

        if (Input.GetKey(KeyCode.Return))
        {
            Kick();
        }

        if (Input.GetKeyDown(KeyCode.Space))

    }
    private void FixedUpdate()
    {

        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(moveX * speedX, 0, moveZ * speedZ));
        


    }

    void jump()
    {
        
    }

    
    void OnCollisionStay(Collision other)
    { 
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }


    Vector3 DeltaLook()
    {

        Vector3 dLook = Vector3.zero;
        float rotX = Input.GetAxisRaw("Mouse X") * lookSpeed;
        float rotY = Input.GetAxisRaw("Mouse Y") * lookSpeed;
        dLook = new Vector3(rotX, rotY, 0);
        
        if (dLook != Vector3.zero)
        {
            Debug.Log("Delta look:" + dLook);
        }

        return dLook;

    }

    void Kick()
    {
        bool rayCast = Physics.Raycast(transform.position, Vector3.forward, 5f);
        Debug.DrawRay(transform.position, Vector3.forward * 5f, Color.blue);
        
        if(rayCast)
        {

        }

    }

   
}
