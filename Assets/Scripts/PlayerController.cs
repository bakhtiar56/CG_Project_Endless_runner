using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    //Move Left Right 
    private int desireLane = 1; //Default is -2, 1 is left, -4 is right
    public float laneDistance = 3; 
    public float laneSpeed = 100;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        direction.z = -forwardSpeed;

        //Lane 
        if(Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            desireLane++; //one press
            if(desireLane == 3) //two press 
                desireLane = 2;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            desireLane--; //one press
            if(desireLane == -1) //two press 
                desireLane = 0;
        }
        //Calculate where we should be 
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desireLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desireLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;

        }

        
        transform.position = Vector3.Lerp(transform.position, targetPosition, laneSpeed* Time.deltaTime);

    } 

    private void FixedUpdate()
    {
        controller.Move(direction*Time.fixedDeltaTime);
    }
}
