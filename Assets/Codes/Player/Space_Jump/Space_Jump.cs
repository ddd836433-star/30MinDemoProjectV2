using UnityEngine;

public class Space_Jump : MonoBehaviour
{
    private Rigidbody2D JumpRigidbody;
    private Animator JumpAnimator;

    private bool isJumped = false;
    public bool isGrounded = false;

    public float JumpForce = 5f ;
    
    void Start()
    {
        JumpRigidbody = GetComponent<Rigidbody2D>();
        JumpAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumped = true;

            JumpAnimator.SetBool("isJump", true);

        } else
        {
            JumpAnimator.SetBool("isJump", false);

        }
    }

    void FixedUpdate()
    {
        if (isJumped == true)
        {
            JumpRigidbody.linearVelocity = new Vector2(JumpRigidbody.linearVelocity.x, JumpForce);

            isJumped = false;

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collsion)
    {
        isGrounded = false;
    }
}
