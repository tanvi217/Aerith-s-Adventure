using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aerith : MonoBehaviour{
    public float moveSpeed;
    private float moveSpeedStore;
    public float speedMultiplier;

    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;

    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;

    private bool hasStoppedJumping;
    private bool canDoubleJump;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    private Animator myAnimator;

    public GameManager1 theGameManager;

    public AudioSource deathSound;

    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();

        myAnimator = GetComponent<Animator>();

        speedMilestoneCount = speedIncreaseMilestone;

        jumpTimeCounter = jumpTime;

        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

        hasStoppedJumping = true;
    }
    

    void Update() {
        
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if(transform.position.x > speedMilestoneCount) {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) ) {
            if(grounded) {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                hasStoppedJumping = false;
            }

            if(!grounded && canDoubleJump) {
                myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                hasStoppedJumping = false;
                canDoubleJump = false;
            }
        }

        if( (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) ) && !hasStoppedJumping) {
            if(jumpTimeCounter > 0) {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) {
            jumpTimeCounter = 0;
            hasStoppedJumping = true;
        }

        if(grounded) {
            jumpTimeCounter = jumpTime;
            canDoubleJump = true;
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);
        myAnimator.SetBool("Grounded", grounded);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "kill") {
            
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            deathSound.Play();
        }
    }
}

