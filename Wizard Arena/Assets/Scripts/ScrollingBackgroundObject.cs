using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackgroundObject : MonoBehaviour
{
    public float parallaxFactor = 1f;

    public Transform player;

    private Vector3 lastPlayerPosition;

    private float width;




    // Start is called before the first frame update
    void Start()
    {
        lastPlayerPosition = player.position;

        width = GetComponent<SpriteRenderer>().bounds.size.x;


    }

    // Update is called once per frame
    void Update()
    {
        float distanceMoved = player.position.x - lastPlayerPosition.x;

        transform.position += Vector3.right * distanceMoved * parallaxFactor;

        if (transform.position.x <= -width)
        {
            transform.position = new Vector3(transform.position.x + width * 2, transform.position.y, transform.position.z);

        }


        lastPlayerPosition = player.position;
    }

}
