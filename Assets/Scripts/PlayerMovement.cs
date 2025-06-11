using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public int forwardForce = 2000;
    public int sideForce = 500;
    public int jumpForce = 200;
    private float rightBorder = 6.9f;
    private float leftBorder = -6.9f;
    private bool isGrounded;
    public Score Score;

    public Animator anim;
    private string jumpanim = "onJump";

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();  // pairnei automata to Rigidbody tou antikeimenou pou evala to script
        rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);  // Time.deltaTime = o xronos pou mesolavei anamesa sta frames (60fps = 1/60 = 0.01667 seconds to kathe frame)

        // h kinisi deksia - aristera
        if (Input.GetKey("a") && transform.position.x > leftBorder)
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("d") && transform.position.x < rightBorder)
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown("space")&& isGrounded == true)
        {
            rb.AddForce(0, jumpForce, 0);
            anim.SetBool(jumpanim, true);
        }

        // kollaei ton kuvo sto orio otan tha paei na to perasei
        if (transform.position.x < leftBorder)
        {
            rb.position = new Vector3(leftBorder, rb.position.y, rb.position.z);
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, rb.linearVelocity.z);
        }
        else if (transform.position.x > rightBorder)
        {
           rb.position = new Vector3(rightBorder, rb.position.y, rb.position.z);
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, rb.linearVelocity.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {
            Score.GameOver();
        }
        if (collision.gameObject.name == "Finish")
        {
            Score.WinGame();
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            isGrounded = true;
            anim.SetBool(jumpanim, false);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = false;
        }
    }
}
