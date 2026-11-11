using UnityEngine;

public class Space_Jump : MonoBehaviour
{
    private Rigidbody2D JumpRigidbody;
    private Animator JumpAnimator;

    private bool isJumped = false;

    public float JumpForce = 5f ;
    
    void Start()
    {
        JumpRigidbody = GetComponent<Rigidbody2D>();
        JumpAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumped = true;

            JumpAnimator.SetTrigger("isJump");
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
}
