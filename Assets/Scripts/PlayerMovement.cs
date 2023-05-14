using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody RB;
    [SerializeField] float movementSpeed = 6f;
    float jumpForce = 5f;
    [SerializeReference] Transform GroundCheck;
    [SerializeReference] LayerMask Ground;
    [SerializeField] AudioSource jumpSound;
    [SerializeReference] AudioSource runSound;
    float rotSpeed = 0.9f;
    float rot;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello Lamar");
        RB = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");
        RB.velocity = new Vector3(0, RB.velocity.y, verticalinput * movementSpeed);
        RB.velocity = transform.TransformDirection(RB.velocity);
        rot += Input.GetAxis("Horizontal") * rotSpeed;
        transform.eulerAngles = new Vector3(0, rot, 0);

        if (Input.GetButtonDown("Jump") && IsGrounded()) 
        {
            anim.SetBool("is jump", true);
            Jump();

        }
        else
        {
            anim.SetBool("is jump", false);
        }


        if ((Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.S)) && IsGrounded())
        {
            anim.SetBool("is run", true);
        }
        else
        {
            anim.SetBool("is run", false);
        }
    }
    
    void Jump()
    {
        RB.velocity = new Vector3(RB.velocity.x, jumpForce, RB.velocity.z);
        jumpSound.Play();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head")) 
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool IsGrounded()
        {
        return Physics.CheckSphere(GroundCheck.position, .1f, Ground);
        }

    public void footsteps()
    {

        if ((Input.GetKey(KeyCode.UpArrow) | Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.DownArrow) | Input.GetKey(KeyCode.S)) && IsGrounded())
        {
            runSound.Play();
            return;
        }
        else
        {
            runSound.Stop();
        }
    }

}