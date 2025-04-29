using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBall : MonoBehaviour
{
    public float freezeDuration = 3f;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void CollisionEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyFreeze enemy = collision.GetComponent<EnemyFreeze>();

            if (enemy != null)
            {
                enemy.Freeze(freezeDuration);
            }

            Destroy(gameObject);
        }
        
        
    }
}
