using UnityEngine;

public class Attack_2 : MonoBehaviour
{
    private Animator AttackAnimator_2;
    private Combo_Attack ComboAttackScript;
    private AD_Move AD_MoveScript ;
    
    void Start()
    {
        AttackAnimator_2 = GetComponent<Animator>();

        ComboAttackScript = GetComponent<Combo_Attack>() ;
        AD_MoveScript = GetComponent<AD_Move>() ;

    }

    void Update()
    {
        if (ComboAttackScript.canCombo)
        {
            if (Input.GetMouseButtonDown(0))
            {
                AttackAnimator_2.SetBool("isAttack_1", false);
                AttackAnimator_2.SetBool("isAttack_2", true);

            } 
        }

        if (ComboAttackScript.isFinishCombo) 
        {
            AttackAnimator_2.SetBool("isAttack_2", false) ;
            AD_MoveScript.isAttacking = false ;

        }
    }
}
