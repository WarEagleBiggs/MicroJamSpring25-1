using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public float moveForce;
    public Vector3 LeftVector;
    public Vector3 RightVector;

    void Update()
    {

        
        if (Input.GetKey(KeyCode.A) )
        {
            //move left
            rb.linearVelocity = LeftVector * moveForce;
        } else if (Input.GetKeyUp(KeyCode.A) )
        {
            rb.linearVelocity = new Vector3(0, 0, 0);
        } else if (Input.GetKey(KeyCode.D))
        {
            //move right
            rb.linearVelocity = RightVector * moveForce;
        } else if (Input.GetKeyUp(KeyCode.D))
        {
            rb.linearVelocity = new Vector3(0, 0, 0);
        }
        
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "obs")
        {
            //die
            SceneManager.LoadScene("SampleScene");
        }
    }
}