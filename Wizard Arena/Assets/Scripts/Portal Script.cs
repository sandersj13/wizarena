using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTeleport : MonoBehaviour
{
 

    void OnTriggerEnter2D(Collider2D hit)
    {

        if(hit.gameObject.tag == "Portal")
        {
            int CSnum = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(CSnum + 1);


        }


    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
