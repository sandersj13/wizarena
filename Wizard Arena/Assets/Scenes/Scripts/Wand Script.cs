using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandScript : MonoBehaviour
{
    public GameObject fireballlPrefab;
    public Transform firePoint;
    public float fireballSpeed = 20f;
    
    

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
           
            Fire();
            Debug.Log("Anything");
        }

    }
    void Fire()
    {
        Instantiate(fireballlPrefab, firePoint.position, firePoint.rotation);

        GameObject fireball = Instantiate(fireballlPrefab, firePoint.position, firePoint.rotation);

        Vector3 direction = GetMouseDirection();

        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * fireballSpeed;
        }

    }

    Vector3 GetMouseDirection()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

        Vector3 direction = (mousePos - firePoint.position).normalized;

        return direction;
    }

}
