using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinWin : MonoBehaviour
{

    Rigidbody rb;
    public bool P1 = false;
    public bool P2 = false;
    public bool P3 = false;
    public bool P4 = false;
    public bool P5 = false;
    public bool P6 = false;
    public bool P7 = false;
    public bool P8 = false;
    public bool P9 = false;
    public bool P10 = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (P1 == true & P2 == true & P3 == true & P4 == true & P5 == true & P6 == true & P7 == true & P8 == true & P9 == true & P10 == true)
        {
            SceneManager.LoadScene(2);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "P1")
        {
            P1 = true;
        }

        if (other.tag == "P2")
        {
            P2 = true;
        }

        if (other.tag == "P3")
        {
            P3 = true;
        }

        if (other.tag == "P4")
        {
            P4 = true;
        }

        if (other.tag == "P5")
        {
            P5 = true;
        }

        if (other.tag == "P6")
        {
            P6 = true;
        }

        if (other.tag == "P7")
        {
            P7 = true;
        }

        if (other.tag == "P8")
        {
            P8 = true;
        }

        if (other.tag == "P9")
        {
            P9 = true;
        }

        if (other.tag == "P10")
        {
            P10 = true;
        }

    }

}
