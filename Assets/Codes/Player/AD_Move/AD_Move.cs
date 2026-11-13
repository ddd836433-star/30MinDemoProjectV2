using UnityEngine;

public class AD_Move : MonoBehaviour
{
    private Animator MoveAnimator;
    private SpriteRenderer MoveSpriteRenderer;
    private Rigidbody2D MoveRigidbody;

    public float MoveSpeed = 5f;

    public float MoveInput;

    public bool isDashing = false;
    public bool isAttacking = false;

    public Transform hitboxTransform ;
    private Vector3 hitboxStartPosition ;
    private Vector3 hitboxStartScale ;
    
    void Start()
    {
        MoveAnimator = GetComponent<Animator>();
        MoveSpriteRenderer = GetComponent<SpriteRenderer>();
        MoveRigidbody = GetComponent<Rigidbody2D>();

        hitboxStartPosition = hitboxTransform.localPosition ;
        hitboxStartScale = hitboxTransform.localScale ;

    }

    
    void Update()
    {
        MoveInput = Input.GetAxisRaw("Horizontal");

        if (MoveInput > 0)
        {
            if (!isAttacking) {
                MoveSpriteRenderer.flipX = false;

                hitboxTransform.localPosition = hitboxStartPosition ;
                hitboxTransform.localScale = hitboxStartScale ;

            }

            MoveAnimator.SetBool("isMove", true);

            

        } 
        
        if (MoveInput < 0)
        {
            if (!isAttacking) {
                MoveSpriteRenderer.flipX = true;

                hitboxTransform.localPosition = new Vector3 (-hitboxStartPosition.x, hitboxStartPosition.y, hitboxStartPosition.z) ;
                hitboxTransform.localScale = new Vector3 (-hitboxStartScale.x, hitboxStartScale.y, hitboxStartScale.z) ;
            }

            MoveAnimator.SetBool("isMove", true);

        }

        if (MoveInput == 0)
        {
            MoveAnimator.SetBool("isMove", false);

        }
    }

    void FixedUpdate()
    {
        if (isAttacking) {
            MoveRigidbody.linearVelocity = new Vector2(0, 0);
        }

        if (isDashing == false && isAttacking == false)
            MoveRigidbody.linearVelocity = new Vector2(MoveSpeed * MoveInput, MoveRigidbody.linearVelocity.y);

    }
}
