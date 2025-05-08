using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTeleport : MonoBehaviour
{
    public string playerTag = "Player";
    public GameManager gameManager;
 

    void OnTriggerEnter2D(Collider2D hit)
    {

        if(hit.CompareTag("Player") && gameManager.AllEnemiesDefeated())
        {
            int CSnum = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(CSnum + 1);


        }


    }


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
