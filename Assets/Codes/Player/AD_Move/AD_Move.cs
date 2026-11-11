using UnityEngine;

public class AD_Move : MonoBehaviour
{
    private Animator MoveAnimator;
    private SpriteRenderer MoveSpriteRenderer;
    private Rigidbody2D MoveRigidbody;

    public float MoveSpeed = 5f;

    private float MoveInput;
    
    void Start()
    {
        MoveAnimator = GetComponent<Animator>();
        MoveSpriteRenderer = GetComponent<SpriteRenderer>();
        MoveRigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        MoveInput = Input.GetAxisRaw("Horizontal");

        if (MoveInput > 0)
        {
            MoveSpriteRenderer.flipX = false;

            MoveAnimator.SetBool("isMove", true);
        } 
        
        if (MoveInput < 0)
        {
            MoveSpriteRenderer.flipX = true;

            MoveAnimator.SetBool("isMove", true);
        }

        if (MoveInput == 0)
        {
            MoveAnimator.SetBool("isMove", false);
        }
    }

    void FixedUpdate()
    {
        MoveRigidbody.linearVelocity = new Vector2(MoveSpeed * MoveInput, MoveRigidbody.linearVelocity.y);
    }
}
