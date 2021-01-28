using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovementfirst : MonoBehaviour
{
    public bool collid = false;
    private CharacterController characterController;
    [SerializeField] private float movementSpeed;

    [Header("Gravity Options")]
    [SerializeField] [Range(-80f, 0f)] private float gravityScale = -40f;
    [SerializeField] [Range(2f, 30f)] private float jumpHeight = 5f;

    [Header("Ground Options")]
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Button Options")]
    [SerializeField] private string jumpButton = "Jump";

    private Vector3 movementDirection;
    private Vector3 verticalVelocity;
    private bool canDoubleJump;
    private bool isGrounded;

    public bool CanDoubleJump { get => canDoubleJump; set => canDoubleJump = value; }
    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }

    public spawnmanager Spawnmanager;

    void Start()
    {
        Time.timeScale = 1;
        characterController = GetComponent<CharacterController>();
        current_speed = movementSpeed;
        max_run_speed = current_speed * 5;
        SoundManagerScript.playsound("gamesound");

    }
    float current_speed;
    float max_run_speed;

    void Update()
    {
        GroundCheck();
        HorizontalMovement();
        VerticalMovement();
        Jump();
    }

    private void Jump()
    {
        if (IsGrounded && Input.GetButtonDown(jumpButton))
        {
            verticalVelocity.y = Mathf.Sqrt(-2 * jumpHeight * gravityScale);
            CanDoubleJump = true;
        }
        else if (Input.GetButtonDown(jumpButton) && CanDoubleJump)
        {
            CanDoubleJump = false;
            verticalVelocity.y = Mathf.Sqrt(-2 * jumpHeight * gravityScale);
        }
    }

    private void VerticalMovement()
    {
        if (IsGrounded && verticalVelocity.y < 0f)
        {
            verticalVelocity.y = 0f;
        }
        else
        {
            verticalVelocity.y += gravityScale * Time.deltaTime;
        }
        characterController.Move(verticalVelocity * Time.deltaTime);
    }

    private void HorizontalMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection = transform.TransformDirection(movementDirection);

        bool runpress = Input.GetKey("left shift");

        if (runpress)
        {
            if (current_speed <= max_run_speed) //acceleration
                current_speed += Time.deltaTime * 5;
          //  Debug.Log("Acceleration:" + current_speed);
            Debug.Log("player is trying to run");
        }
        else
        {
            if (current_speed >= movementSpeed)
                current_speed -= Time.deltaTime * 5;
           // Debug.Log("deceleration:" + current_speed);
            Debug.Log("player is trying stopped");
        }
        characterController.Move(movementDirection * current_speed * Time.deltaTime);
       
    }

    private void GroundCheck()
    {
        IsGrounded = Physics.CheckSphere(groundCheckTransform.position, groundCheckRadius, whatIsGround);
    }
    private void OnTriggerEnter(Collider other)
    {
        Spawnmanager.SpawnTriggerEnter();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag =="obstical")
        {
            gamemanager.gameover = true;
            SoundManagerScript.stopsound();

            collid = true;

            if(collid== true)
            {
                SoundManagerScript.playsound("playercollide");
                collid = false;
            }
        }

    }
}
