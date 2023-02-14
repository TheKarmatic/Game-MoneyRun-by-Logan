using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ChMovement : MonoBehaviour
{
    //Movement
    bool jump = false;
    bool jumpAvab = true;
    public float speed, jumpForce;
    public float jumpCd;

    //State Manager
    bool grounded = true;
    bool fell = false;
    bool stop = false;

    //Componenets
    Animator animator;
    Rigidbody rb;
    GameManager manager;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        fell = false;
    }

    void Update()
    {
        if (manager.start && !stop)
        {
            AnimatorController(); 

            if (!fell)
            {
                MovementController();
            }
        }
        
        if (grounded)
        {
            rb.useGravity = false;
        }
        else
            rb.useGravity = true;

        if (transform.position.y > 0.25)
        {
            rb.useGravity = true;
        }

        //Skips the level if you get stuck because you bad 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Stop();
        }
    }

    void MovementController()
    {
        //Run
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && !jump && grounded && jumpAvab)
        {
            jump = true;
            jumpAvab = false;
            grounded = false;

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            Invoke("JumpToggle", 0.25f);
        }

        if (rb.velocity.y < 0)
        {
            rb.AddForce(Vector3.up * -2f, ForceMode.Force);
        }
    }

    void JumpToggle()
    {
        jump = false;
    }

    void AnimatorController()
    {
        animator.SetBool("Run", true);
        animator.SetBool("Jump", jump);
    }

    public void FallDown()
    {
        fell = true;
        animator.SetBool("Fail", true);
        manager.start = false;

        if (manager.lives > 1)
        {
            manager.lives -= 1;
            manager.Invoke("ReloadScene", 2f);
        }
        else
            manager.Invoke("LoadEndScenePrematurely", 2f);        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            grounded = true;
            jump = false;

            Invoke("JumpReset", jumpCd);
        }
    }

    void JumpReset()
    {
        jumpAvab = true;
    }

    public void Stop()
    {
        stop = true;
        manager.start = false;
        manager.Invoke("LoadNext", 2f);
    }
}
