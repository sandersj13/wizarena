using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlip : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public float moveSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector2.right * moveInput * moveSpeed * Time.deltaTime);

        if (moveInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < 0)
        {
            spriteRenderer.flipX = true;

        }
    }
}



                

