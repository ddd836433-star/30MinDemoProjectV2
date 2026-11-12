using UnityEngine;

public class Combo_Attack : MonoBehaviour
{
    private Animator ComboAnimator ;

    public bool canCombo = false;
    public bool isFinishCombo = false;

    private AD_Move AD_MoveScript ;

    void Start() 
    {
        ComboAnimator = GetComponent<Animator>() ;

        AD_MoveScript = GetComponent<AD_Move>() ;
    }

    public void isEnterToClick()
    {
        canCombo = true;

    }

    public void isExitToClick()
    {
        canCombo = false;

    }

    public void isFinishToClick() 
    {
        isFinishCombo = true ;

    }

    public void isEndAttack() 
    {
        if (ComboAnimator.GetBool("isAttack_2"))
            return ;

        isResetCombo() ;
        
    }

    public void isResetCombo() 
    {
        canCombo = false ;
        isFinishCombo = false ;
        AD_MoveScript.isAttacking = false ;

        ComboAnimator.SetBool("isAttack_1", false) ;
        ComboAnimator.SetBool("isAttack_2", false) ;
    }
}
