using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinoThrow : MonoBehaviour
{
    public GameObject rockPrefab;
    public Transform throwPoint;
    public Transform wizardTarget;
    public float throwForce = 50f;
    public float throwCooldown = 2f;

    private float throwTimer = 0f;

  


    // Update is called once per frame
    void Update()
    {
        throwTimer += Time.deltaTime;

        if (Vector2.Distance(transform.position, wizardTarget.position) < 10f && throwTimer >= throwCooldown)
        {
            ThrowRock();
            throwTimer = 0f;
        }
    }
    void ThrowRock()
    {
        GameObject rock = Instantiate(rockPrefab, throwPoint.position, Quaternion.identity);

        Vector2 direction = (wizardTarget.position - throwPoint.position).normalized;

        Rigidbody2D rb = rock.GetComponent<Rigidbody2D>();
        rb.velocity = direction * throwForce;
    }
}

