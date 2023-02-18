using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    public Rigidbody2D rb;
    private bool IsFacingRight;
    private bool IsJumping;
    public bool IsGrounded;
    private float LastOnGroundTime;
    [SerializeField] [Range(0f,0.5f)] private float coyoteTime = 0;
    [SerializeField] private Transform _groundCheckPoint;
	[SerializeField] private Vector2 _groundCheckSize = new Vector2(0.85f, 0.03f);
    [SerializeField] private LayerMask _groundLayer;

    private Vector2 _moveInput;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent <Animator>();
        IsFacingRight = true;
        animator.SetBool("IsJumping", false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer);
        LastOnGroundTime -= Time.deltaTime;
        animator.SetBool("IsGround", IsGrounded);

        _moveInput.x = Input.GetAxis("Horizontal");
        _moveInput.y = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(_moveInput.x * speed, rb.velocity.y);

        if (_moveInput.x != 0)
        {
            animator.SetBool("IsRunning", true);
            CheckDirectionToFace(_moveInput.x > 0);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        if (IsJumping && rb.velocity.y < 0)
        {
			IsJumping = false;
            animator.SetBool("IsJumping", false);
		}

        if (IsGrounded && !IsJumping){
            LastOnGroundTime = coyoteTime;
            animator.SetBool("IsGround", true);
            animator.SetBool("IsJumping", false);
            if(Input.GetKeyDown("w"))
            {
                Jump();
                IsJumping = true;
                animator.SetBool("IsJumping", true);
                animator.SetBool("IsGround", false);
            }
        }
        else if(LastOnGroundTime > 0 && !IsJumping)
        {
            if(Input.GetKeyDown("w"))
            {
                Jump();
                IsJumping = true;
                animator.SetBool("IsJumping", true);
                animator.SetBool("IsGround", false);
            }
        }

        if (Input.GetKey("y"))
            transform.position = Vector3.zero;

        if(Input.GetKeyDown("s")){
            if(!IsGrounded){
                Stomp();
            }else{
                Debug.Log("No Stomp");
            }
        }

    }
    public void CheckDirectionToFace(bool isMovingRight)
	{
		if (isMovingRight != IsFacingRight)
			Turn();
	}
    private void Turn()
	{
		//stores scale and flips the player along the x axis
		Vector3 scale = transform.localScale; 
		scale.x *= -1;
		transform.localScale = scale;
        
		IsFacingRight = !IsFacingRight;
	}
    private void Jump(){

		LastOnGroundTime = 0;

        float force = 5;
		if (rb.velocity.y < 0)
	        force -= rb.velocity.y;

        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    private void Stomp(){
        float force = 50;
        rb.AddForce(Vector2.down * force, ForceMode2D.Impulse);
        Debug.Log("Stomp");
    }

    private void OnDrawGizmosSelected()
    {
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(_groundCheckPoint.position, _groundCheckSize);
	}
}
