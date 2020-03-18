using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int heal = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(this.gameObject, 0.0f);
        collider.SendMessage("Heal", heal);    
    }
}
