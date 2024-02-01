using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    public float speedX;
    public float speedY;
    private float moveX;
    private float moveY;

    public int myScore;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveX * speedX, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, moveY * speedY);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            Destroy(gameObject);
        }

        
    }

}
