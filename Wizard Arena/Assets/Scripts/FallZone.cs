using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallZone : MonoBehaviour
{

    public Transform spawnPoint;


    void OnTriggerEnter2D(Collider2D other)
    {
        

    if (other.CompareTag("Player"))
    {
            other.transform.position = spawnPoint.position;
    }

        
    }
}
