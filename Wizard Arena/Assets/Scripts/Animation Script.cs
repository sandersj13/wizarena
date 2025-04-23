using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private bool isGrounded;
    private Rigidbody2D rb;

    Animator animController;
    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animController.SetInteger("control", 1);

           


        }

        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animController.SetInteger("control", 2);


        }

        if (Input.GetKey(KeyCode.None))
        {
            animController.SetInteger("control", 0);

        }

    }
}
