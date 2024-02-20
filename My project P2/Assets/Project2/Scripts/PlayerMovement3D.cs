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

    public float lookSpeed = 100f;
    public Camera myCam;

    Vector3 myLook;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        myLook = myCam.transform.forward;
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerLook = myCam.transform.forward;
        Vector3 newLook = DeltaLook();
        myLook += DeltaLook() * Time.deltaTime;
        
        transform.rotation = Quaternion.Euler(0f, myLook.x, 0f);
        myCam.transform.rotation = Quaternion.Euler(-myLook.y, myLook.x, 0f);

    }
    private void FixedUpdate()
    {

        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(moveX * speedX, 0, rb.velocity.z);
        rb.velocity = new Vector3(rb.velocity.x, 0, moveZ * speedZ);

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
}
