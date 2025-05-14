using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinoHealth : MonoBehaviour
{
    public int health = 3;

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Goblino took damage! Health now: " + health);

        if (health <= 0)
        {

            Die();
        }

    }

    void Die()
    {

        Debug.Log("Goblino has been defeated!");
        Destroy(gameObject);


    }
}
