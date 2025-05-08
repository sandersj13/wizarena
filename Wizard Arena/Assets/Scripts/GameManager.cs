
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int enemiesRemaining;

    // Start is called before the first frame update
    void Start()
    {
        enemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    public void EnemyDefeated()
    {
        enemiesRemaining--;
        if (enemiesRemaining < 0)
            enemiesRemaining = 0;
    }

    public bool AllEnemiesDefeated()
    {
        return enemiesRemaining <= 0;
    }
}
