using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Leben : MonoBehaviour
{
    public GameObject deathVFXPrefab;

    Enemy enemy;
    Animator anim;
    Rigidbody2D rigidbody;

    public float invincibleTime = 2f;
    public bool isAlive;
    public bool hitable;
    public int lives = 3;
    public int whichEnemy;
    private int trapsLayer;
    private int enemyLayer;
    private int playerLayer;

    private void Start()
    {

        hitable = true;
        isAlive = true;

        enemyLayer = LayerMask.NameToLayer("Enemy");
        playerLayer = LayerMask.NameToLayer("Player");
        trapsLayer = LayerMask.NameToLayer("Traps");
        
        anim = GetComponentInChildren<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();

        UIManager.UpdateLivesUI(lives);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        enemy = collision.collider.GetComponent<Enemy>();
        if (collision.gameObject.layer == enemyLayer && isAlive)
        {
            
            foreach (ContactPoint2D point in collision.contacts)
            {
                Debug.DrawLine(point.point, point.point + point.normal, Color.red, 5);

                if ( point.normal.y >= 0.9f)
                {

                    Vector2 velocity = rigidbody.velocity;
                    velocity.y = GetComponent<PlayerController>().jumpForce * 2;
                    rigidbody.velocity = velocity;
                    enemy.Die();

                }
                else
                {
                    Hurt();
                }
            }
        }
        //Traps tödlicher Lassen?
        if (collision.gameObject.layer == trapsLayer && isAlive)
        {
            
            Instantiate(deathVFXPrefab, transform.position, transform.rotation);

            gameObject.SetActive(false);

            GameManager.PlayerDie();
            AudioManager.PlayDeathAudio();

            isAlive = false;
        }
    }

    public void Hurt()
    {
        if (hitable)
        {
            lives--;

            UIManager.UpdateLivesUI(lives);

            if (lives > 0)
            {
                
                StartCoroutine(HurtBlinker(invincibleTime));
                StartCoroutine(HitBlinker(invincibleTime));
            }
            else
            {
                hitable = false;
                Instantiate(deathVFXPrefab, transform.position, transform.rotation);

                gameObject.SetActive(false);

                GameManager.PlayerDie();
                AudioManager.PlayDeathAudio();

                isAlive = false;
            }
        }
    }

    IEnumerator HurtBlinker(float hurtTime)
    {
        hitable = false;
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer);

        anim.SetLayerWeight(1, 1);

        yield return new WaitForSeconds(hurtTime);

        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);
        anim.SetLayerWeight(1, 0);
        hitable = true;
    }

    IEnumerator HitBlinker(float hurtTime)
    {
        hitable = false;
        Physics2D.IgnoreLayerCollision(trapsLayer, playerLayer);

        anim.SetLayerWeight(1, 1);

        yield return new WaitForSeconds(hurtTime);

        Physics2D.IgnoreLayerCollision(trapsLayer, playerLayer, false);
        anim.SetLayerWeight(1, 0);
        hitable = true;
    }
    /* StayAlive stayAlive;
     AnimatorController myAnim;
     Spieler spieler;

     public GameObject Spieler;
     public GameObject CheckPoint;


     public bool hitable;
     public bool healable;

     public int lebenStart = 3;
     public int leben;
     public int lebenUp;
     private int score;



     void Start()
     {
         spieler = GameObject.Find("Kacki").GetComponent<Spieler>();
         myAnim = AnimatorController.instance;

         lebenUp = 10;
         leben = lebenStart;
         hitable = true;
         healable = true;

         lebenText.text = leben.ToString();
     }

     void Update()
     {
         stayAlive = GameObject.Find("StayAlive").GetComponent<StayAlive>();
         leben = stayAlive.GetLeben();
         lebenText.text = leben.ToString();
     }

     void Heal(int heal)
     {
         if (healable == true)
         {
             leben += heal;
             stayAlive.SetLeben(leben);   
             lebenText.text = leben.ToString();
             healable = false;
         }
     }

     public void Damage()
     {
         if (hitable == true)
         {
             //Debug.Log("Schaden erhalten");
             leben--;
             stayAlive.SetLeben(leben);
             hitable = false;
             if (leben > 0)
             {

                 myAnim.Hit(incincibleTimeAfterhurt);
                 StartCoroutine(HitPlayer());
             }
             else if (leben <= 0)
             {
                 Die();
             }
             lebenText.text = leben.ToString();

         }
     }

     public void Die()
     {
             leben = lebenStart;
             stayAlive.SetLeben(leben);
             Spieler.transform.position = Killzone_2.CheckPoint;
             lebenText.text = leben.ToString();
             StartCoroutine(HitPlayer());
     }

     public void SetLeben(int _leben)
     {
         leben = _leben;
     }

     public int GetLeben()
     {
         return leben;
     }

     public int GetStartLeben()
     {
         return lebenStart;
     }
     IEnumerator HealPlayer()
     {
         yield return new WaitForSeconds(1);
         healable = true;
     }

     IEnumerator HitPlayer()
     {
         yield return new WaitForSeconds(incincibleTimeAfterhurt);
         hitable = true;
     }
     */
}
