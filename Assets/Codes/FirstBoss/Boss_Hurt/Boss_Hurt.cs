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

            bossHP = bossHP - playerDamage ;

            if (bossHP <= 0) {

                Debug.Log("보스 사망") ;

                BossAnimator.SetTrigger("isDead") ;

                Invoke(nameof(isTurnOffObject), 0.5f) ;

                return ;
            }

            BossAnimator.SetTrigger("isHurt") ;

            Debug.Log("보스 피 감소 " + bossHP) ;
        }
    }

    private void isTurnOffObject() {

        gameObject.SetActive(false) ;

    }
}
