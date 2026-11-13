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

    public Transform hitboxTransform_2 ;
    private Vector3 hitboxStartPosition_2 ;
    private Vector3 hitboxStartScale_2 ;
    
    void Start()
    {
        MoveAnimator = GetComponent<Animator>();
        MoveSpriteRenderer = GetComponent<SpriteRenderer>();
        MoveRigidbody = GetComponent<Rigidbody2D>();

        hitboxStartPosition = hitboxTransform.localPosition ;
        hitboxStartScale = hitboxTransform.localScale ;

        hitboxStartPosition_2 = hitboxTransform_2.localPosition ;
        hitboxStartScale_2 = hitboxTransform_2.localScale ;

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

                hitboxTransform_2.localPosition = hitboxStartPosition_2 ;
                hitboxTransform_2.localScale = hitboxStartScale_2 ;

            }

            MoveAnimator.SetBool("isMove", true);

            

        } 
        
        if (MoveInput < 0)
        {
            if (!isAttacking) {
                MoveSpriteRenderer.flipX = true;

                hitboxTransform.localPosition = new Vector3 (-hitboxStartPosition.x, hitboxStartPosition.y, hitboxStartPosition.z) ;
                hitboxTransform.localScale = new Vector3 (-hitboxStartScale.x, hitboxStartScale.y, hitboxStartScale.z) ;

                hitboxTransform_2.localPosition = new Vector3 (-hitboxStartPosition_2.x, hitboxStartPosition_2.y, hitboxStartPosition_2.z) ;
                hitboxTransform_2.localScale = new Vector3 (-hitboxStartScale_2.x, hitboxStartScale_2.y, hitboxStartScale_2.z) ;

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
