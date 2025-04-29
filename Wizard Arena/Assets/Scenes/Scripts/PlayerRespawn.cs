using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector2 respawnPoint;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (respawnPoint == Vector2.zero)
        {
            respawnPoint = transform.position;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("FallZone"))
        {
            Respawn();
        }
    }


    void Respawn()
    {

        transform.position = respawnPoint;

        rb.velocity = Vector2.zero;
    }
}