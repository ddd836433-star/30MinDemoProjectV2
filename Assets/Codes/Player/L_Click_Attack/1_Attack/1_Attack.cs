using UnityEngine;

public class Attack_1 : MonoBehaviour
{
    private Animator AttackAnimator_1;

    private AD_Move AD_MoveScript;
    
    void Start()
    {
        AttackAnimator_1 = GetComponent<Animator>();

        AD_MoveScript = GetComponent<AD_Move>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !AD_MoveScript.isAttacking)
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
