using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    public float attackCooldown = 1f;


    private float lastAttackTime;


    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Zombie Trigger Stay with: " + collision.gameObject.name); 

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Zombie Attacking!");

            if (Time.time - lastAttackTime > attackCooldown)
            {
                CharacterMovement player = collision.GetComponent<CharacterMovement>();


                if (player != null)
                {

                    Debug.Log("Zombie Deals Damage: " + damage);
                    player.TakeDamage(damage);
                    lastAttackTime = Time.time;

                }    
                
            }

        }

    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log("Zombie Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Zombie Died");
        Destroy(gameObject);
    }
}
