using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform target;
    private Transform background;
    public float speedx = 0.6f;
    public float speedy = 0.6f;


    void Start()
    {
        background = this.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector2 offset = new Vector2(target.position.x * speedx * 0.01f, target.position.y * speedy * 0.01f);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
