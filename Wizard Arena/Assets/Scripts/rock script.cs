using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockscript : MonoBehaviour
{

    public int damage = 10;
    public float lifetime = 5f;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CharacterMovement playerHealth = collision.gameObject.GetComponent<CharacterMovement>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);

        }
    }
}
