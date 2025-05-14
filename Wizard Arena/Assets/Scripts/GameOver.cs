using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private CharacterMovement access;
    public GameObject Wizard;
    // Start is called before the first frame update
    void awake()
    {
        access = Wizard.GetComponent<CharacterMovement>();
        
    }

    void Start()
    {
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
      if (access.gameOver == true)
      {
            gameObject.SetActive(true);
            Debug.Log("gameOver");

      }
    }
}
