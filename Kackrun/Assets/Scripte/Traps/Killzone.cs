using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    Enemy enemy;

    private int trapsLayer;
    private int enemyLayer;
    private int playerLayer;

    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        playerLayer = LayerMask.NameToLayer("Player");
        trapsLayer = LayerMask.NameToLayer("Traps");

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == trapsLayer)
        {
            Destroy(collision.gameObject);


        }
        else if( collision.gameObject.layer == enemyLayer)
        {
            enemy = collision.collider.GetComponent<Enemy>();
            enemy.Die();


        }
        else if(collision.gameObject.layer == playerLayer)
        {
            collision.gameObject.SetActive(false);

            GameManager.PlayerDie();
            AudioManager.PlayDeathAudio();
        }
    }
}
