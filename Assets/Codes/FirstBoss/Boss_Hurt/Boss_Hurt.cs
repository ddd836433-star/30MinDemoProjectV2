using UnityEngine;

public class Boss_Hurt : MonoBehaviour
{
    public int bossHP = 30 ;
    public int playerDamage = 10 ;

    private Animator BossAnimator ;
    
    void Start()
    {
        BossAnimator = GetComponent<Animator>() ;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("PlayerAttack")) {

            BossAnimator.SetTrigger("isHurt") ;

            bossHP = bossHP - playerDamage ;

            Debug.Log("보스 피 감소 " + bossHP) ;
        }
    }
}
