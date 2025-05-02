using System.Collections;
using UnityEngine;

public class WizardHealth : MonoBehaviour
{
    public int health = 3;
    public Vector3 respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
    }

    public void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = respawnPoint;
        health = 3;
        Debug.Log("Wizard respawn!");
    }
}
