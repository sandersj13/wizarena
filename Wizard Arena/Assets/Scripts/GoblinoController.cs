using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinoController : MonoBehaviour
{
    public GameObject rockPrefab;
    public float throwInterval = 2f;
    public Transform target;
    public float throwForce = 20f;

    private float throwTimer;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        throwTimer = throwInterval;

    }

    // Update is called once per frame
    void Update()
    {
        throwTimer -= Time.deltaTime;

        if (throwTimer <= 0f)
        {
            ThrowRock();
            throwTimer = throwInterval;
        }
    }

    void ThrowRock()
    {
        GameObject rock = Instantiate(rockPrefab, transform.position, Quaternion.identity);

        Vector2 direction = (target.position - transform.position).normalized;

        Rigidbody2D rb = rock.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * throwForce;
        }
    }
}