using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsFall : MonoBehaviour
{
    public TrapsFallCollision block;

    Animator anim;
    BoxCollider2D box;
    AudioSource audioSource;
    int playerLayer;
    int fallParamID;

    void Start()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();

        playerLayer = LayerMask.NameToLayer("Player");
        fallParamID = Animator.StringToHash("Activate");
    }

    public void Fall()
    {
        block.Fall();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != playerLayer)
            return;

        box.enabled = false;
        audioSource.Play();
        anim.SetTrigger(fallParamID);
    }
}
