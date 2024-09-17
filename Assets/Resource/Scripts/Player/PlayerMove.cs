using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float leftRightSpeed;

    public bool isJumping = false;
    public bool isCommingDown = false;
    public bool isGrounded = true;
    public Rigidbody rb;

    public Animator animator;
    public string currentAnimation = "idle";
    public bool isRunning = false;
    public AudioSource obsFX;
    public LevelBoundary levelBoundary;

    public LayerMask groundLayer;

    private void Start()
    {
        ChangeAnimation("idle");
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = CheckGroundStatus();
        Debug.Log(CheckGroundStatus());

        if (isRunning == true) 
        {
            Move();
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded == true) 
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && isJumping && isCommingDown == false)
        {
            CommingDown();
        }

        if (isGrounded && (isJumping || isCommingDown))
        {
            isJumping = false;
            isCommingDown = false;
            ChangeAnimation("run");
        }

    }

    public void StartRunning() 
    {
        isRunning = true;
        ChangeAnimation("run");
    }

    public void Move()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * leftRightSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.right * leftRightSpeed * Time.deltaTime);
            }
        }
    }

    public void Jump() 
    {
        isJumping = true;
        isGrounded = false;
        rb.AddForce(Vector3.up * 25f);
        ChangeAnimation("jump");
    }

    public void CommingDown()
    {
        isCommingDown = true;
        transform.Translate(Vector3.up * Time.deltaTime * -3f, Space.World);
    }

    private bool CheckGroundStatus()
    {
        RaycastHit hit;
        //Debug.DrawRay(transform.position, Vector3.down * 1.1f, Color.red, 0.1f);
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f, groundLayer))
        {
            return true;
        }
        return false;
    }

    public void ChangeAnimation(string animName)
    {
        if (currentAnimation != animName)
        {
            animator.ResetTrigger(animName);
            currentAnimation = animName;
            animator.SetTrigger(currentAnimation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            ChangeAnimation("dead");
            obsFX.Play();
            levelBoundary.GameOver();
            isRunning = false;
        }
    }

}
