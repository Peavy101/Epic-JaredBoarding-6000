using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    public bool canMove = true;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
        
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }

        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }


    void RotatePlayer()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }

        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground" && canMove)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {  
        if(other.gameObject.tag == "Ground")
        {
            GetComponent<AudioSource>().Stop();
        }
    }

    }
}
