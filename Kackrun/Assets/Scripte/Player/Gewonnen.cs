using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gewonnen : MonoBehaviour
{
    int playerLayer;

    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != playerLayer)
            return;

        Debug.Log("Player Won!");
        GameManager.PlayerWon();
    }
}
