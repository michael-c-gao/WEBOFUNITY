using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Assingables
    public Transform playerCam;
    public Transform orientation;

    //Other
    private Rigidbody rb;
    
    //Audio
    private AudioSource spiderAudio;
    public AudioClip spiderWalkSound;

    //Rotation and look
    private float xRotation;
    private float sensitivity = 50f;
    private float sensMultiplier = 1f;

    //Movement
    public float maxSpeed = 20;
    public bool grounded;
    public LayerMask whatIsGround;
    private float moveSpeed;
    private float speedScalarStartingSpeed;
    private float speedScalar;

    public float counterMovement = 0.175f;
    private float threshold = 0.01f;
    public float maxSlopeAngle = 35f;

    //Crouch & Slide
     private Vector3 crouchScale = new Vector3(1, 0.5f, 1);
    private Vector3 playerScale;
    public float slideForce = 400;
    public float slideCounterMovement = 0.2f;

    //Jumping
    private bool readyToJump = true;
    private float jumpCooldown = 0.25f;
    public float jumpForce = 25f;

    //Input
    float x, y;
    bool jumping, sprinting, crouching;

    //Sliding
    private Vector3 normalVector = Vector3.up;
    private Vector3 wallNormalVector;

    //initial reference: https://www.youtube.com/watch?v=XAC8U9-dTZU
    //although later we changed it to 3rd person
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        playerScale = transform.localScale;
        
        moveSpeed = GetComponent<PlayerStats>().StartingSpeed;
        speedScalarStartingSpeed = GetComponent<PlayerStats>().StartingSpeed;
        spiderAudio = GetComponent<AudioSource>();
    }


    private void FixedUpdate()
    {

        Cursor.visible = false;
        Cursor.lockState =  CursorLockMode.Confined;

        if (PauseMenu.isPaused){ 
            Cursor.visible = true; 
        }else{ 
            Cursor.visible = false; 
        }
        
        speedScalar = GetComponent<PlayerStats>().getSpeed() / speedScalarStartingSpeed;
        if(!Input.GetKey(KeyCode.Q))
            Movement();
    }

    private void Update()
    {
        if (!PauseMenu.isPaused && !GameOverScreen.isGameOver)
        {
            MyInput();
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && grounded)
            {
                if (!spiderAudio.isPlaying)
                {
                    
                    spiderAudio.clip = spiderWalkSound;
                    spiderAudio.Play();
                }
            }
            else
            {
                spiderAudio.Stop();
            }

            
        }
    }

    private void MyInput()
    {
        x = Input.GetAxisRaw("Horizontal")*1.25f;
        y = Input.GetAxisRaw("Vertical")* 1.25f;
        jumping = Input.GetButton("Jump");
        


    }


    private void StopCrouch()
    {
        
    }

    private void Movement()
    {
        //Extra gravity
        rb.AddForce(Vector3.down * Time.deltaTime * 10);

        //Find actual velocity relative to where player is looking
        Vector2 mag = FindVelRelativeToLook();
        float xMag = mag.x, yMag = mag.y;

        //Counteract sliding and sloppy movement
        CounterMovement(x, y, mag);

        //If holding jump && ready to jump, then jump
        if (readyToJump && jumping) Jump();

        //Set max speed
        float maxSpeed = this.maxSpeed;


        //If speed is larger than maxspeed, cancel out the input so you don't go over max speed
        if (x > 0 && xMag > maxSpeed) x = 0;
        if (x < 0 && xMag < -maxSpeed) x = 0;
        if (y > 0 && yMag > maxSpeed) y = 0;
        if (y < 0 && yMag < -maxSpeed) y = 0;

        //Some multipliers
        float multiplier = 1f, multiplierV = 1f;

        // Movement in air
        if (!grounded)
        {
            multiplier = 0.5f;
            multiplierV = 0.5f;
        }

        // Movement while sliding
        if (grounded && crouching) multiplierV = 0f;

        transform.rotation = new Quaternion(0, playerCam.rotation.y, 0, playerCam.rotation.w);

        //Apply forces to move player
        rb.AddForce(orientation.transform.forward * y * moveSpeed * speedScalar * Time.deltaTime * multiplier * multiplierV);
        rb.AddForce(orientation.transform.right * x * moveSpeed * speedScalar * Time.deltaTime * multiplier);
    }

    private void Jump()
    {
        if (grounded && readyToJump)
        {
            readyToJump = false;

            //Add jump forces
            rb.AddForce(Vector2.up * jumpForce * 0.1f);
            rb.AddForce(normalVector * jumpForce * 0.1f);

            //If jumping while falling, reset y velocity.
            Vector3 vel = rb.velocity;
            if (rb.velocity.y < 0.5f)
                rb.velocity = new Vector3(vel.x, 0, vel.z);
            else if (rb.velocity.y > 0)
                rb.velocity = new Vector3(vel.x, vel.y / 2, vel.z);

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void ResetJump()
    {
        readyToJump = true;
    }

  
   
   

    private void CounterMovement(float x, float y, Vector2 mag)
    {
        if (!grounded || jumping) return;

       

//Counter movement
if (Math.Abs(mag.x) > threshold && Math.Abs(x) < 0.05f || (mag.x < -threshold && x > 0) || (mag.x > threshold && x < 0))
{
    rb.AddForce(moveSpeed * speedScalar * orientation.transform.right * Time.deltaTime * -mag.x * counterMovement);
}
if (Math.Abs(mag.y) > threshold && Math.Abs(y) < 0.05f || (mag.y < -threshold && y > 0) || (mag.y > threshold && y < 0))
{
    rb.AddForce(moveSpeed * speedScalar * orientation.transform.forward * Time.deltaTime * -mag.y * counterMovement);
}


if (Mathf.Sqrt((Mathf.Pow(rb.velocity.x, 2) + Mathf.Pow(rb.velocity.z, 2))) > maxSpeed)
{
    float fallspeed = rb.velocity.y*3;
    Vector3 n = rb.velocity.normalized * maxSpeed;
    rb.velocity = new Vector3(n.x, fallspeed, n.z);
}
    }

    
    public Vector2 FindVelRelativeToLook()
{
    float lookAngle = orientation.transform.eulerAngles.y;
    float moveAngle = Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg;

    float u = Mathf.DeltaAngle(lookAngle, moveAngle);
    float v = 90 - u;

    float magnitue = rb.velocity.magnitude;
    float yMag = magnitue * Mathf.Cos(u * Mathf.Deg2Rad);
    float xMag = magnitue * Mathf.Cos(v * Mathf.Deg2Rad);

    return new Vector2(xMag, yMag);
}

private bool IsFloor(Vector3 v)
{
    float angle = Vector3.Angle(Vector3.up, v);
    return angle < maxSlopeAngle;
}

private bool cancellingGrounded;


private void OnCollisionStay(Collision other)
{
    //Make sure we are only checking for walkable layers
    int layer = other.gameObject.layer;
    if (whatIsGround != (whatIsGround | (1 << layer))) return;

    //Iterate through every collision in a physics update
    for (int i = 0; i < other.contactCount; i++)
    {
        Vector3 normal = other.contacts[i].normal;
        //FLOOR
        if (IsFloor(normal))
        {
            grounded = true;
            cancellingGrounded = false;
            normalVector = normal;
            CancelInvoke(nameof(StopGrounded));
        }
    }

    //Invoke ground/wall cancel, since we can't check normals with CollisionExit
    float delay = 3f;
    if (!cancellingGrounded)
    {
        cancellingGrounded = true;
        Invoke(nameof(StopGrounded), Time.deltaTime * delay);
    }
}

private void StopGrounded()
{
    grounded = false;
}

}
