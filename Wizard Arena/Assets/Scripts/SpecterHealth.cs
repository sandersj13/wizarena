using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecterHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
