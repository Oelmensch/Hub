using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsFallCollision : MonoBehaviour
{
    Rigidbody2D rigidBody;
    BoxCollider2D box;
    AudioSource audioSource;
    LayerMask groundMask;


    private int flyingLayer;
    private int groundLayer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();

        groundMask = LayerMask.GetMask("Ground");
        groundLayer = LayerMask.NameToLayer("Ground");
        flyingLayer = LayerMask.NameToLayer("FlyingPlatform");
    }

    public void Fall()
    {
        rigidBody.bodyType = RigidbodyType2D.Dynamic;
        rigidBody.freezeRotation = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            print("hit");
            if (rigidBody.bodyType == RigidbodyType2D.Dynamic)
            {
                Vector3 pos = rigidBody.position;
                RaycastHit2D hit;

                hit = Physics2D.Raycast(pos, Vector2.down, 3f, groundMask);
                pos.y = hit.point.y + 1.5f;
                transform.position = pos;
                box.usedByComposite = true;
                
                Destroy(rigidBody);
                audioSource.Play();
            }
        }
        if(collision.gameObject.layer == flyingLayer)
        {
            audioSource.Play();
            Destroy(this.gameObject);
        }
    }
}
