using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public Collider col;
    public float maxSpeed;
    private bool isCollide=true;

    //Move Left Right 
    private int desireLane = 0; //Default is -2, 1 is left, -4 is right
    public float laneDistance = 3; 
    public float laneSpeed =2 ;

    //Jump code
    public Animator anim;
    public float jumpForce = 10;
    public float gravity = -20;

    //Score System
    public static int currentScore;
    public Text uiScore;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        direction.z = -forwardSpeed;
        Time.timeScale = 1;
        col= GetComponent<Collider>();
        currentScore = 0;
        laneSpeed = 3;



    }
    private void afterSlide()
    {
        controller.detectCollisions = true;
        laneSpeed = 2;
        isCollide = true;
    }

    void Update()
    {

        //Score System
        uiScore.text = "Score " + currentScore.ToString();



        //Lane 
        if(Input.GetKeyDown(KeyCode.RightArrow)) 
        {
             if(desireLane==2){
                desireLane=1;
            }
            else if(desireLane ==0) //two press 
                {desireLane +=1;}
            else if (desireLane == 1) //two press 
            { desireLane += 1; }
            else if(desireLane ==-1) //two press 
                {desireLane +=1;}
            else if (desireLane == -2) //two press 
            { desireLane += 1; }
            else if (desireLane == -3) //two press 
            { desireLane += 1; }


        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // if(desireLane <1) //two press 
            //     desireLane -= 1;
             if(desireLane==-3){
                desireLane=0;
            }
       
                     else if(desireLane ==0) //two press 
                {desireLane -=1;}

                   else if(desireLane ==1) //two press 
                {desireLane -=1;}
            else if (desireLane == 2) //two press 
            { desireLane -= 1; }
            else if (desireLane == -1) //two press 
            { desireLane -= 1; }
            else if (desireLane == -2) //two press 
            { desireLane -= 1; }









        }

        //Vector3 targetPosition = transform.position;
        // targetPosition.x = desireLane;
        //Vector3 target = direction;
        //direction.z = 0;
        //direction.x = desireLane*3;
        //direction.z = target.z;
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
            isCollide = false;
            Invoke(nameof(afterSlide), 1.5f);

            controller.detectCollisions = false;
            //col.enabled = !col.enabled;
            laneSpeed = 0;

            StartCoroutine(Slider());
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            //controller.detectCollisions = false;

        }



    } //end update function

    private void FixedUpdate()
    {
        direction.x = Input.GetAxis("Horizontal")*laneSpeed;
        controller.Move(direction*Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
        anim.SetTrigger("JumpTrigger");       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            //Debug.Log("Collided" + other.transform.parent.name);

            currentScore += 1;
            SoundManager.sound.coinSource.PlayOneShot(SoundManager.sound.coinSound);
            Destroy(other.gameObject);

        }
    }
    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    Debug.Log("Collided");
    //    if (hit.gameObject.tag == "Coin")
    //    {
    //        Debug.Log("Collided");

    //        currentScore += 1;
    //        SoundManager.sound.coinSource.PlayOneShot(SoundManager.sound.coinSound);
    //        Destroy(hit.gameObject);
    //    }    }

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
            forwardSpeed -= 0.5f * Time.deltaTime;
        }

    }
    //game over function
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("obstacle") && isCollide)
        {
            GameManager.gameOver = true;
        }
    }



}                                                         
