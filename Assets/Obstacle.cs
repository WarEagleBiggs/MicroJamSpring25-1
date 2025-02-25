using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Rigidbody rb;
    public float moveVelocity;
    

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector3(0, 0, -1) * moveVelocity * Time.deltaTime;
    }
}