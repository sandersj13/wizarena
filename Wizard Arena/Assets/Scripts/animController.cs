using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
    public CharacterMovement health;
   
    Animator animController;
    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animController.SetInteger("Reg", 1);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animController.SetInteger("Reg", 2);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animController.SetInteger("Reg", 3);
        }

    }
}
