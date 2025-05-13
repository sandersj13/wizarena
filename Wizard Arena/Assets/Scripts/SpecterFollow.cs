using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecterFollow : MonoBehaviour
{
    public Transform wizard;
    public float speed = 2f;
    public float followDistance = 1.5f;

    // Update is called once per frame
    void Update()
    {
        if (wizard == null) return;

        float distance = Vector2.Distance(transform.position, wizard.position);
        if (distance > followDistance)
        {
            Vector2 direction = (wizard.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, wizard.position, speed * Time.deltaTime);
        }
    }
}
