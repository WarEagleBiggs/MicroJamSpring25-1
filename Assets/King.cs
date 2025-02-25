using UnityEngine;
using Unity.Mathematics;

public class King : MonoBehaviour
{
    public GameObject room;  
    public Transform pivot;  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Press");
            room.transform.RotateAround(pivot.position, Vector3.forward, 90f);
        }
    }
}