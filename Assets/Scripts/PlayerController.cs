using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    //Move Left Right 
    private int desireLane = 0; //Default is -2, 1 is left, -4 is right
    public float laneDistance = 3; 
    public float laneSpeed = 100;

    //Jump code
    public Animator anim;
    public float jumpForce = 10;
    public float gravity = -20;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        direction.z = -forwardSpeed;

        
    }

    void Update()
    {


        //Lane 
        if(Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
             if(desireLane==1){
                desireLane=0;
            }
            else if(desireLane ==0) //two press 
                {desireLane +=1;}
            else if(desireLane ==-1) //two press 
                {desireLane +=1;}
            else if (desireLane == -2) //two press 
            { desireLane += 1; }


        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // if(desireLane <1) //two press 
            //     desireLane -= 1;
             if(desireLane==-2){
                desireLane=0;
            }
       
                     else if(desireLane ==0) //two press 
                {desireLane -=1;}

                   else if(desireLane ==1) //two press 
                {desireLane -=1;}
            else if (desireLane == -1) //two press 
            { desireLane -= 1; }









        }

        Vector3 targetPosition = transform.position;
         targetPosition.x = desireLane;
         transform.position=targetPosition;

         transform.Rotate(Vector3.up,0.0f);

        //Jump code
        direction.y += gravity * Time.deltaTime;
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
       
        }

        //Slider Input
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(Slider());
        }



    } //end update function

    private void FixedUpdate()
    {
        controller.Move(direction*Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
        anim.SetTrigger("JumpTrigger");       
    }

    //Slider Function
    IEnumerator Slider()
    {
        anim.SetTrigger("SliderT");
        //controller.height = 1;
        //controller.center = new Vector3(0, -1f, 0);
        yield return new WaitForSeconds(2f);
        //controller.height = 2;
        //controller.center = new Vector3(0, -1, 0);
        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.2f * Time.deltaTime;
        }

    }



}                                                         
