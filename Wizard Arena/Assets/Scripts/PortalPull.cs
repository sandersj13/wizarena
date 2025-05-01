using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPull : MonoBehaviour
{
    public float pullRadius = 3f;
    public float pullForce = 5f;

    private void FixedUpdate()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return;


        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb == null) return;


        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < pullRadius)
        {

            Vector2 direction = (transform.position - player.transform.position).normalized;

            rb.AddForce(direction * pullForce);
        }
    }
}
    
        
  

