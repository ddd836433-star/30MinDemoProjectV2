using UnityEngine;

public class Attack_1 : MonoBehaviour
{
    private Animator AttackAnimator_1;

    private AD_Move AD_MoveScript;
    private Space_Jump Space_JumpScript;
    
    void Start()
    {
        AttackAnimator_1 = GetComponent<Animator>();

        AD_MoveScript = GetComponent<AD_Move>();
        Space_JumpScript = GetComponent<Space_Jump>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) 
            && !AD_MoveScript.isAttacking
            && Space_JumpScript.isGrounded)
        {
            AttackAnimator_1.SetBool("isAttack_1", true);

            AD_MoveScript.isAttacking = true;

            Invoke(nameof(EndAttacking), 0.5f);

        } 
    }

    private void EndAttacking()
    {
        AttackAnimator_1.SetBool("isAttack_1", false);

        AD_MoveScript.isAttacking = false;
    }
}
