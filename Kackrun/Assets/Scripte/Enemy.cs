using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D myBody;
    Transform myTrans;
	BoxCollider2D bodyCollider;
    public LayerMask enemyMask;
    public float speed = 1;

    private int thisEnemy;
    float myWidth;
    float myHeight;

    void Start()
    {
        SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
		bodyCollider = GetComponent<BoxCollider2D>();

		myTrans = transform;
        myBody = GetComponent<Rigidbody2D>();
        myWidth = bodyCollider.size.x/ 2 - bodyCollider.offset.x;
		myHeight = bodyCollider.size.y / 2 - bodyCollider.offset.y;

    }

    void FixedUpdate()
    {
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;

        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - myTrans.right.toVector2() * 0.05f, enemyMask);


        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.toVector2() * 0.05f);

        if (!isGrounded || isBlocked)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
        }

        Vector2 myVel = myBody.velocity;

        myVel.x = myTrans.right.x * -speed;
        myBody.velocity = myVel;
    }
    public void Die()
    {
        Destroy(gameObject);
            
    }
}
