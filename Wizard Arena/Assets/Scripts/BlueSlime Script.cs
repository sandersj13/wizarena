using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlimeScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    public int damage = 10;

    private Transform player;
    private float lastAttackTime;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            Attack();
        }
        else
        {
            MoveTowardPlayer();
        }
            
    }
    void MoveTowardPlayer()
    {

        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
    }
    void Attack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            Debug.Log("Monster attacks!");

            lastAttackTime = Time.time;
        }
    }
}
