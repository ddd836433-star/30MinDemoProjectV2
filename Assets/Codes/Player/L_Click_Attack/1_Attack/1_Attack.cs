using UnityEngine;

public class Attack_1 : MonoBehaviour
{
    private Animator AttackAnimator_1;

    private AD_Move AD_MoveScript;
    private Space_Jump Space_JumpScript;
    private Combo_Attack Combo_AttackScript ;

    public GameObject hitboxObject ;
    
    void Start()
    {
        hitboxObject.SetActive(false) ;
        
        AttackAnimator_1 = GetComponent<Animator>();

        AD_MoveScript = GetComponent<AD_Move>();
        Space_JumpScript = GetComponent<Space_Jump>();
        Combo_AttackScript = GetComponent<Combo_Attack>() ;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) 
            && !AD_MoveScript.isAttacking
            && Space_JumpScript.isGrounded
            && !Combo_AttackScript.canCombo)
        {
            AttackAnimator_1.SetBool("isAttack_1", true);

            AD_MoveScript.isAttacking = true;

        }
    }

    public void isTurnOnHitbox() 
    {
        hitboxObject.SetActive(true) ;
    
    }

    public void isTurnOffHitbox() 
    {
        hitboxObject.SetActive(false) ;

    }
}
