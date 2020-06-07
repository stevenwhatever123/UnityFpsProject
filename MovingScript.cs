using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    // Component References
    public Rigidbody rb;
    public Camera camera;
    public GameObject weapon;
    public CapsuleCollider collider;

    // Player's variables and settings
    public float walkingSpeed;
    public float walkingVelocityLimit;
    public float crouchingSpeed;
    public float crouchingVelocityLimit;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public bool grounded = false;
    public bool isJumping = false;
    public bool crouching = false;
    public bool walking;
    public float CrouchHeight;
    public bool runningOnWall;
    
    // Variables for wall climbings
    public bool cameraRotated;
    private RaycastHit hitL;
    private RaycastHit hitR;
    public bool isWallL;
    public bool isWallR;
    public float wallClimbingTime = 1f;

    // Camera Settings
    public float turnSpeed = 4.0f;
    public float moveSpeed = 2.0f;
    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;
    private float rotX;
    private float rotY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        KeyBoardMovement();
        wallClimbing();
        MouseAiming();
        Falling();
        Jump();
        crouch();
        crouchingToNormal(); 
    }

    // Function for reading the mouse movement and rotation the camera and the player
    void MouseAiming ()
    {
        // get the mouse inputs
        rotY += Input.GetAxis("Mouse X") * turnSpeed;
        rotX += Input.GetAxis("Mouse Y") * turnSpeed;
    
        // clamp the vertical rotation
        rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        // rotate the camera
        transform.eulerAngles = new Vector3(-rotX, rotY, 0);
        camera.transform.eulerAngles = new Vector3(-rotX, rotY, 0);
    }

    // Player crouching
    void crouch(){
        if (Input.GetKey(KeyCode.LeftControl)){
            if(!crouching){
                collider.height -= CrouchHeight;
                collider.center += new Vector3(0, CrouchHeight/2, 0);
                crouching = true;
            }
        }
    }

    // Player getting up from crouching
    void crouchingToNormal(){
        if (Input.GetKeyUp(KeyCode.LeftControl)){
            collider.height += CrouchHeight;
            collider.center -= new Vector3(0, CrouchHeight/2, 0);
            crouching = false;
        }
    }

    // Player's jumping calculations
    void Jump(){
        if(!isJumping && Input.GetKeyDown(KeyCode.Space)){
            rb.useGravity = true;
            isWallL = false;
            isWallR = false;
            runningOnWall = false;
            if(grounded){
                rb.AddForce(Vector3.up * jumpForce * rb.mass);
            } else {
                rb.AddForce(Vector3.up * jumpForce * rb.mass * 2);
            }
            isJumping = true;
        }
    }

    // Player's falling calculations
    void Falling(){
        if(rb.useGravity){
            if(rb.velocity.y < 0){
                rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier -1) * Time.deltaTime;
            } else if (rb.velocity.y > 0 && !Input.GetButton("Jump")){
                rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier -1) * Time.deltaTime;
            }
        }
    }

    void wallClimbing(){
        // When the player hit the wall on the left
        if(Physics.Raycast(transform.position, -transform.right, out hitL, 1)){
            if(hitL.transform.tag  == "Wall"){
                runningOnWall = true;
                cameraRotated = true;
                isWallL = true;
                isWallR = false;
                rb.useGravity = false;
                isJumping = false;
                StartCoroutine(afterRun());
            }
        }
        // When the player hit the wall on the right
        if(Physics.Raycast(transform.position, transform.right, out hitR, 1)){
            if(hitR.transform.tag  == "Wall"){
                runningOnWall = true;
                cameraRotated = true;
                isWallR = true;
                isWallL = false;
                rb.useGravity = false;
                isJumping = false;
                StartCoroutine(afterRun());
            }
        }
    }

    // Duration for the animation and climbing on the wall
    IEnumerator afterRun(){
        yield return new WaitForSeconds(wallClimbingTime);
        isWallL = false;
        isWallR = false;
        runningOnWall = false;
        cameraRotated = false;
        rb.useGravity = true;
    }

    // Keyboard input
    void KeyBoardMovement(){

        // Updating player's velocity on the x axis and y axis
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Temp for storing the speed in different condition(E.g. normal walking / crouch walking)
        float speedTemp = walkingSpeed;
        float speedLimitTemp = walkingVelocityLimit;
        
        if(runningOnWall){
            if(isWallL){
                rb.velocity -= (transform.forward * moveX).normalized * speedTemp * Time.deltaTime;
            } else if(isWallR){
                rb.velocity += (transform.forward * moveX).normalized * speedTemp * Time.deltaTime;
            }
        } else {
            if(crouching){
                speedTemp = crouchingSpeed;
                speedLimitTemp = crouchingVelocityLimit;
            }
            rb.velocity += (transform.right * moveX + transform.forward * moveY).normalized * speedTemp * Time.deltaTime;
            // If the player exceed the walking velocity limit, 
            //  we set the player's velocity to the limit that we set
            if(rb.velocity.magnitude > speedLimitTemp){
                rb.velocity = rb.velocity.normalized * speedLimitTemp;
            }
        }
    }

    // Check if collision exist, if yes we set the condition to true;
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            isJumping = false;
        } 

        if(collision.gameObject.tag == "Wall"){
            runningOnWall = true;
            isJumping = false;
        }
    }

    // Check if collision exist after leaving and changing its conditions.
    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
             grounded = false;
        }

        if(collision.gameObject.tag == "Wall"){
            runningOnWall = false;
            cameraRotated = false;
            rb.useGravity = true;
        }
    }

}
