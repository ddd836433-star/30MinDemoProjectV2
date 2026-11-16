using UnityEngine;

public class Player_Hurt : MonoBehaviour
{
    private Animator hp_Animator ;

    public int playerHP = 30 ;
    public int enemyDamage = 10 ;

    void Start() {

        hp_Animator = GetComponent<Animator>() ;

    }
    
    void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("EnemyAttack")) {

            playerHP = playerHP - enemyDamage ;

            if (playerHP <= 0) {

                Debug.Log("플레이어 사망") ;
                
                hp_Animator.SetBool("isDead", true) ;

                GetComponent<AD_Move>().enabled = false ;

                Invoke(nameof(isEndGame), 0.55f) ;

                return ;
            }

            hp_Animator.SetBool("isHurt", true) ;

            Invoke(nameof(isEndAnimation), 0.15f) ;
        }
    }

    private void isEndAnimation() {

        hp_Animator.SetBool("isHurt", false) ;

    }

    private void isEndGame() {

        Time.timeScale = 0f ;
    }
}
