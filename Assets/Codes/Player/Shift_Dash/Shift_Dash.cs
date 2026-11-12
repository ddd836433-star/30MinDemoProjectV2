using UnityEngine;

public class Shift_Dash : MonoBehaviour
{
    private Animator DashAnimator;
    private Rigidbody2D DashRigidbody;

    private AD_Move AD_MoveScript;
    private Space_Jump Space_JumpScript;

    private bool NowDashing = false;

    public int DashSpeed = 15;

    void Start()
    {
        DashAnimator = GetComponent<Animator>();
        DashRigidbody = GetComponent<Rigidbody2D>();

        AD_MoveScript = GetComponent<AD_Move>();
        Space_JumpScript = GetComponent<Space_Jump>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Space_JumpScript.isGrounded)
        {
            AD_MoveScript.isDashing = true;

            NowDashing = true;

            DashAnimator.SetBool("isDash", true);

            Invoke(nameof(EndDashing), 0.2f);

        } 
    }

    void FixedUpdate()
    {
        if (NowDashing && !AD_MoveScript.isAttacking)
            DashRigidbody.linearVelocity = new Vector2(AD_MoveScript.MoveInput * DashSpeed, DashRigidbody.linearVelocity.y);
    }

    private void EndDashing()
    {
        DashAnimator.SetBool("isDash", false);

        AD_MoveScript.isDashing = false;

        NowDashing = false;

    }
}
