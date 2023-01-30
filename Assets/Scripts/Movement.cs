using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed;
    public Rigidbody2D rb;
    private bool IsFacingRight;
    public bool IsJumping;

    [SerializeField] [Range(0.1f,0.5f)]
    private float coyoteTime;
    [SerializeField] private Transform _groundCheckPoint;
	//Size of groundCheck depends on the size of your character generally you want them slightly small than width (for ground) and height (for the wall check)
	[SerializeField] private Vector2 _groundCheckSize = new Vector2(0.85f, 0.03f);
    [SerializeField] private LayerMask _groundLayer;

    private Vector2 _moveInput;
    private float LastOnGroundTime;

    private Animator animator;
    // private float LastPressedJumpTime;
    // last pressed momentan nu face nimic
    // last ground inseamna cat poti inca sa sari dupa ce nu mai esti pe ground
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent < Animator>();
        
        IsFacingRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        LastOnGroundTime -= Time.deltaTime;
        //LastPressedJumpTime -= Time.deltaTime;

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
		}
        if (Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer))//checks if set box overlaps with ground
			LastOnGroundTime = coyoteTime;
        if(Input.GetKey("w"))
        {
            if (Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer) && !IsJumping){ //checks if set box overlaps with ground
				LastOnGroundTime = 0.5f; //if so sets the lastGrounded to coyoteTime
                //LastPressedJumpTime = 0.5f;
                Jump();
                IsJumping = true;
            }
            if(LastOnGroundTime > 0)
            {
                Jump();
                IsJumping = true;
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

        //LastPressedJumpTime = 0;
		LastOnGroundTime = 0;

        float force = 5;
		    if (rb.velocity.y < 0)
			    force -= rb.velocity.y;

        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
    //degeaba momentan vad daca mai fac ceva la ea :)))
    private bool CanJump()
    {
		return LastOnGroundTime > 0 && !IsJumping;
    }
    private void OnDrawGizmosSelected()
    {
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(_groundCheckPoint.position, _groundCheckSize);
	}
}
