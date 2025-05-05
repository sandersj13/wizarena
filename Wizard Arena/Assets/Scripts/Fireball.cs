using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnTriggerEnter2D(Collider2D other)
     {
        BlueSlime slime = other.GetComponent<BlueSlime>();
        if (slime != null)
        {
            slime.TakeDamage(damage);
            Destroy(gameObject);
        }


        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        
     }
}
